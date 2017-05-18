using UnityEngine;
using System.Collections;

public class WestLevel : MonoBehaviour {

	[SerializeField]
	private GameObject characterList;
	private GameObject player;
	private Animator animator;

	private string characterName = "";

	private int totalScore = 14700;
	private int totalNotes = 48;
	private int failedNotes = 0;
	private int correctNotes = 0;

	private bool songInit = false;

	[SerializeField]
	private GameObject brownActivator;
	[SerializeField]
	private GameObject redActivator;
	[SerializeField]
	private GameObject orangeActivator;
	[SerializeField]
	private GameObject yellowActivator;
	[SerializeField]
	private GameObject greenActivator;
	[SerializeField]
	private GameObject tealActivator;
	/*[SerializeField]
	private GameObject blueActivator;
	[SerializeField]
	private GameObject purpleActivator;
	*/

	[SerializeField]
	private AudioSource levelMusic;



	// Use this for initialization
	void Start () {
		GetPlayerOptions();
		characterName = player.name;
		// Create level object LevelData(int, levelID, string levelName, string levelCode, string characterName, bool isCompleted, int totalScore, int levelScore, int totalNotes, int correctNotes, int stars)
		LevelData skyLevel = new LevelData(3 , this.GetType ().Name, "level3", characterName, false, totalScore, 0, totalNotes, 0, 0);
		GameManager.gameManager.levels.Add (skyLevel);

		// Character control

		animator = player.GetComponent <Animator> ();
		animator.SetBool("isRunning", true);

		// Observe notifications
		NotificationCenter.DefaultCenter().AddObserver (this, "NoteFailed");
		NotificationCenter.DefaultCenter().AddObserver (this, "NotePressedCorrectly");
		NotificationCenter.DefaultCenter().AddObserver (this, "PointsIncresed");
	}
	
	// Update is called once per frame
	void Update () {
		if(!songInit && GameManager.gameManager.CountdownDone){
			levelMusic.Play ();
			songInit = true;
			GameManager.gameManager.CountdownDone = false;
		}
	}

	private void GetPlayerOptions(){
		int index = PlayerPrefs.GetInt ("MainCharacterSelected");
		player = characterList.transform.GetChild(index).gameObject;
		player.SetActive (true);
	}

	void NoteFailed(Notification notification){

		failedNotes++;
		if(failedNotes > 3){
			animator.SetBool("isHit",true);
			animator.SetBool("isRunning",false);
			failedNotes = 0;
		}
	}

	void NotePressedCorrectly(Notification notification){
		correctNotes++;
		if (correctNotes > 5) {
			animator.SetBool ("isRunning", true);
			animator.SetBool ("isJumping", false);
			animator.SetBool ("isHit", false);
			correctNotes = 0;
		}
	}

	void PointsIncresed(Notification notification){
		animator.SetBool("isJumping",true);
		animator.SetBool("isRunning",false);
	}

}
