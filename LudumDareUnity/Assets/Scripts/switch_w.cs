using UnityEngine;
using System.Collections;

public class switch_w : MonoBehaviour {
	
	void Update ()
	{
		transform.localScale = GameObject.FindGameObjectWithTag ("Player").transform.localScale;
	}
}
