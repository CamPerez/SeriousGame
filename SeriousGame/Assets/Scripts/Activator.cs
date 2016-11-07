using UnityEngine;
using System.Collections;

public class Activator : MonoBehaviour {

	public KeyCode key;
	bool active = false;
	GameObject note;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown (0) && active){ //Si se ha tocado la tecla y está activo (hay un objeto pasando por el activador)
			Destroy (note); //Destruimos la nota
		}
	}

	//Se detecta un elemento tocando al activador
	void OnTriggerEnter2D(Collider2D col){
		active = true;
		if(col.gameObject.tag == "Note"){ //Si el elemento que nos toca es una nota se guarda
			note = col.gameObject;
		}
	}


	void OnTriggerExit2D(Collider2D col){
		active = false;
	}
}
