/// <summary>
/// Handles vision for AI.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour
{
	/// <summary>
	/// The range that the vision can see.
	/// </summary>
	public float Range = 10.0f;

	/// <summary>
	/// The field of view.
	/// </summary>
	public int FieldOfView = 90;

	/// <summary>
	/// Number of rays to be cast.
	/// </summary>
	public int NumberOfRays = 10;

	/// <summary>
	/// The layer mask that will cause alert.
	/// </summary>
	public LayerMask Alert;

	/// <summary>
	/// Whether an object with layer mask of alert layer mask has been seen.
	/// </summary>
	private bool m_IsAlert = false;

	void Update ()
	{
		// Create a cone the width of the field of view with NumberOfRays rays
		for( int i = 0 - ( FieldOfView / 2 );
		     i < ( FieldOfView / 2 );
		     i += ( FieldOfView / NumberOfRays ) )
		{
			// Find the point along a circle that represents the vision
			Vector3 pt = new Vector3( 0.0f, 0.0f, 0.0f );
			pt.x = Mathf.Cos( ( i + transform.eulerAngles.z ) * Mathf.Deg2Rad );
			pt.y = Mathf.Sin( ( i + transform.eulerAngles.z ) * Mathf.Deg2Rad );

			// Move the point to the range
			pt *= Range;
			pt += transform.position;

			// Get the direction between the origin and the point
			Vector3 heading = pt - transform.position;
			float dist = heading.magnitude;
			Vector3 dir = heading / dist;

			// Shoot the ray
			RaycastHit2D hit = 
				Physics2D.Raycast( transform.position,
				                  dir,
				                  Range,
				                  Alert );

			// Test if hit something
			if( hit.collider != null )
			{
				m_IsAlert = true;
			}
			else
			{
				m_IsAlert = false;
			}
		}
	}

	void OnDrawGizmos ()
	{
		for( int i = 0 - ( FieldOfView / 2 ); 
		    i < ( FieldOfView / 2 ); 
		    i += ( FieldOfView / NumberOfRays ) )
		{
			// Find the point along a circle that represents the vision
			Vector3 point = new Vector3( 0, 0, 0 );
			point.x = Mathf.Cos( ( i + transform.eulerAngles.z ) * Mathf.Deg2Rad );
			point.y = Mathf.Sin( ( i + transform.eulerAngles.z ) * Mathf.Deg2Rad );

			point *= Range;
			point += transform.position;

			// Get the direction from the character to the point
			Vector3 heading = point - transform.position;
			float distance = heading.magnitude;
			Vector3 dir = heading / distance;


			Gizmos.DrawRay( transform.position, dir * Range );
		}
	}
}
