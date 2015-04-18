using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour {

	public static bool isDragged = false;
	private Vector3 screenPoint;
	private Vector3 offset;
	
	void OnMouseDown() 
	{
		isDragged = true;
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseUp()
	{
		isDragged = false;
	}

	void Update()
	{
		Vector3 worldCoorMin = Camera.main.ScreenToWorldPoint(new Vector3 (0, 0, 0));
		Vector3 worldCoorMax = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, worldCoorMin.x, worldCoorMax.x),
		                                      Mathf.Clamp(this.transform.position.y, worldCoorMin.y, worldCoorMax.y), 0);
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
	}
}