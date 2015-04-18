﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class obj
{
	public int index;
	public string name;
	public Sprite img;
	public int theIndex;
}

public class InventoryHandler : MonoBehaviour {
	public obj [] objects = new obj[3];
	public Image [] spritesObj;
	public Sprite emptySlot;
	public Image warningImage;
	[HideInInspector]
	public bool canBeDropped = false;
	public int index_drop = 0;
	obj oldObj = new obj();
	public static bool isDragged = false;
	
	void Start()
	{
		int i;
		for (i = 0; i < 3; i++)
		{
			objects[i].index = i;
			objects[i].name = "empty";
			objects[i].img = emptySlot;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
			removeObj(0);
	}

	public void addObject(obj _object)
	{
		oldObj.name = objects[_object.index].name;
		oldObj.img = objects[_object.index].img;
		objects[_object.index].name = _object.name;
		objects[_object.index].img = _object.img;
		spritesObj[_object.index].sprite = _object.img;
	}
	
	public void removeObj(int index)
	{
		objects[index].name = "empty";
		objects[index].img = emptySlot;
		spritesObj[index].sprite = emptySlot;
	}

	public void restoreObj(int index)
	{
		objects[index].name = oldObj.name;
		objects[index].img = oldObj.img;
		spritesObj[index].sprite = oldObj.img;
	}

	public int areSlotsEmpty()
	{
		int pos = 0;
		
		foreach (obj _object in objects)
		{
			if (_object.name == "empty")
			{
				return (pos);
			}
			++pos;
		}
		return (-1);
	}
	
	public void resetWarning()
	{
		warningImage.color = new Color(1, 0, 0, 0);
	}
	
	public IEnumerator fadeWarning()
	{
		for (;;)
		{
			for (float i = 1; i >= -0.1f; i -= 0.1f)
			{
				warningImage.color = new Color(0, 1, 1, i);
				yield return new WaitForSeconds(0.06f);
			}
			for (float i = 0; i <= 1.1f; i += 0.1f)
			{
				warningImage.color = new Color(0, 1, 1, i);
				yield return new WaitForSeconds(0.06f);
			}
		}
	}
	
	public void draggingIn(int index)
	{
		canBeDropped = true;
		index_drop = index;
	}
	
	public void draggingOut()
	{
		canBeDropped = false;
	}
}
