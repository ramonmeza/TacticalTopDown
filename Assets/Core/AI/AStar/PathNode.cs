/// <summary>
/// Path node.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
	/// <summary>
	/// Heuristic; Distance from a node to the target node.
	/// </summary>
	public float H { get; set; }

	/// <summary>
	/// Movement cost
	/// </summary>
	public float G { get; set; }

	/// <summary>
	/// F = G + H
	/// </summary>
	public float F { get; set; }

	/// <summary>
	/// A node to reach this node.
	/// </summary>
	public PathNode Parent { get; set; }

	/// <summary>
	/// List of neighbors from this node to other nodes.
	/// </summary>
	public List<PathNode> Neighbors = new List<PathNode>();

	void Start()
	{
		// Initialize cost values
		H = 0.0f;
		G = 0.0f;
		F = 0.0f;

		// Initialize parent
		Parent = null;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawSphere( transform.position, 0.5f );

		foreach( PathNode node in Neighbors )
		{
			if( node != null )
				Gizmos.DrawLine( transform.position, node.transform.position );
		}
	}
}
