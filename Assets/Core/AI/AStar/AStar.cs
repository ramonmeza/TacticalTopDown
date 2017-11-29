/// <summary>
/// The implementation of A* pathfinding algorithm.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
	/// <summary>
	/// List of every node that forms the grid.
	/// </summary>
	public List<AStarNode> Grid;

	// List of nodes that need to be checked
	private List<AStarNode> OpenList;

	// List of nodes that have already been checked
	private List<AStarNode> ClosedList;

	/// <summary>
	/// Finds the closest node to the given target.
	/// </summary>
	/// <returns>The closest node to the given object.</returns>
	/// <param name="obj">Game object search from.</param>
	public AStarNode FindClosestNode( GameObject obj )
	{
		return null;
	}

	/// <summary>
	/// Finds the shortest path to a target object.
	/// </summary>
	/// <param name="obj">Starting object.</param>
	/// <param name="target">Target object.</param>
	public void FindShortestPath( GameObject start, GameObject target )
	{
		AStarAlgorithm( FindClosestNode( start ), FindClosestNode( target ) );
	}

	/// <summary>
	///  The A* pathfinding algorithm implementation
	/// </summary>
	/// <returns>List of nodes that form a path</returns>
	/// <param name="startNode">Starting node.</param>
	/// <param name="targetNode">Target node.</param>
	private List<AStarNode>
		AStarAlgorithm( AStarNode startNode, AStarNode targetNode )
	{
		// Create a node to keep track of where we are in the search
		AStarNode currentNode = startNode;

		// While we haven't gotten to the target node
		while( currentNode != targetNode )
		{
			/* Step 1 */
			// Add startNode to closed list
			ClosedList.Add( currentNode );

			// Temp node for finding the smallest FCost node
			AStarNode bestNode = null;

			// Access the nodes connected to the start node
			foreach( AStarNode connected in startNode.ConnectedNodes )
			{
				// Set the parent for the connected node
				connected.SetParent( currentNode );

				// Find the costs of the node
				connected.FindCosts( currentNode, targetNode );

				// Check node to see if it is the best node to move to
				if( bestNode == null )
				{
					bestNode = connected;
				}
				else
				{
					// If this node is better than the previous best node
					if( connected.GetFCost() < bestNode.GetFCost() )
					{
						// Add the previous best node to the open list
						OpenList.Add( bestNode );

						// Set the new best node
						bestNode = connected;
					}
				}
			}

			// Add the best node to the closed list
			if( bestNode != null )
				ClosedList.Add( bestNode );
			else
				return null;
		}

		// Return the list for the best path
		return ClosedList;
	}
}
