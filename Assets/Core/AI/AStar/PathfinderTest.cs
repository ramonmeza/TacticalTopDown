/// <summary>
/// A test for the Pathfinder class
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderTest : MonoBehaviour
{
	public PathNode StartNode;
	public PathNode TargetNode;

	public List<PathNode> FoundPath = new List<PathNode>();
	public Pathfinder PathfinderComponent;

	void Start ()
	{
		if(StartNode != null && 
			TargetNode != null && 
			PathfinderComponent != null)
		{
			FoundPath = PathfinderComponent
				.FindShortestPath( StartNode, TargetNode );
		}
	}
}
