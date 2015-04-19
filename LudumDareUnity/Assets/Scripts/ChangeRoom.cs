using UnityEngine;
using System.Collections;

public class ChangeRoom : MonoBehaviour {

	bool moveRight = false;
	bool moveLeft = false;
	private Vector3 init;
	Vector3 refVel;

	void Start () 
	{
		init = transform.position;
	}
	
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
}
