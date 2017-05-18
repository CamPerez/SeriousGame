using UnityEngine;
using System.Collections;

public class NoteDestroyer : MonoBehaviour {

	[SerializeField]
	private bool isCounter = false;

	public int counter = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if (isCounter) {
			counter++;
		} else {
			Destroy (other.gameObject);
		}
	}
}
