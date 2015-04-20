using UnityEngine;
using System.Collections;

public class ReloadLevel : MonoBehaviour {

	public void ReloadLevelFunction()
	{
		Application.LoadLevel("Level1");
	}
}
