using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Stat points;


	void Awake(){
		points.InitializeValues ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown (KeyCode.Q)){
			points.CurrentVal -= 10;
		}

		if(Input.GetKeyDown (KeyCode.W)){
			points.CurrentVal += 10;
		}
	}
}
