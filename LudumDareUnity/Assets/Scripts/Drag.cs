using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour {

	public obj thisObj;
	public static bool isDragged = false;
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 originalPos;
	private Vector3 refVel;

	void Start()
	{
		originalPos = this.transform.position;
	}

	void OnMouseDown()
	{
		isDragged = true;
		GameObject.Find("Inventory").GetComponent<InventoryHandler>().StartCoroutine("fadeWarning");
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseUp()
	{
		InventoryHandler inventory = GameObject.Find("Inventory").GetComponent<InventoryHandler>();
		isDragged = false;
		inventory.StopAllCoroutines();
		inventory.resetWarning();
		if (inventory.canBeDropped)
			inventory.addObject(thisObj);
	}

	void Update()
	{
		if (isDragged == false)
		{
			this.transform.position = Vector3.SmoothDamp(this.transform.position, originalPos, ref refVel, 0.4f);
		}
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