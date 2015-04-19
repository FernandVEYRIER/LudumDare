using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Atelier : MonoBehaviour {
	[System.Serializable]
	public class tab
	{
		public int[] index = new int[3];
	}
	public tab[] craft = new tab[1];
	public Color flash_color;
	private bool fl = false;
	private InventoryHandler inv;
	void Start()
	{
		inv = GameObject.Find ("Inventory").GetComponent<InventoryHandler> ();
	}
	void OnMouseEnter()
	{
		if (!fl)
		{
			fl = true;
			StartCoroutine ("flash");
		}
	}
	void OnMouseExit()
	{
		if (fl) {
			fl = false;
		}
	}
	void OnMouseDown()
	{
		int[] tmp = new int[3];
		tmp [0] = inv.objects [0].theIndex;
		tmp [1] = inv.objects [1].theIndex;
		tmp [2] = inv.objects [2].theIndex;
		Array.Sort (tmp);
		print(tmp[0]);
		print(tmp[1]);
		print(tmp[2]);
		foreach (tab elem in craft)
		{
			int i = 0;
			while (i < 3 && tmp[i] == elem.index[i])
				i++;
			if (i == 3)
				print("succes!");
		}
		print ("fail");
	}
	IEnumerator flash()
	{

		while (fl) 
		{
			this.GetComponent<SpriteRenderer>().color = flash_color;
			yield return new WaitForSeconds(0.2f);
			this.GetComponent<SpriteRenderer>().color = Color.white;
			yield return new WaitForSeconds(0.2f);
		}
	}
}
