using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]

public class Drag : MonoBehaviour {

	public obj thisObj = new obj();
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 originalPos;
	private Vector3 refVel;
	bool selfDragged = false;

	void Start()
	{
		InventoryHandler.isDragged = false;
		originalPos = this.transform.position;
	}

	void OnMouseDown()
	{
		InventoryHandler.isDragged = true;
		selfDragged = true;
		GameObject.Find("Inventory").GetComponent<InventoryHandler>().StartCoroutine("fadeWarning");
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseUp()
	{
		InventoryHandler inventory = GameObject.Find("Inventory").GetComponent<InventoryHandler>();
		InventoryHandler.isDragged = false;
		selfDragged = false;
		inventory.StopAllCoroutines();
		inventory.resetWarning();
		thisObj.index = inventory.index_drop;
		if (inventory.canBeDropped)
		{
			inventory.addObject(thisObj);
			GameObject.Find("Spawn_info").GetComponent<bounce_info>().create_info_bulle(this.GetComponent<SpriteRenderer>().sprite);
		}
	}

	void Update()
	{
		if (selfDragged == false)
		{
			this.transform.position = Vector3.SmoothDamp(this.transform.position, originalPos, ref refVel, 0.4f);
			return;
		}
		Vector3 worldCoorMin = Camera.main.ScreenToWorldPoint(new Vector3 (0, 0, 0));
		Vector3 worldCoorMax = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width, Screen.height, 0));
		this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, worldCoorMin.x, worldCoorMax.x),
		                                      Mathf.Clamp(this.transform.position.y, worldCoorMin.y, worldCoorMax.y), 0);
	}

	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);// + offset;
		//transform.position = curPosition;
		transform.position = Vector3.SmoothDamp(transform.position, curPosition, ref refVel, 0.1f);
	}

	public void SendImage()
	{
		InventoryHandler inventory = GameObject.Find("Inventory").GetComponent<InventoryHandler>();
		if (!selfDragged)
			return;
		this.GetComponent<SpriteRenderer>().enabled = false;
		thisObj.index = inventory.index_drop;
		inventory.addObject(thisObj);
	}

	public void DeleteImage()
	{
		InventoryHandler inventory = GameObject.Find("Inventory").GetComponent<InventoryHandler>();
		if (!selfDragged)
			return;
		this.GetComponent<SpriteRenderer>().enabled = true;
		inventory.restoreObj(thisObj.index);
	}
}