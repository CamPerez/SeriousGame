using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

	private SpriteRenderer sr;

	private Color colorWhenPressed = new Color(0,0,0);
	private Color oldColor;

	public KeyCode key;
	bool active = false;

	private GameObject note;

	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
		oldColor = sr.color;
		NotificationCenter.DefaultCenter().AddObserver (this, "NotePressedCorrectly"); //Pendientes de mensaje de nota tocada dentro de activador
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Se detecta un elemento tocando al activador
	void OnTriggerEnter2D(Collider2D col){
		active = true;
	}


	void OnTriggerExit2D(Collider2D col){
		active = false;
	}

	public void SetColorChange(){
		StartCoroutine (Pressed ());
	}
		
	IEnumerator Pressed(){
		sr.color = colorWhenPressed;
		yield return new WaitForSeconds (0.05f);
		sr.color = oldColor;
	}


}
