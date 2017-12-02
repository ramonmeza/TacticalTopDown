/// <summary>
/// Helper functions for the pathfinding.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderHelper : MonoBehaviour
{
	/// <summary>
	/// Finds the straight line distance from the a node to the b node.
	/// </summary>
	public static float StraightLineDistance ( PathNode a, PathNode b )
	{
		return Vector2.Distance( a.transform.position, b.transform.position );
	}

	/// <summary>
	/// Finds the straight line distance from the a node to the b node.
	/// </summary>
	public static float StraightLineDistance ( GameObject a, GameObject b )
	{
		return Vector2.Distance( a.transform.position, b.transform.position );
	}

	/// <summary>
	/// Finds the straight line distance from the a node to the b node.
	/// </summary>
	public static float StraightLineDistance ( Vector3 a, Vector3 b )
	{
		return Vector2.Distance( a, b );
	}

	/// <summary>
	/// Gives a random node from the given path.
	/// </summary>
	public static PathNode RandomNodeInPath ( Pathfinder path )
	{
		if( path.Grid.Count > 0 )
			return path.Grid[ Random.Range( 0, path.Grid.Count - 1 ) ];
		else
			return null;
	}

	/// <summary>
	/// Finds the closest node to the given target.
	/// </summary>
	/// <returns>The closest node to target.</returns>
	/// <param name="target">Target</param>
	public static PathNode FindClosestNode ( GameObject target, Pathfinder path )
	{
		return FindClosestNode( target.transform.position, path );
	}

	/// <summary>
	/// Finds the closest node to the given target.
	/// </summary>
	/// <returns>The closest node to target.</returns>
	/// <param name="target">Target.</param>
	public static PathNode FindClosestNode ( Vector3 target, Pathfinder path )
	{
		PathNode closestNode = null;

		foreach( PathNode node in path.Grid )
		{
			if( closestNode == null ||
			    StraightLineDistance( target, node.transform.position ) <
			    StraightLineDistance( target, closestNode.transform.position ) )
			{
				closestNode = node;
			}
		}

		return closestNode;
	}
}
