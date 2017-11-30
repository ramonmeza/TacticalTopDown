/// <summary>
/// Implementation of the A* pathfinding algorithm.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
	/// <summary>
	/// List of all the nodes that form the grid.
	/// </summary>
	public List<PathNode> Grid = new List<PathNode>();

	/// <summary>
	/// Finds the shortest path between two nodes.
	/// </summary>
	/// <returns>List of nodes that make up the path.</returns>
	/// <param name="startNode">Start node.</param>
	/// <param name="targetNode">Target node.</param>
	public List<PathNode> 
		FindShortestPath( PathNode startNode, PathNode targetNode )
	{
		/* 
		 * DON'T FORGET CLOSED LIST, PLACE ALREADY CHECKED NODES IN LIST
		 * DON'T CHECK THEM TWICE
		*/
		List<PathNode> ClosedList = new List<PathNode>();

		// Keep track of the best path
		List<PathNode> BestPath = new List<PathNode>();
		BestPath.Add( startNode );

		// Keep track of the current node
		PathNode currentNode = startNode;

		// Find the path
		while( currentNode != targetNode )
		{
			// Add current node to the closed list
			if( ClosedList.Contains( currentNode ) != true )
				ClosedList.Add( currentNode );

			// Keep track of the best node
			PathNode bestNode = null;
			
			// Check each connected node
			foreach( PathNode connected in currentNode.ConnectedNodes )
			{
				// If you haven't already checked this node
				if( ClosedList.Contains( connected ) != true )
				{
					// Calculate the node's cost
					connected.CalculateCosts( startNode, targetNode );

					// Find the node with the lowest F value
					if( bestNode == null )
					{
						bestNode = connected;
					}
					else if( connected.F < bestNode.F )
					{
						bestNode = connected;
					}

					// Add node to closed list
					ClosedList.Add( connected );
				}
			}

			// Add the best node to the path
			if( bestNode != null )
			{
				BestPath.Add( bestNode );
				currentNode = bestNode;
			}
			else
			{
				break;
			}
		}

		return BestPath;
	}
}