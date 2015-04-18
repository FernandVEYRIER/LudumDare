using UnityEngine;
using System.Collections;

public class ChangeRoom : MonoBehaviour {

	public Transform leftDoor;
	public Transform rightDoor;
	
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
			this.transform.localScale = new Vector3(1, 1, 1);
			this.transform.position = Vector3.Lerp(this.transform.position, new Vector3 (leftDoor.position.x, init.y, init.z), 2 * Time.deltaTime);
		}
		if (!moveLeft && moveRight)
		{
			this.transform.localScale = new Vector3(-1, 1, 1);
			this.transform.position = Vector3.Lerp(this.transform.position, new Vector3 (rightDoor.position.x, init.y, init.z), 2 * Time.deltaTime);
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
	}
}
