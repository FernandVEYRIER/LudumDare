using UnityEngine;
using System.Collections;

public class ChangeRoom : MonoBehaviour {

	public Transform leftDoor;
	public Transform rightDoor;

	bool moveRight = true;
	bool moveLeft = false;

	Vector3 refVel;

	void Start () 
	{
	
	}
	
	void Update ()
	{
		if (moveLeft && !moveRight)
		{
			this.transform.position =  Vector3.SmoothDamp(this.transform.position, leftDoor.position, ref refVel, 0.9f);
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
		}
		if (!moveLeft && moveRight)
		{
			this.transform.position = Vector3.SmoothDamp(this.transform.position, rightDoor.position, ref refVel, 0.9f);
			this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
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
