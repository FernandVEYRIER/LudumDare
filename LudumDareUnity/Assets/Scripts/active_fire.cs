using UnityEngine;
using System.Collections;

public class active_fire : MonoBehaviour {

	private bool play_one = false;
	// Update is called once per frame
	void Update ()
	{
		if (!play_one && this.GetComponentInParent<Animator> ().GetInteger ("anim") == 3)
			StartCoroutine (play ());
	}
	IEnumerator play()
	{
		play_one = true;
		this.GetComponent<ParticleRenderer> ().enabled = true;
		this.transform.GetChild(0).GetComponent<ParticleRenderer> ().enabled = true;
		yield return new WaitForSeconds (2);
		this.GetComponent<ParticleRenderer> ().enabled = false;
		this.transform.GetChild(0).GetComponent<ParticleRenderer> ().enabled = false;
	}
}
