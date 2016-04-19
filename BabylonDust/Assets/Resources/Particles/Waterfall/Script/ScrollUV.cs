using UnityEngine;
using System.Collections;

public class ScrollUV : MonoBehaviour {

	public float scrollSpeed_X = 0.5f;
	public float scrollSpeed_Y = 0.5f;
	private Renderer rend;

	void Start () {
		rend = GetComponent<Renderer> ();
	}

	void Update () {
		float offsetX = Time.time * scrollSpeed_X;
		float offsetY = Time.time * scrollSpeed_Y;
		rend.material.mainTextureOffset = new Vector2 (offsetX, offsetY);
	}
}
