using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour {
	[HideInInspector]
	public obj [] objects = new obj[3];
	public Image [] spritesObj;
	public Sprite emptySlot;
	public Image warningImage;

	[System.Serializable]
	public class obj
	{
		public int index;
		public string name;
		public Sprite img;
	}

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

	public void addObject(obj _object)
	{
		int emptySlot = areSlotsEmpty();

		if (emptySlot != -1)
		{
			_object.index = emptySlot;
			objects[emptySlot] = _object;
			spritesObj[emptySlot].sprite = _object.img;
		}
		else
		{
			warningImage.color = new Color(1, 0, 0);
		}
	}

	public void removeObj(int index)
	{
		objects[index].name = "empty";
		objects[index].img = emptySlot;
		spritesObj[index].sprite = emptySlot;
	}

	int areSlotsEmpty()
	{
		int pos = 0;

		foreach (obj _object in objects)
		{
			if (_object.name != "empty")
			{
				return (-1);
			}
			++pos;
		}
		return (pos);
	}
}
