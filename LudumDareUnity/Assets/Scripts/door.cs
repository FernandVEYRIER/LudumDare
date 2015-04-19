using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	public GameObject exit;
	public string roomToGo = "none";
	private bool activate = false;
	void OnMouseDown()
	{
		activate = true;
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform>().position.x < transform.position.x)
			GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveRight ();
		else
			GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveLeft();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (activate && col.tag == "Player" && col.transform.localScale.x == 1)
		{
			Camera.main.GetComponent<FadeTransition>().StartCoroutine("Fade", roomToGo);
			StartCoroutine(wait(col, -1));
			col.GetComponent<ChangeRoom>().DontMove();
		}
		else if (activate && col.tag == "Player" && col.transform.localScale.x == -1)
		{
			Camera.main.GetComponent<FadeTransition>().StartCoroutine("Fade", roomToGo);
			StartCoroutine(wait(col, 1));
			col.GetComponent<ChangeRoom>().DontMove();
		}
		activate = false;
	}
	IEnumerator wait(Collider2D col, int sign)
	{
		col.GetComponent<ChangeRoom>().DontMove();
		yield return new WaitForSeconds (1);
		col.transform.position = exit.transform.position;
	}
}
