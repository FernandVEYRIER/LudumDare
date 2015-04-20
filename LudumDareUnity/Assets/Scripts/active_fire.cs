using UnityEngine;
using System.Collections;

public class active_fire : MonoBehaviour {

	private bool play_one = false;
	// Update is called once per frame
	void Awake()
	{
		this.GetComponent<ParticleSystem> ().Stop();
	}
	void Update ()
	{
		if (!play_one && this.GetComponentInParent<Animator> ().GetInteger ("anim") == 3)
			StartCoroutine (play ());
	}
	IEnumerator play()
	{
		play_one = true;
		this.GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (1.5f);
		this.GetComponent<ParticleSystem> ().Stop();
	}
}
