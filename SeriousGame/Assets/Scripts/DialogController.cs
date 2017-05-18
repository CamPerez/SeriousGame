using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DialogController : MonoBehaviour {
	
	private float delay = 0.05f;
	private string currentText = "";

	public static DialogController dialogController = new DialogController();

	// Use this for initialization
	void Start () {
		//StartCoroutine (ShowText ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator ShowText(string newText, Color color, Text textObject){
		for(int i = 0; i <= newText.Length; i++){
			currentText = newText.Substring (0, i);
			textObject.color = color;
			textObject.text = currentText;
			yield return new WaitForSeconds (delay);
		}
	}
}
