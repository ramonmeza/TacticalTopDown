/// <summary>
/// Decision tree.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTree : MonoBehaviour 
{
	/// <summary>
	/// The root node to the tree.
	/// </summary>
	private DecisionTreeNode m_Root;

	/// <summary>
	/// Gets the root.
	/// </summary>
	public DecisionTreeNode GetRoot()
	{
		return m_Root;
	}
}