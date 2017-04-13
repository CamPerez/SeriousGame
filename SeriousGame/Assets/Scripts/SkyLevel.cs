using UnityEngine;
using System.Collections;

public class SkyLevel : MonoBehaviour {

	private GameObject Rytmus;
	private Animator animator;

	private string characterName = "Rytmus";

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
	/*[SerializeField]
	private GameObject tealActivator;
	[SerializeField]
	private GameObject blueActivator;
	[SerializeField]
	private GameObject purpleActivator;
	*/

	private AudioSource levelMusic;
	[SerializeField]
	private AudioSource noteSoundBrown;
	[SerializeField]
	private AudioSource noteSoundRed;
	[SerializeField]
	private AudioSource noteSoundOrange;
	[SerializeField]
	private AudioSource noteSoundYellow;
	[SerializeField]
	private AudioSource noteSoundGreen;
	/*[SerializeField]
	private AudioSource noteSoundTeal;
	[SerializeField]
	private AudioSource noteSoundBlue;
	[SerializeField]
	private AudioSource noteSoundPurple;
	*/

	// Use this for initialization
	void Start () {

		// Create level object LevelData(int, levelID, string levelName, string levelCode, string characterName, bool isCompleted, int totalScore, int levelScore, int totalNotes, int correctNotes, int stars)
		LevelData skyLevel = new LevelData(1 , this.GetType ().Name, "level1", characterName, false, totalScore, 0, totalNotes, 0, 0);
		GameManager.gameManager.levels.Add (skyLevel);

		// Character control
		Rytmus = GameObject.Find(characterName);
		animator = Rytmus.GetComponent <Animator> ();
		animator.SetBool("isFlying", true);

		// Music and sounds
		levelMusic = gameObject.GetComponent <AudioSource>();
		brownActivator.GetComponent <Activator> ().setNoteSound (noteSoundBrown);
		redActivator.GetComponent <Activator> ().setNoteSound (noteSoundRed);
		orangeActivator.GetComponent <Activator> ().setNoteSound (noteSoundOrange);
		yellowActivator.GetComponent <Activator> ().setNoteSound (noteSoundYellow);
		greenActivator.GetComponent <Activator> ().setNoteSound (noteSoundGreen);
		/*tealActivator.GetComponent <Activator> ().setNoteSound (noteSoundTeal);
		blueActivator.GetComponent <Activator> ().setNoteSound (noteSoundBlue);
		purpleActivator.GetComponent <Activator> ().setNoteSound (noteSoundPurple);
		*/

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
		}
	}

	void NoteFailed(Notification notification){

		failedNotes++;
		if(failedNotes > 3){
			animator.SetBool("isFlyingHit",true);
			animator.SetBool("isFlying",false);
			animator.SetBool("isFlyingJump",false);
			failedNotes = 0;
		}
	}

	void NotePressedCorrectly(Notification notification){
		correctNotes++;
		if (correctNotes > 5) {
			animator.SetBool ("isFlying", true);
			animator.SetBool ("isFlyingHit", false);
			animator.SetBool ("isFlyingJump", false);
			correctNotes = 0;
		}
	}

	void PointsIncresed(Notification notification){
		animator.SetBool("isFlyingJump",true);
		animator.SetBool("isFlying",false);
		animator.SetBool("isFlyingHit",false);
	}

}
