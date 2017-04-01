using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Stat points;

	private GameObject pointsManager;


	void Awake(){
		points.InitializeValues ();
	}

	// Use this for initialization
	void Start () {
		pointsManager = GameObject.Find("LevelManager");
		NotificationCenter.DefaultCenter().AddObserver (this, "AddScoreToBar");
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown (KeyCode.Q)){
			points.CurrentVal -= 10;
		}

		if(Input.GetKeyDown (KeyCode.W)){
			points.CurrentVal += 10;
		}*/
	}

	//Aumentamos los puntos conseguidos en la barra
	void AddScoreToBar(Notification notification){
		int winnedPoints = pointsManager.GetComponent<PointsManager> ().GetScore ();
		points.CurrentVal += winnedPoints;
	}
}
