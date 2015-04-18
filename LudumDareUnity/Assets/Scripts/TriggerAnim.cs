using UnityEngine;
using System.Collections;

public class TriggerAnim : MonoBehaviour {

	public string roomToGo = "none";

	void OnTriggerEnter2D(Collider2D col)
	{
		Camera.main.GetComponent<FadeTransition>().StartCoroutine("Fade", roomToGo);
	}
}
