using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bubble_inf : MonoBehaviour {

	public GameObject canvas;
	public GameObject parent;
	void Update ()
	{
		float mult;
		canvas.transform.position = transform.position;
		if  ((canvas.transform.localScale.x > 0 && parent.transform.localScale.x < 0) || (canvas.transform.localScale.x < 0 && parent.transform.localScale.x > 0))
			canvas.transform.localScale = new Vector3(canvas.transform.localScale.x * -1, canvas.transform.localScale.y, canvas.transform.localScale.z);
	}
	public void create_bubble(Sprite spr)
	{

	}
}
