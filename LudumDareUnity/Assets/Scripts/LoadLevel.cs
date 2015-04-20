using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public void LoadGame()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	void Update()
	{
		if (Input.anyKeyDown)
			Application.LoadLevel(Application.loadedLevel + 1);
	}
}
