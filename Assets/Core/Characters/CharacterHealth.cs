/// <summary>
/// Controls the character's health.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamageable
{
	/// <summary>
	/// The max health.
	/// </summary>
	public float MaxHealth = 100.0f;

	/// <summary>
	/// The current health.
	/// </summary>
	private float CurrentHealth = 100.0f;

	void Start()
	{
		// Initialize health
		CurrentHealth = MaxHealth;
	}

	/// <summary>
	/// Applies damage to the health.
	/// </summary>
	public void Damage( float damage )
	{
		CurrentHealth -= damage;

		// Kill the character if they are dead
		if( IsDead() )
			Kill();
	}

	/// <summary>
	/// Determine whether dead or not.
	/// </summary>
	/// <returns><c>true</c> if is dead</returns>
	public bool IsDead()
	{
		// If health is below 0
		if( CurrentHealth <= 0.0f )
			return true;

		// Health is above 0
		return false;
	}

	/// <summary>
	/// Kills the character.
	/// </summary>
	public void Kill()
	{
		// Temporary
		Destroy( gameObject );
	}
}