using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

	Rigidbody2D rb;
	public float speed = 2;
	private bool inside = false;


	private RuntimePlatform platform = Application.platform;
	private GameObject note;
	private GameObject activator;
	private GameObject gameManager;
	private Activator activatorScript;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
	}

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
		rb.velocity = new Vector2 (0, -speed);
	}

	void Update(){
		if(platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer){
			if(Input.touchCount > 0) {
				if(Input.GetTouch(0).phase == TouchPhase.Began){
					checkTouch(Input.GetTouch(0).position);
				}
			}
		}else if(platform == RuntimePlatform.WindowsEditor){
			if(Input.GetMouseButtonDown(0)) {
				checkTouch(Input.mousePosition);
			}
		}
	}

	void checkTouch(Vector3 pos){
		Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
		Vector2 touchPos = new Vector2(wp.x, wp.y);
		Collider2D hit = Physics2D.OverlapPoint(touchPos);

		if(hit && hit.transform.gameObject.tag == "Note"){
			note = hit.transform.gameObject;
			if(inside == true && gameObject.name == note.name){
				NotificationCenter.DefaultCenter ().PostNotification (this, "NotePressedCorrectly"); //La nota ha sido pulsada cuando pasa por un activador
				activator.GetComponent <Activator>().SetColorChange ();
				Destroy (note);
				gameManager.GetComponent<GameManager> ().AddStreak ();
				AddScore ();
			}
		}
	}


	void AddScore(){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + gameManager.GetComponent<GameManager>().GetScore ());
	}
		

	//Se detecta un elemento tocando la nota
	void OnTriggerEnter2D(Collider2D col){
		inside = true;
		activator = col.gameObject;
	}
		
	void OnTriggerExit2D(Collider2D col){
		inside = false;
		gameManager.GetComponent<GameManager> ().ResetStreak (); 
		//Se detecta que ha pasado una nota por el activador y ha salido de ella (No ha sido destruida), 
		//por lo que se reinicia los streaks seguidos del jugador
	}
		
}
