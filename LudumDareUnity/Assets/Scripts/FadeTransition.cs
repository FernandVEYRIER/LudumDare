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
		GameObject.Find("PixelEffector").GetComponent<PixelEffector>().startTransition();
		yield return new WaitForSeconds(1.3f);
		foreach (CameraPos _camPos in camPos)
		{
			if (_camPos.roomName == roomToGo)
			{
				Camera.main.transform.position = _camPos.position.position + new Vector3(0, 0, -10);
			}
		}
	}
}
