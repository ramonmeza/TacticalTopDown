/// <summary>
/// A node for the A* path finding algorithm.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarNode : MonoBehaviour
{
	/// <summary>
	/// A list of all of the connected nodes.
	/// </summary>
	public List<AStarNode> ConnectedNodes;

	/// <summary>
	/// The parent node to this one used during the A* algorithm.
	/// </summary>
	private AStarNode m_ParentNode = null;

	// Save the costs for each node
	private float GCost = 0.0f;
	private float HCost = 0.0f;
	private float FCost = 0.0f;
	private float MovementCost = 0.0f;

	/// <summary>
	/// Gets the FCost for this node.
	/// </summary>
	/// <returns>The FCost for this node.</returns>
	public float GetFCost()
	{
		return FCost;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="AStarNode"/> class.
	/// </summary>
	/// <param name="startNode">Start node.</param>
	/// <param name="targetNode">Target node.</param>
	public void FindCosts( AStarNode startNode, AStarNode targetNode )
	{
		GCost = GValue( startNode );
		HCost = HValue( targetNode );
		FCost = GCost + HCost;

		MovementCost = m_ParentNode.GCost + GCost;
	}

	/// <summary>
	/// Sets the parent node.
	/// </summary>
	/// <param name="parent">To new parent node.</param>
	public void SetParent( AStarNode parent )
	{
		m_ParentNode = parent;
	}

	/// <summary>
	/// Distance cost from the starting node.
	/// </summary>
	/// <returns>The distance from the starting node.</returns>
	/// <param name="startNode">Node where the search started.</param>
	private float GValue( AStarNode startNode )
	{
		// If this is the starting node
		if( startNode == this )
			return 0.0f;

		return Vector3.Distance( startNode.transform.position, 
			transform.position );
	}

	/// <summary>
	/// Distance cost from the target node.
	/// </summary>
	/// <returns>The distance from the target node.</returns>
	/// <param name="startNode">The target node.</param>
	private float HValue( AStarNode targetNode )
	{
		return Vector3.Distance( transform.position, 
			targetNode.transform.position );
	}

	// Draw a debug sphere
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere( transform.position, 1.0f );

		// Draw lines to connected
		foreach( AStarNode node in ConnectedNodes )
		{
			if( node != null )
				Gizmos.DrawLine( transform.position, node.transform.position );
		}
	}
}
