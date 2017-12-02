/// <summary>
/// Make the camera it is placed on follow a specified target.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
	/// <summary>
	/// The target object to follow
	/// </summary>
	public GameObject Target;

	/// <summary>
	/// Amount of lag the camera has when following the target
	/// </summary>
	public float FollowLag = 0.05f;

	/// <summary>
	/// The camera component
	/// </summary>
	private Camera m_CameraComponent;

	void Start ()
	{
		// Initialize the camera component
		m_CameraComponent = GetComponent<Camera>();
	}

	void Update ()
	{
		if( Target != null )
		{
			// Get the target's position relative to the screen
			Vector3 targetPos = 
				m_CameraComponent
					.WorldToViewportPoint( Target.transform.position );

			// If the target is off horizontally
			if( targetPos.x != 0.5f )
			{
				// Get lerp between camera position and target position
				float x = Mathf.Lerp( transform.position.x, 
				                     Target.transform.position.x, 
				                     FollowLag );

				// Set the new camera position
				transform.position = new Vector3( x, 
				                                 transform.position.y, 
				                                 transform.position.z );
			}

			// If the target is off horizontally
			if( targetPos.x != 0.5f )
			{
				// Get lerp between camera position and target position
				float y = Mathf.Lerp( transform.position.y, 
				                     Target.transform.position.y, 
				                     FollowLag );

				// Set the new camera position
				transform.position = new Vector3( transform.position.x,
				                                 y,
				                                 transform.position.z );
			}
		}
	}
}