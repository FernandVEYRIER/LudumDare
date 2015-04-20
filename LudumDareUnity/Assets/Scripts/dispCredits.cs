using UnityEngine;
using System.Collections;

public class dispCredits : MonoBehaviour {

	public GameManager gm;

	void OnMouseDown()
	{
		gm.affCredits();
	}
}
