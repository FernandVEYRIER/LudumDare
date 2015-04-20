using UnityEngine;
using System.Collections;

public class CleanScene : MonoBehaviour {

	GameObject scout = null;
	bool animPlaying = false;

	void Start () 
	{
		animPlaying = false;
		this.GetComponent<Animator>().enabled = false;
		scout = GameObject.FindGameObjectWithTag("Scout");
	}
	
	void Update () 
	{
		if (scout == null)
		{
			scout = GameObject.FindGameObjectWithTag("Scout");
			return;
		}
		if (!animPlaying && scout.GetComponent<Animator>().GetInteger("anim") != 0)
		{
			animPlaying = true;
			this.GetComponent<Animator>().enabled = true;
			this.GetComponent<Collider2D>().enabled = false;
			Invoke("ResetClean", 2f);
		}

	}

	void ResetClean()
	{
		this.GetComponent<Animator>().enabled = false;
		this.GetComponent<Collider2D>().enabled = true;
		//Reload Video
	}
}
