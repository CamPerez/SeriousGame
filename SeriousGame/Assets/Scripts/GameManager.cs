using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int multiplier = 1;
	private int streak = 0;
	private int correctNotes = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}

	// Añadimos los puntos de la nota pulsada en el activador
	public void AddScore(){
		correctNotes++;
		int winnedPoints = GetScore ();
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + winnedPoints);
		NotificationCenter.DefaultCenter ().PostNotification (this, "AddScoreToBar");
		AddStreak ();
	}

	//Añadimos multiplicadores si el usuario realiza determinados aciertos seguidos
	private void AddStreak(){
		int auxMult = multiplier;
		streak++;
		if (streak >= 24) {
			multiplier = 4;
		} else if (streak >= 16) {
			multiplier = 3;
		} else if (streak >= 8) {
			multiplier = 2;
		} else {
			multiplier = 1;
		}
		if (auxMult != multiplier) {
			NotificationCenter.DefaultCenter ().PostNotification (this, "PointsIncresed"); 
		}
		UpdateGUI ();
	}

	public void ResetStreak(){
		streak = 0;
		multiplier = 1;
		UpdateGUI ();
	}

	//Devolvemos la puntuación por cada nota tocada multiplicada por el valor de aciertos seguidos
	public int GetScore(){
		return 100 * multiplier; 
	}

	private void UpdateGUI(){
		//PlayerPrefs.SetInt ("Streak", streak);
		//PlayerPrefs.SetInt ("Multiplier", multiplier);
		PlayerPrefs.SetInt ("correctNotes", correctNotes);
	}
}
