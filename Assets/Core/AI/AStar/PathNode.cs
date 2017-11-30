/// <summary>
/// A single path node for the A* pathfinding.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
	/// <summary>
	/// List of connected nodes that can be traveled to.
	/// </summary>
	public List<PathNode> ConnectedNodes = new List<PathNode>();

	/// <summary>
	/// Cost of path to move to this node
	/// </summary>
	public float G = 0.0f;

	/// <summary>
	/// Estimated cost to target node, using straight line distance
	/// </summary>
	public float H = 0.0f;

	/// <summary>
	/// The cost to take a given path
	/// </summary>
	public float F = 0.0f;

	/// <summary>
	/// Calculates the costs.
	/// </summary>
	/// <param name="targetNode">Target node.</param>
	public void CalculateCosts( PathNode startNode, PathNode targetNode )
	{
		// Distance from startNode to this node
		G = ( transform.position - startNode.transform.position ).magnitude;

		// Straight line distance from this node to target node
		H = ( targetNode.transform.position - transform.position ).magnitude;

		// Cost of taking this path
		F = G + H;
	}

	// Draw debug/editor objects
	void OnDrawGizmos()
	{
		// Draw sphere
		Gizmos.DrawSphere( transform.position, 0.5f );

		// Draw a line between each connected node
		Gizmos.color = Color.red;
		foreach( PathNode node in ConnectedNodes )
		{
			if( node != null )
				Gizmos.DrawLine( transform.position, node.transform.position );
		}
	}
}
