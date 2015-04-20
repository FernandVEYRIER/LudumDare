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
			Invoke("StartClean", 2f);
			Invoke("ResetClean", 4f);
		}

	}

	void StartClean()
	{
		this.GetComponent<Animator>().enabled = true;
		this.GetComponent<Collider2D>().enabled = false;
		StartCoroutine(removeScout());
	}

	void ResetClean()
	{
		this.GetComponent<Animator>().enabled = false;
		this.GetComponent<Collider2D>().enabled = true;
		//Reload Video
	}

	IEnumerator removeScout()
	{
		GameObject scout = GameObject.FindGameObjectWithTag("Scout");
		yield return new WaitForSeconds(1);
        for (float i = 1; i >= 0; i -= 0.03f)
		{
			scout.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, i);
			yield return new WaitForSeconds(0.00001f);
		}
		yield return new WaitForSeconds(0.5f);
		if (GameObject.Find("Canvas") != null)
			GameObject.Find("Canvas").SetActive(false);
		GameObject.Find("PixelEffector").GetComponent<PixelEffector>().startTransition();
		yield return new WaitForSeconds(1.3f);
		Application.LoadLevel("CutScene");
	}
}
