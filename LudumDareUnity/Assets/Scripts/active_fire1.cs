using UnityEngine;
using System.Collections;

public class active_fire1 : MonoBehaviour {

	// Use this for initialization
	private bool play_one = false;
	IEnumerator play()
	{
		play_one = true;
		this.GetComponent<ParticleRenderer> ().enabled = true;
		this.transform.GetChild(0).GetComponent<ParticleRenderer> ().enabled = true;
		yield return new WaitForSeconds (2);
		this.GetComponent<ParticleRenderer> ().enabled = false;
		this.transform.GetChild(0).GetComponent<ParticleRenderer> ().enabled = false;
	}
	// Update is called once per frame
	void Update () {
		if (!play_one && GameObject.Find("scout2").GetComponent<Animator> ().GetInteger ("anim") == 3)
			StartCoroutine (play ());
	}
}
