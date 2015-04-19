using UnityEngine;
using System.Collections;

public class stop_mamie : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
			col.GetComponent<ChangeRoom> ().DontMove ();
		}
	}
}
