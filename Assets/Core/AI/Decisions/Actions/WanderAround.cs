/// <summary>
/// Wonder around aimlessly.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WanderAround : ActionNode
{
	/// <summary>
	/// The acceptance radius.
	/// </summary>
	public float AcceptanceRadius = 0.5f;

	/// <summary>
	/// The character movement component.
	/// </summary>
	public Pathfinder m_PathfinderComponent;

	/// <summary>
	/// The character movement component.
	/// </summary>
	private CharacterMovementComponent m_CharacterMovementComponent;

	/// <summary>
	/// A path to follow
	/// </summary>
	private List<PathNode> m_CurrentPath = new List<PathNode>();

	void Start ()
	{
		// Initialize component
		m_CharacterMovementComponent = 
			GetComponent<CharacterMovementComponent>();
	}

	void Update ()
	{
		// If the current path is empty
		if( m_CurrentPath.Count == 0 )
		{
			// Get the start node
			PathNode startNode = PathfinderHelper
									.FindClosestNode( gameObject, 
			                        				  m_PathfinderComponent );
			
			// Get the target node
			PathNode targetNode = PathfinderHelper
									.RandomNodeInGrid( m_PathfinderComponent
				                  						.GetGrid() );

			// Find the best path from start node to target node
			m_CurrentPath = 
				m_PathfinderComponent.FindBestPath( startNode, targetNode );
		}

		// If you are at the node along the path
		if( IsAtPoint( m_CurrentPath.Last() ) )
		{
			// Remove the node from the path
			m_CurrentPath.Remove( m_CurrentPath.Last() );
		}
		else
		{
			// Move to the node
			transform.position = 
				Vector3.MoveTowards(transform.position, 
				                    m_CurrentPath.Last().transform.position, 
				                    m_CharacterMovementComponent.Speed * 
				                    	Time.deltaTime );
		}
	}

	/// <summary>
	/// Determines whether this instance is at the specified point.
	/// </summary>
	/// <returns><c>true</c> if this is at point the specified point; 
	/// otherwise, <c>false</c>.</returns>
	private bool IsAtPoint ( PathNode point )
	{
		if( Vector2.Distance( transform.position, 
		                      point.transform.position ) < AcceptanceRadius )
			return true;
		
		return false;
	}
}