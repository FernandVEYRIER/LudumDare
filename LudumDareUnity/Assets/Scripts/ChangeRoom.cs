using UnityEngine;
using System.Collections;

public class ChangeRoom : MonoBehaviour {

	public bool moveRight = false;
	public bool moveLeft = false;
	private Vector3 init;
	public bool transition = false;
	
	void Update ()
	{
		if (moveLeft && !moveRight)
		{
			this.GetComponent<Animator>().SetBool("move", true);
			this.transform.localScale = new Vector3(1, 1, 1);
			transform.Translate(-4 * Time.deltaTime, 0, 0);
		}
		if (!moveLeft && moveRight)
		{
			this.GetComponent<Animator>().SetBool("move", true);
			this.transform.localScale = new Vector3(-1, 1, 1);
			transform.Translate(4 * Time.deltaTime, 0, 0);
		}
	}

	public void MoveLeft()
	{
		moveLeft = true;
		moveRight = false;
	}

	public void MoveRight()
	{
		moveRight = true;
		moveLeft = false;
	}

	public void DontMove()
	{
		moveRight = false;
		moveLeft = false;
		this.GetComponent<Animator>().SetBool("move", false);
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Door" && transform.localScale.x == 1)
			StartCoroutine(wait(col, -1));
		else if (col.tag == "Door" && transform.localScale.x == -1)
			StartCoroutine(wait(col, 1));
	}
	IEnumerator wait(Collider2D col, int sign)
	{
		transition = true;
		DontMove();
		Camera.main.GetComponent<FadeTransition>().StartCoroutine("Fade", col.GetComponent<door>().roomToGo);
		yield return new WaitForSeconds (1);
		transform.position = col.GetComponent<door>().exit.transform.position;
		yield return new WaitForSeconds (1);
		transition = false;
	}
}
