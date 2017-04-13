using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour {

	private GameManager GM;

	public void SetCountDown(){

		GM = GameObject.Find("GameManager").GetComponent <GameManager>();
		GM.CountdownDone = true;
	}
}
