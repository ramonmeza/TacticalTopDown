/// <summary>
/// Magazine.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Magazine
{
	/// <summary>
	/// The ammo left.
	/// </summary>
	public int AmmoLeft = 10;

	/// <summary>
	/// Determines whether this instance is empty.
	/// </summary>
	/// <returns><c>true</c> if magazine is empty</returns>
	public bool IsEmpty()
	{
		if( AmmoLeft > 0 )
			return false;

		return true;
	}

	/// <summary>
	/// Gives the ammo.
	/// </summary>
	/// <returns>The ammo.</returns>
	public bool GiveAmmo()
	{
		// If there is no ammo left
		if( IsEmpty() )
			return false;

		// Decrement ammo left
		AmmoLeft--;
		return true;
	}
}
