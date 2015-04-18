using UnityEngine;
using System.Collections;

public class Change_cursor : MonoBehaviour {

	public Texture2D texture;
	void OnMouseEnter()
	{
		Cursor.SetCursor (texture, Vector2.zero, CursorMode.Auto);
	}
	void OnMouseExit()
	{
		Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
}
