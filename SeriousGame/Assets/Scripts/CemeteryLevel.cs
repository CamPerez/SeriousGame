using UnityEngine;
using System.Collections;
using System;

public class CemeteryLevel : MonoBehaviour {

	private GameObject player;
	private Animator animator;

	private string characterName = "Vampire";

	private int totalScore = 9200;
	private int totalNotes = 35;
	private int failedNotes = 0;
	private int correctNotes = 0;

	private bool songInit = false;

	[SerializeField]
	private AudioSource levelMusic;

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
	[SerializeField]
	private GameObject blueActivator;
	[SerializeField]
	private GameObject purpleActivator;

	[SerializeField]
	private GameObject noteCounter;
	private NoteDestroyer nc;



	// Use this for initialization
	void Start () {
		DateTime dt = DateTime.Now;
		string date = dt.ToString("dd/MM/yyyy");
		// Create level object LevelData(levelID, string levelName, string levelCode, string characterName, bool isCompleted, int totalScore, int levelScore, int totalNotes, int correctNotes, int stars)
		LevelData cemeteryLevel = new LevelData(2 , this.GetType ().Name, "level2", "Skeleton", false, totalScore, 0, totalNotes, 0, 0, date);
		if (GameManager.gameManager.levels.Count == 1) {
			GameManager.gameManager.levels.Add (cemeteryLevel);
		}

		// Character control
		player = GameObject.Find(characterName);
		animator = player.GetComponent <Animator> ();

		// Note's counter
		nc = noteCounter.GetComponent<NoteDestroyer>();

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
		// Change notes music when musics changes (after 17 notes)
		if(nc.counter == 18){
			brownActivator.SetActive (false);
			redActivator.SetActive (false);
			orangeActivator.SetActive (false);
			yellowActivator.SetActive (false);

			greenActivator.SetActive (true);
			tealActivator.SetActive (true);
			blueActivator.SetActive (true);
			purpleActivator.SetActive (true);
		}
	}
		
	void NoteFailed(Notification notification){
		failedNotes++;
		if(failedNotes > 3){
			animator.SetBool("isAppearing",true);
			animator.SetBool("isAttacking",false);
			animator.SetBool("isRunning",false);
			failedNotes = 0;
		}
	}

	void NotePressedCorrectly(Notification notification){
		correctNotes++;
		if (correctNotes > 5) {
			animator.SetBool ("isAttacking", true);
			animator.SetBool ("isRunning", false);
			animator.SetBool ("isAppearing", false);
			correctNotes = 0;
		}
	}

	void PointsIncresed(Notification notification){
		animator.SetBool("isRunning",true);
		animator.SetBool("isAppearing",false);
		animator.SetBool("isAttacking",false);
	}

}
