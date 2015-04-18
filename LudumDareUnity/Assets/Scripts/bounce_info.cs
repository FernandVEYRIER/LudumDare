using UnityEngine;
using System.Collections;

public class bounce_info : MonoBehaviour {

	public Sprite image;
	public float duration;
	public AudioClip sound;
	GameObject obj;
	Vector3 velocity = Vector3.zero;

	void Start()
	{
		obj = new GameObject();
		obj.transform.position = transform.position;
		obj.AddComponent<SpriteRenderer>();
		obj.GetComponent<SpriteRenderer>().sprite = image;
		obj.AddComponent<AudioSource>().clip = sound;
		obj.GetComponent<AudioSource>().Play();
		StartCoroutine("died");
		obj.transform.localScale = Vector3.zero;
	}
	void Update()
	{
		if (obj)
			obj.transform.localScale = Vector3.Lerp (obj.transform.localScale, Vector3.one, 4 * Time.deltaTime);
	}
	IEnumerator died()
	{
		yield return new WaitForSeconds(duration);
		Destroy(obj);
	}
}
