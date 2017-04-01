using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {

	[SerializeField]
	private float speed = 0.15f;

	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed, 0); // Velocidad en el eje x (movimiento horizontal)
		renderer.material.mainTextureOffset = offset;
	}
}
