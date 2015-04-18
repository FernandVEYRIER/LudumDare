using UnityEngine;
using System.Collections;
using AlpacaSound;
using System.Collections.Generic;

public class FadeTransition : MonoBehaviour {

	RetroPixel var;
	public CameraPos [] camPos;

	[System.Serializable]
	public class CameraPos
	{
		public string roomName;
		public Transform position;
	}

	void Start () 
	{
		var = this.GetComponent<RetroPixel>();
		var.enabled = false;
	}

	public IEnumerator Fade(string roomToGo)
	{
		var.enabled = true;
		int step = 50;

		for (int i = 10; i < 31; i++)
		{
			this.GetComponent<RetroPixel>().horizontalResolution -= step;
			this.GetComponent<RetroPixel>().verticalResolution -= step;
			yield return new WaitForSeconds(0.04f);
		}
		foreach (CameraPos _camPos in camPos)
		{
			if (_camPos.roomName == roomToGo)
			{
				Camera.main.transform.position = _camPos.position.position + new Vector3(0, 0, -10);
			}
		}
		for (int i = 31; i > 10; i--)
		{
			this.GetComponent<RetroPixel>().horizontalResolution += step;
			this.GetComponent<RetroPixel>().verticalResolution += step;
			yield return new WaitForSeconds(0.04f);
		}
		var.enabled = false;
	}
}
