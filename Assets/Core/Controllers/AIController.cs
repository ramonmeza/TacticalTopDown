/// <summary>
/// Dispatches AI input to the game object.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
	private CharacterMovementComponent m_CharacterMovementComponent;
	public GameObject Target;

	void Start()
	{
		// Get the CharacterMovementComponent from the character
		m_CharacterMovementComponent = 
			gameObject.GetComponent<CharacterMovementComponent>();

	}

	void Update()
	{
	}
}