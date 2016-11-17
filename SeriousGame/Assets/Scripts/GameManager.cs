using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int multiplier = 1;
	private int streak = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		
	}

	public void AddStreak(){
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
		UpdateGUI ();
	}

	public void ResetStreak(){
		streak = 0;
		multiplier = 1;
		UpdateGUI ();
	}


	public int GetScore(){
		return 100 * multiplier; 
	}

	void UpdateGUI(){
		PlayerPrefs.SetInt ("Streak", streak);
		PlayerPrefs.SetInt ("Multiplier", multiplier);
	}
}
