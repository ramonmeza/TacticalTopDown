/// <summary>
/// Handles vision for AI.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour
{
	public float Range = 10.0f;
	public int FieldOfView = 90;
	public int NumberOfRays = 10;

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

			// Rotate the point to in front of the character

			// Get the direction from the character to the point
			Vector3 heading = point - transform.position;
			float distance = heading.magnitude;
			Vector3 dir = heading / distance;


			Gizmos.DrawRay( transform.position, dir * Range );
		}
	}
}
