/// <summary>
/// Interface to allow damage to be taken.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
	/// <summary>
	/// Applies damage to object.
	/// </summary>
	void Damage ( float damage );
}
