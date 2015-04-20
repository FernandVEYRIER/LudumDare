using UnityEngine;
using System.Collections;

public class SpawnScout : MonoBehaviour {

	public GameObject [] scoutPrefab;

	void Start () 
	{
		Instantiate(scoutPrefab[Random.Range(0, scoutPrefab.Length)], this.transform.position, Quaternion.identity);
	}
}
