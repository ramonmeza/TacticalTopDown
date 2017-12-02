/// <summary>
/// Implementation of A* pathfinding algorithm using waypoints (PathNodes).
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathfinder : MonoBehaviour
{
	/// <summary>
	/// List of all of the nodes for the pathfinding.
	/// </summary>
	private List<PathNode> m_Grid = new List<PathNode>();

	void Start ()
	{
		// Get all nodes parented to this object for the grid
		foreach( PathNode child in GetComponentsInChildren<PathNode>() )
			m_Grid.Add( child );
	}

	public List<PathNode> GetGrid ()
	{
		return m_Grid;
	}

	/// <summary>
	/// Finds the best path.
	/// </summary>
	/// <param name="startNode">Start node.</param>
	/// <param name="targetNode">Target node.</param>
	public List<PathNode> FindBestPath ( PathNode startNode, 
	                                     PathNode targetNode )
	{
		// If the start node is the target node
		if( startNode == targetNode )
			return RevealPath( startNode );

		// List of nodes that need to be checked.
		List<PathNode> OpenList = new List<PathNode>();

		// List of nodes that have been checked.
		List<PathNode> ClosedList = new List<PathNode>();

		// For each node in the grid
		foreach( PathNode node in m_Grid )
		{
			// Get H cost of each node
			node.H = PathfinderHelper.StraightLineDistance( node, targetNode );

			// Initialize other node variables
			node.G = 0.0f;
			node.Parent = null;
		}

		// Current node in the path
		PathNode currentNode = startNode;

		// Add current node to the closed list since we're evaluating it
		ClosedList.Add( currentNode );

		while( currentNode != targetNode )
		{
			foreach( PathNode node in currentNode.Connections )
			{
				// If the connected node is the target node
				if( node == targetNode )
				{
					node.Parent = currentNode;
					return RevealPath( node );
				}

				// If the node isn't already in our closed list
				if( ClosedList.Contains( node ) == false )
				{
					// If the node is already on the open list
					if( OpenList.Contains( node ) == true )
					{
						// Check if cost to move to this is cheaper than before
						float specialCase = currentNode.G +
						                    PathfinderHelper
												.StraightLineDistance( node, 
						                             currentNode );

						if( specialCase < node.G )
						{
							node.Parent = currentNode;
						}
					}
					else
					{
						// Get G cost of each node
						node.G = currentNode.G +
						PathfinderHelper.StraightLineDistance( node, 
						                                       currentNode );

						// Get F cost of each node
						node.F = node.H + node.G;
				
						// Parent the node to the current node
						node.Parent = currentNode;

						// Add nodes to open list to be evaluated
						OpenList.Add( node );
					}
				}
			}

			PathNode BestNode = LowestFCostNode( OpenList );
			ClosedList.Add( BestNode );
			OpenList.Remove( BestNode );

			currentNode = ClosedList.Last();
		}

		return null;
	}

	/// <summary>
	/// Finds the path node with the lowest F cost value in a given list.
	/// </summary>
	/// <returns>The path node with the lowest F cost value.</returns>
	/// <param name="nodes">List of nodes to search.</param>
	private PathNode LowestFCostNode ( List<PathNode> nodes )
	{
		PathNode lowest = null;

		foreach( PathNode node in nodes )
		{
			// Update lowest
			if( lowest == null || node.F < lowest.F )
				lowest = node;
		}

		return lowest;
	}

	/// <summary>
	/// Reveals the path taken to get to a given node.
	/// </summary>
	/// <returns>The path to the given node. The list's first element
	/// is the last node on the path and the last element is the first 
	/// node on the path.</returns>
	/// <param name="node">Last node on the path.</param>
	private List<PathNode> RevealPath ( PathNode node )
	{
		// The list to return the path in
		List<PathNode> path = new List<PathNode>();

		// Find all of the parents
		while( node != null )
		{
			// Add the current node to the path
			path.Add( node );

			// Change current node to it's parent
			node = node.Parent;
		}

		// Return the path
		return path;
	}
}