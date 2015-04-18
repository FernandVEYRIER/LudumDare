using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject pausePanel;

	void Start () {
	
	}
	
	void Update () {
	
	}

	public void dispPause()
	{
		Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
		pausePanel.SetActive(!pausePanel.activeSelf);
	}

	public void quitGame()
	{
		Application.Quit();
	}
}
