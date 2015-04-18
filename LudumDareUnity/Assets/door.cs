using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {

	public GameObject exit_door;
	public bool right;
	public string roomToGo = "none";
	void OnMouseDown()
	{
		if (right)
			GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveRight ();
		else
			GameObject.FindGameObjectWithTag ("Player").GetComponent<ChangeRoom> ().MoveLeft();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.transform.localScale.x == 1)
		{
			Camera.main.GetComponent<FadeTransition>().StartCoroutine("Fade", roomToGo);
			StartCoroutine(wait(col, -1));
			col.GetComponent<ChangeRoom>().DontMove();
		}
		else if (col.transform.localScale.x == - 1)
		{
			Camera.main.GetComponent<FadeTransition>().StartCoroutine("Fade", roomToGo);
			StartCoroutine(wait(col, 1));
			col.GetComponent<ChangeRoom>().DontMove();
		}
	}
	IEnumerator wait(Collider2D col, int sign)
	{
		col.GetComponent<ChangeRoom>().DontMove();
		yield return new WaitForSeconds (1);
		col.transform.position = new Vector3(exit_door.transform.position.x + sign * (col.bounds.size.x + 1), col.transform.position.y, col.transform.position.z);
	}
}
