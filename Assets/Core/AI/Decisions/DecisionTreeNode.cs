/// <summary>
/// An abstract base class for the nodes of a decision tree.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class DecisionTreeNode : MonoBehaviour
{
	/// <summary>
	/// The left hand side child.
	/// </summary>
	protected DecisionTreeNode m_LHS = null;

	/// <summary>
	/// The right hand side child.
	/// </summary>
	protected DecisionTreeNode m_RHS = null;

	/// <summary>
	/// Gets the LHS child.
	/// </summary>
	public DecisionTreeNode GetLHS()
	{
		return m_LHS;
	}

	/// <summary>
	/// Gets the RHS child.
	/// </summary>
	public DecisionTreeNode GetRHS()
	{
		return m_RHS;
	}

	/// <summary>
	/// Adds a node to the LHS.
	/// </summary>
	public void AddLHS( DecisionTreeNode node )
	{
		m_LHS = node;
	}

	/// <summary>
	/// Adds a node to the RHS.
	/// </summary>
	public void AddRHS( DecisionTreeNode node )
	{
		m_RHS = node;
	}
}