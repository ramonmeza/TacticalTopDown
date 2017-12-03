/// <summary>
/// Wonder around aimlessly.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	/// A point to goto
	/// </summary>
	private PathNode m_PointToGoto = null;

	void Start ()
	{
		// Initialize component
		m_CharacterMovementComponent = 
			GetComponent<CharacterMovementComponent>();
	}

	void Update ()
	{
		if( m_PointToGoto != null &&
		    !IsAtPoint( m_PointToGoto ) )
		{
		}
		else if( m_PointToGoto == null || IsAtPoint( m_PointToGoto ) )
		{
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