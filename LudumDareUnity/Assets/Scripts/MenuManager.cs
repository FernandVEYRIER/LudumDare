using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadIntro()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
