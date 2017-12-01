/// <summary>
/// Display the FPS count on the top left corner of the screen
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
	private float deltaTime = 0.0f;

	public void Update()
	{
		deltaTime += ( Time.unscaledDeltaTime - deltaTime ) * 0.1f;
	}

	void OnGUI()
	{
		int width = Screen.width;
		int height = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect( 0, 0, width, height / 50.0f );
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = (int) Mathf.Floor( height / 20.0f );
		style.normal.textColor = Color.green;

		float ms = deltaTime * 1000.0f;
		float FPS = 1.0f / deltaTime;

		string text = string.Format( "{0:0.0} ms ({1:0.} fps)", ms, FPS );

		GUI.Label( rect, text, style );
	}
}