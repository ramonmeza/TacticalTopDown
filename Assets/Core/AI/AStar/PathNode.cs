/// <summary>
/// A single path node for the A* pathfinding.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
	/// <summary>
	/// List of the connected nodes.
	/// This specifies the nodes this node can traverse to.
	/// </summary>
	public List<PathNode> ConnectedNodes = new List<PathNode>();

	// Draw debug/editor objects
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere( transform.position, 0.5f );

		foreach( PathNode node in ConnectedNodes )
		{
			if(node != null)
				Gizmos.DrawLine( transform.position, node.transform.position );
		}
	}
}
