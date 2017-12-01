/// <summary>
/// A* pathfinding algorithm implementation.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pathfinder : MonoBehaviour
{
	/// <summary>
	/// List of all nodes that define a single path
	/// </summary>
	public List<PathNode> Grid;

	/// <summary>
	/// Dictionary of all of the connection costs
	/// </summary>
	private Dictionary<KeyValuePair<PathNode, PathNode>, float> m_Connections =
		new Dictionary<KeyValuePair<PathNode, PathNode>, float>();

	void Start()
	{
		// Precalculate all costs between connections
		foreach( PathNode node in Grid )
		{
			foreach( PathNode connected in node.ConnectedNodes )
			{
				AddConnection( node, connected );
			}
		}
	}

	/// <summary>
	/// Finds the best path.
	/// </summary>
	/// <param name="startNode">Start node.</param>
	/// <param name="targetNode">Target node.</param>
	public List<PathNode> FindBestPath(
		PathNode startNode, 
		PathNode targetNode )
	{
		
		List<PathNode> BestPath = new List<PathNode>();
		BestPath.Add( startNode );

		PathNode currentNode = startNode;

		KeyValuePair<PathNode, float> BestNode = 
			new KeyValuePair<PathNode, float>( null, Mathf.Infinity );

		while( currentNode != targetNode )
		{
			foreach( PathNode connected in currentNode.ConnectedNodes )
			{
				// Skip iteration if the node is already on the best path
				if( BestPath.Contains( connected ) )
					continue;

				// If the connected node is the target node
				if( connected == targetNode )
				{
					BestPath.Add( connected );
					return BestPath;
				}

				/* 
				 * Calculate the scores
				 * F = G + H
				 * G = Path cost SO FAR
				 * H = Estimated cost from node to goal
				*/
				float G = GetConnectionCost( currentNode, connected );
				float H = StraightLineDistance( connected, targetNode );
				float F = G + H;

				// If this node is better than the best node
				if( BestNode.Key == null || F < BestNode.Value )
					BestNode = 
						new KeyValuePair<PathNode, float>( connected, F );
			}

			// Add best node to the path
			Debug.Log(BestNode.Key);
			BestPath.Add( BestNode.Key );

			// Increment currentNode
			currentNode = BestPath.Last();
		}

		return null;
	}

	/// <summary>
	/// Finds the straight line distance between two PathNodes
	/// </summary>
	/// <param name="startNode">Start node.</param>
	/// <param name="targetNode">Target node.</param>
	private float StraightLineDistance( 
		PathNode startNode, 
		PathNode targetNode )
	{
		return Vector3.Distance( 
			startNode.transform.position, 
			targetNode.transform.position );
	}

	/// <summary>
	/// Check if the connection is already in the hashtable
	/// </summary>
	private bool CheckConnectionKey( PathNode a, PathNode b )
	{
		// Check the two differenct connections keys
		KeyValuePair<PathNode, PathNode> ab = 
			new KeyValuePair<PathNode, PathNode>( a, b );
		KeyValuePair<PathNode, PathNode> ba = 
			new KeyValuePair<PathNode, PathNode>( b, a );

		// If the connection key exists already
		if( m_Connections.ContainsKey( ab ) || m_Connections.ContainsKey( ba ) )
			return true;

		// No key for this connection
		return false;
	}

	/// <summary>
	/// Gets the connection key between a and b.
	/// </summary>
	private KeyValuePair<PathNode, PathNode> GetConnectionKey( PathNode a, 
	                                                           PathNode b )
	{
		// Check the two differenct connections keys
		KeyValuePair<PathNode, PathNode> ab = 
			new KeyValuePair<PathNode, PathNode>( a, b );
		KeyValuePair<PathNode, PathNode> ba = 
			new KeyValuePair<PathNode, PathNode>( b, a );

		if( m_Connections.ContainsKey( ab ) )
			return ab;
		else if( m_Connections.ContainsKey( ba ) )
			return ba;
		
		// No key for this connection
		return new KeyValuePair<PathNode, PathNode>( null, null );
	}

	/// <summary>
	/// Add a connection if it exists
	/// </summary>
	private void AddConnection( PathNode a, PathNode b )
	{
		// If there is no connection between a and b
		if( !a.ConnectedNodes.Contains( b ) && !b.ConnectedNodes.Contains( a ) )
			return;

		// Check if the connection isn't already accounted for
		if( !CheckConnectionKey( a, b ) )
		{
			float value = StraightLineDistance( a, b );

			// Add connection
			KeyValuePair<PathNode, PathNode> key =
				new KeyValuePair<PathNode, PathNode>( a, b );
			m_Connections.Add( key, value );
		}
	}

	/// <summary>
	/// Gets the connection cost between node a and b.
	/// </summary>
	private float GetConnectionCost( PathNode a, PathNode b )
	{
		if( CheckConnectionKey( a, b ) )
			return m_Connections[ GetConnectionKey( a, b ) ];

		return Mathf.Infinity;
	}
}