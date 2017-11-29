/// <summary>
/// Controls movement for a character.
/// </summary>
/// 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementComponent : MonoBehaviour
{
	/// <summary>
	/// Speed that the character will move at
	/// </summary>
	public float Speed = 10.0f;

	/// <summary>
	/// Moves the game object toward world up vector.
	/// </summary>
	/// <param name="value">Factor to move the game object by. 
	/// If negative, the game object will move world down.</param>
	public void MoveUp(float value)
	{
		transform.position += Vector3.up * value * Speed * Time.deltaTime;
	}

	/// <summary>
	/// Moves the game object toward world right vector.
	/// </summary>
	/// <param name="value">Factor to move the game object by. 
	/// If negative, the game object will move world left.</param>
	public void MoveRight(float value)
	{
		transform.position += Vector3.right * value * Speed * Time.deltaTime;
	}
}
