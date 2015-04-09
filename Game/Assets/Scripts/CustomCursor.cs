using UnityEngine;
using System.Collections;

public class CustomCursor : MonoBehaviour {

	public  Texture cursorImage;

	void Start()
	{
		Cursor.visible = false;
	}

	void Update()
	{

	}

	void OnGUI()
	{
		Vector3 mousePos = Input.mousePosition;
		Rect pos = new Rect(mousePos.x, Screen.height - mousePos.y, cursorImage.width, cursorImage.height);
		GUI.Label (pos, cursorImage);
	}

}
