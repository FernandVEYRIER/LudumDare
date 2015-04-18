using UnityEngine;
using System.Collections;
using AlpacaSound;

public class FadeTransition : MonoBehaviour {
	RetroPixel var;

	void Start () 
	{
		var = this.GetComponent<RetroPixel>();
		var.enabled = false;
	}

	public IEnumerator Fade()
	{
		var.enabled = true;

		for (int i = 10; i < 45; i++)
		{
			this.GetComponent<RetroPixel>().horizontalResolution -= i;
			this.GetComponent<RetroPixel>().verticalResolution -= i;
			yield return new WaitForSeconds(0.06f);
		}
		for (int i = 45; i >= 0; i--)
		{
			this.GetComponent<RetroPixel>().horizontalResolution += i;
			this.GetComponent<RetroPixel>().verticalResolution += i;
			yield return new WaitForSeconds(0.04f);
		}
		var.enabled = false;

	}
}
