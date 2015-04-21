using UnityEngine;
using System.Collections;

public class spawn_egg : MonoBehaviour {

	public float time = 0.5f;
	public GameObject projectile;
	private int count = 0;
	private bool activate = false;
	// Update is called once per frame
	void Update () 
	{
		print (GameObject.FindGameObjectWithTag ("Scout").GetComponent<Animator> ().GetInteger ("anim"));
		if (activate = false && count < 3 && GameObject.FindGameObjectWithTag ("Scout").GetComponent<Animator> ().GetInteger ("anim") == 2)
			StartCoroutine (fire());
	}
	IEnumerator fire()
	{
		GameObject tmp;
		count++;
		activate = true;
		tmp = (GameObject)Instantiate (projectile, transform.position, transform.rotation);
		print ("plop");
		tmp.transform.Translate (-1.5f, 0, 0);
		yield return new WaitForSeconds (time);
		activate = false;
	}
}
