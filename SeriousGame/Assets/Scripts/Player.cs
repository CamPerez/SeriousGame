using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Stat points;

	private GameObject gameManager;


	void Awake(){
		points.InitializeValues ();
	}

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {

		NotificationCenter.DefaultCenter().AddObserver (this, "AddScoreToBar");

		/*if(Input.GetKeyDown (KeyCode.Q)){
			points.CurrentVal -= 10;
		}

		if(Input.GetKeyDown (KeyCode.W)){
			points.CurrentVal += 10;
		}*/
	}

	//Aumentamos los puntos conseguidos en la barra
	void AddScoreToBar(Notification notification){
		int winnedPoints = gameManager.GetComponent<GameManager> ().GetScore ();
		points.CurrentVal += winnedPoints;
	}
}
