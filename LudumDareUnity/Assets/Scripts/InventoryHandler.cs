using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class obj
{
	public int index;
	public string name;
	public Sprite img;
}

public class InventoryHandler : MonoBehaviour {
	public obj [] objects = new obj[3];
	public Image [] spritesObj;
	public Sprite emptySlot;
	public Image warningImage;
	[HideInInspector]
	public bool canBeDropped = false;
	public int index_drop = 0;

//	[System.Serializable]
//	public class obj
//	{
//		public int index;
//		public string name;
//		public Sprite img;
//	}

	void Start()
	{
		int i;
		for (i = 0; i < 3; i++)
		{
			//objects[i].index = i;
			objects[i].name = "empty";
			objects[i].img = emptySlot;
		}
	}

	public void addObject(obj _object)
	{
		int emptySlot = areSlotsEmpty();
		Debug.Log(emptySlot);
		if (emptySlot != -1)
		{
			//_object.index = emptySlot;
			objects[emptySlot] = _object;
			spritesObj[emptySlot].sprite = _object.img;
		}
		else
		{
			StartCoroutine(fadeWarning());
		}
	}

	public void removeObj(int index)
	{
		objects[index].name = "empty";
		objects[index].img = emptySlot;
		spritesObj[index].sprite = emptySlot;
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
				warningImage.color = new Color(1, 0, 0, i);
				yield return new WaitForSeconds(0.06f);
			}
			for (float i = 0; i <= 1.1f; i += 0.1f)
			{
				warningImage.color = new Color(1, 0, 0, i);
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
