using UnityEngine;
using System.Collections;

public class destruct_egg : MonoBehaviour {

	public GameObject destroy_ouef;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D col)
	{
		Instantiate (destroy_ouef, transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
