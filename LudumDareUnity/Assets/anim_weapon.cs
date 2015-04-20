using UnityEngine;
using System.Collections;

public class anim_weapon : MonoBehaviour {

	// Use this for initialization
	void Update ()
	{
		this.GetComponent<Animator>().SetBool("move", GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("move"));
	}
}
