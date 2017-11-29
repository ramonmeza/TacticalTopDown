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
	void HandleInput()
	{
		MoveUp( Input.GetAxisRaw( "MoveUp" ) );
		MoveRight( Input.GetAxisRaw( "MoveRight" ) );
	}

	/// <summary>
	/// Moves the player's character up/down using it's 
	/// CharacterMovementComponent.
	/// </summary>
	void MoveUp( float value )
	{	
		// Check to see if there is a CharacterMovementComponent to use
		if( m_CharacterMovementComponent != null )
			m_CharacterMovementComponent.MoveUp( value );
	}

	/// <summary>
	/// Moves the player's character right/left using it's 
	/// CharacterMovementComponent.
	/// </summary>
	void MoveRight( float value )
	{
		// Check to see if there is a CharacterMovementComponent to use
		if( m_CharacterMovementComponent != null )
			m_CharacterMovementComponent.MoveRight( value );
	}
}