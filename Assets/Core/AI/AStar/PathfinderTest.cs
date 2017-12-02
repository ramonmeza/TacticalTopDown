/// <summary>
/// Pathfinder test.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PathfinderTest : MonoBehaviour
{
	public Pathfinder PathFinderComponent;

	public PathNode startNode;
	public PathNode targetNode;

	public List<PathNode> Path = new List<PathNode>();

	void Start ()
	{
		Path = PathFinderComponent.FindBestPath( startNode, targetNode );
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		foreach( PathNode node in Path )
		{
			if( node != null )
			{
				Gizmos.DrawSphere( node.transform.position, 0.6f );

				if( node != Path.Last() )
				{
					Gizmos.DrawLine( 
						node.transform.position + 
							( node.transform.up * 0.05f ), 
						Path[ Path.IndexOf( node ) + 1 ]
							.transform.position + 
						( Path[ Path.IndexOf( node ) + 1 ]
							.transform.up * 0.05f ) );

					Gizmos.DrawLine( 
						node.transform.position + 
						( node.transform.right * 0.05f ), 
						Path[ Path.IndexOf( node ) + 1 ]
							.transform.position + 
						( Path[ Path.IndexOf( node ) + 1 ]
							.transform.right * 0.05f ) );
				}
			}
		}
	}
}