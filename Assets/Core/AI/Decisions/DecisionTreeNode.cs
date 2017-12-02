/// <summary>
/// An abstract base class for the nodes of a decision tree.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DecisionTreeNode : MonoBehaviour
{
	/// <summary>
	/// The left hand side leaf
	/// </summary>
	protected DecisionTreeNode LHS = null;

	/// <summary>
	/// The right hand side left
	/// </summary>
	protected DecisionTreeNode RHS = null;

	/// <summary>
	/// Gets the LHS leaf.
	/// </summary>
	public DecisionTreeNode GetLHS()
	{
		return LHS;
	}

	/// <summary>
	/// Gets the RHS leaf.
	/// </summary>
	public DecisionTreeNode GetRHS()
	{
		return RHS;
	}
}