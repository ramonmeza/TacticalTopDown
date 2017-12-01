using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderTest : MonoBehaviour
{
	public Pathfinder PathFinderComponent;
	public PathNode startNode;
	public PathNode targetNode;

	public List<PathNode> BestPath = new List<PathNode>();

	void Start ()
	{
		BestPath = PathFinderComponent.FindBestPath( startNode, targetNode );
	}
}
