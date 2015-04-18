using UnityEngine;
using System.Collections;

public class bounce_info : MonoBehaviour {
	
	public float duration;
	public AudioClip sound;
	private GameObject obj;
	Vector3 velocity = Vector3.zero;
	void Start()
	{
		this.GetComponent<SpriteRenderer>().enabled = false;
		transform.localScale = Vector3.zero;
	}
	void Update()
	{
		if (obj)
		{
			obj.transform.localScale = Vector3.Lerp (obj.transform.localScale, Vector3.one, 4 * Time.deltaTime);
			transform.localScale = Vector3.Lerp (transform.localScale, Vector3.one * 2, 4 * Time.deltaTime);
		}
	}
	public void create_info_bulle(Sprite image)
	{
		this.GetComponent<SpriteRenderer>().enabled = true;
		obj = new GameObject();
		obj.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.1f);
		obj.AddComponent<SpriteRenderer>();
		obj.GetComponent<SpriteRenderer>().sprite = image;
		obj.AddComponent<AudioSource>().clip = sound;
		obj.GetComponent<AudioSource>().Play();
		StartCoroutine("died");
		obj.transform.localScale = Vector3.zero;
	}
	IEnumerator died()
	{
		yield return new WaitForSeconds(duration);
		this.GetComponent<SpriteRenderer>().enabled = false;
		transform.localScale = Vector3.zero;
		Destroy(obj);
	}
}
