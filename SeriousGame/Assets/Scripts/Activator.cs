using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

	private SpriteRenderer sr;

	private Color colorWhenPressed = new Color(0,0,0);
	private Color oldColor;

	public KeyCode key;
	public bool createMode;
	public GameObject n;

	[SerializeField]
	private int activatorNoteScale;
	[SerializeField]
	private AudioSource noteSound;

	bool active = false;

	private GameObject note;

	void Awake () {
		sr = GetComponent<SpriteRenderer> ();
	}

	// Use this for initialization
	void Start () {
		oldColor = sr.color;
		NotificationCenter.DefaultCenter().AddObserver (this, "NotePressedCorrectly"); // Pendientes de mensaje de nota tocada dentro de activador
	}
	
	// Update is called once per frame
	void Update () {

		if (createMode) {

			if (Input.GetKeyDown (key)) {
				Instantiate (n, transform.position, Quaternion.identity);
			}

		}

	}


	//Se detecta un elemento tocando al activador
	void OnTriggerEnter2D(Collider2D col){
		active = true;
	}


	void OnTriggerExit2D(Collider2D col){
		active = false;
	}

	public void playNoteSound(){
		noteSound.Play ();
	}

	public void SetColorChange(){
		StartCoroutine (Pressed ());
	}
		
	//Modificamos el color del activador cuando se destruye una nota sobre él
	IEnumerator Pressed(){
		sr.color = colorWhenPressed;
		yield return new WaitForSeconds (0.05f);
		sr.color = oldColor;
	}

	public void setNoteSound(AudioSource sound){
		noteSound = sound;
	}
		
}
