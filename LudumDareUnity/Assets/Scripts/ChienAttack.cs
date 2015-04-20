using UnityEngine;
using System.Collections;

public class ChienAttack : MonoBehaviour {

	GameObject target = null;

	void Start () 
	{
		target = GameObject.FindGameObjectWithTag("Scout");
	}
	
	void Update () 
	{
		while (Mathf.Abs(Vector2.Distance(this.transform.position, target.transform.position)) > 1)
		{
			transform.position = Vector3.Lerp(this.transform.position, target.transform.position, 1);
		}
	}
}
