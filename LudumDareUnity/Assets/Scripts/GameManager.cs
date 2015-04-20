﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject pausePanel;
	public GameObject creditsPanel;

	public void dispPause()
	{
		Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
		pausePanel.SetActive(!pausePanel.activeSelf);
	}

	public void quitGame()
	{
		Application.Quit();
	}

	public void affCredits()
	{
		Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
		creditsPanel.SetActive(!creditsPanel.activeSelf);
	}
}
