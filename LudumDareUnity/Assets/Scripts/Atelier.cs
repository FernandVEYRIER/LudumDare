﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Atelier : MonoBehaviour {
	[System.Serializable]
	public class tab
	{
		public int[] index = new int[3];
	}
	public Sprite valid;
	public Sprite erreur;
	public tab[] craft = new tab[1];
	public Color flash_color;
	private bool fl = false;
	private InventoryHandler inv;
	private bool gocraft = false;
	[HideInInspector]
	public bool click = false;
	void Start()
	{
		inv = GameObject.Find ("Inventory").GetComponent<InventoryHandler> ();
	}
	void Update()
	{
		if (click && !gocraft && Math.Abs (transform.position.x - GameObject.FindGameObjectWithTag ("Player").transform.position.x) <= 0.1f && (GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom>().moveRight || GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom>().moveLeft))
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom>().DontMove();
			StartCoroutine (wait ());
		}
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator>().GetBool("action"))
			GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom>().DontMove();
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
		click = true;
		bool plop = false;
		if (!GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().transition && Math.Abs(transform.position.x - GameObject.FindGameObjectWithTag ("Player").transform.position.x) > 0.1f)
		{
			if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ().position.x < transform.position.x)
				GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveRight ();
			else
				GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveLeft ();
		}
		else if (!gocraft)
			StartCoroutine (wait ());
		int[] tmp = new int[3];
		tmp [0] = inv.objects [0].theIndex;
		tmp [1] = inv.objects [1].theIndex;
		tmp [2] = inv.objects [2].theIndex;
		Array.Sort (tmp);
		foreach (tab elem in craft)
		{
			int i = 0;
			while (i < 3 && tmp[i] == elem.index[i])
				i++;
			if (i == 3)
				plop = true;
		}
		StartCoroutine (wait_v(plop));
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
	IEnumerator wait()
	{
		gocraft = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ().SetBool ("action", true);
		yield return new WaitForSeconds(2f);
		GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator> ().SetBool ("action", false);
		gocraft = false;
	}
	IEnumerator wait_v(bool plop)
	{
		yield return new WaitForSeconds(2f);
		if (!plop)
			GameObject.Find("Spawn_info").GetComponent<bubble_inf>().show(erreur);
		else
			GameObject.Find("Spawn_info").GetComponent<bubble_inf>().show(valid);
	}
}
