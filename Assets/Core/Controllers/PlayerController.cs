/// <summary>
/// Dispatches player controller input to the game object.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private CharacterMovementComponent m_CharacterMovementComponent;

	void Start()
	{
		// Get the CharacterMovementComponent from the character
		m_CharacterMovementComponent = 
			gameObject.GetComponent<CharacterMovementComponent>();
	}

	void Update()
	{
		HandleInput();
	}

	/// <summary>
	/// Handles the input events from the player.
	/// </summary>
	private void HandleInput()
	{
		MoveUp( Input.GetAxisRaw( "MoveUp" ) );
		MoveRight( Input.GetAxisRaw( "MoveRight" ) );

		// Rotate to mouse
		AimAt( Camera.main.ScreenToWorldPoint( Input.mousePosition ) );
	}

	/// <summary>
	/// Moves the player's character up/down using it's 
	/// CharacterMovementComponent.
	/// </summary>
	private void MoveUp( float value )
	{	
		// Check to see if there is a CharacterMovementComponent to use
		if( m_CharacterMovementComponent != null )
			m_CharacterMovementComponent.MoveUp( value );
	}

	/// <summary>
	/// Moves the player's character right/left using it's 
	/// CharacterMovementComponent.
	/// </summary>
	private void MoveRight( float value )
	{
		// Check to see if there is a CharacterMovementComponent to use
		if( m_CharacterMovementComponent != null )
			m_CharacterMovementComponent.MoveRight( value );
	}

	/// <summary>
	/// Aims the player at the specified target using it's 
	/// CharacterMovementComponent
	/// </summary>
	private void AimAt( Vector3 target )
	{
		m_CharacterMovementComponent.AimAt( target );
	}
}