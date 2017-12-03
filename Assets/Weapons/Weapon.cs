/// <summary>
/// Weapon.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Weapon : MonoBehaviour
{
	/// <summary>
	/// Whether the weapon is automatic or not.
	/// </summary>
	public bool IsAutomatic = false;

	/// <summary>
	/// Used to support single fire mode. True means you can shoot.
	/// </summary>
	private bool m_ShootOnce = true;

	/// <summary>
	/// The fire rate of the weapon in seconds.
	/// </summary>
	public float FireRate = 0.2f;

	/// <summary>
	/// A timer to keep track of when to shoot.
	/// </summary>
	private float m_FireRateTimer = 0.0f;

	/// <summary>
	/// The reload time.
	/// </summary>
	public float ReloadTime = 1.0f;

	/// <summary>
	/// Whether or not the weapon is currently reloading.
	/// </summary>
	private bool m_IsReloading = false;

	/// <summary>
	/// The range of the weapon.
	/// </summary>
	public float Range = 10.0f;

	/// <summary>
	/// The amount of damage the weapon does.
	/// </summary>
	public float Damage = 10.0f;

	/// <summary>
	/// The number of magazines.
	/// </summary>
	public int NumberOfMagazines = 4;

	/// <summary>
	/// The bullets per magazine.
	/// </summary>
	public int BulletsPerMagazine = 10;

	/// <summary>
	/// List of magazines the weapon has.
	/// </summary>
	public List<Magazine> Magazines = new List<Magazine>();

	/// <summary>
	/// The current magazine.
	/// </summary>
	public Magazine CurrentMagazine = null;

	void Start ()
	{
		// Add magazines to magazine list
		for( int i = 0; i < NumberOfMagazines; i++ )
		{
			Magazines.Add( new Magazine() );
			Magazines.Last().AmmoLeft = BulletsPerMagazine;
		}

		// Set the current magazine
		CurrentMagazine = Magazines.First();
	}

	void Update ()
	{
		// Update fire rate timer
		if( IsAutomatic )
			m_FireRateTimer += Time.deltaTime;
	}

	/// <summary>
	/// Starts the shooting.
	/// </summary>
	public void StartShooting ()
	{
		// If the weapon is not reloading
		if( !m_IsReloading )
		{
			// If it is single shot
			if( m_ShootOnce )
			{
				// Switch off single fire mode
				m_ShootOnce = false;

				// Reset fire rate timer
				m_FireRateTimer = 0.0f;

				// Shoot
				Shoot();
			}
			else if( IsAutomatic && m_FireRateTimer >= FireRate )
			{
				// Reset fire rate timer
				m_FireRateTimer = 0.0f;

				// Shoot
				Shoot();
			}
		}
	}
		
	/// <summary>
	/// Shoots a bullet out.
	/// </summary>
	public void Shoot ()
	{
		// If the current magazine can give ammo
		if( CurrentMagazine.GiveAmmo() )
		{
			Debug.Log( "Shoot!" );

			// Raycast to ignore current object's layer
			int layerMask = 1 << gameObject.layer;
			layerMask = ~layerMask;

			// Shoot the bullet
			RaycastHit2D hit = Physics2D.Raycast( transform.position,
			                                      transform.right,
			                                      Range,
			                                      layerMask );

			// If hit something
			if( hit.collider != null )
			{
				// Get the hit object's damageable interface
				IDamageable obj = hit.collider.GetComponent<IDamageable>();

				// Damage object if it implements IDamageable interface
				if( obj != null )
				{
					obj.Damage( Damage );
				}
			}
		}
		else
		{
			Debug.Log( "Empty!" );

			// Stop shooting if empty
			// StopShooting();
		}
	}

	/// <summary>
	/// Stops the shooting.
	/// </summary>
	public void StopShooting ()
	{
		// Reset the single fire mode
		m_ShootOnce = true;

		// Reset fire rate timer
		m_FireRateTimer = 0.0f;
	}

	/// <summary>
	/// Reloads the weapon.
	/// </summary>
	public void Reload()
	{
		// If not already reloading
		if( !m_IsReloading )
		{
			// Set is reloading to true
			m_IsReloading = true;

			// Set current magazine to the next one in the list
			CurrentMagazine = 
				Magazines[ ( Magazines.IndexOf( CurrentMagazine ) + 1 ) % 
				          		Magazines.Count ];

			// Stop reloading after the reload time is completed
			Invoke( "StopReloading", ReloadTime );
		}
	}

	/// <summary>
	/// Stops reloading.
	/// </summary>
	private void StopReloading()
	{
		// Set is reloading to false
		m_IsReloading = false;
	}
}