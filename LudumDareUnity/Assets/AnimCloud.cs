using UnityEngine;
using System.Collections;

public class AnimCloud : MonoBehaviour {

	public float velocity = 0.001f;

	void Update () 
	{
		this.GetComponent<MeshRenderer>().material.mainTextureOffset += new Vector2(velocity, 0);
	}
}
