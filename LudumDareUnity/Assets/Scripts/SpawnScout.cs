﻿using UnityEngine;
using System.Collections;

public class SpawnScout : MonoBehaviour {

	public GameObject [] scoutPrefab;

	void Start () 
	{
		GameObject go;
		int rnd;
		go = (GameObject) Instantiate(scoutPrefab[rnd = Random.Range(0, scoutPrefab.Length)], this.transform.position, Quaternion.identity);
		if (rnd == 1)
			go.transform.position += new Vector3(0, 1, 0);
	}
}
