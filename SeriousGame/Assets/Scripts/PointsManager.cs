using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PointsManager : MonoBehaviour {


	[SerializeField]
	private string levelName;
	[SerializeField]
	public Stat points;

	private GameObject pointsManager;

	private int multiplier = 1;
	private int streak = 0;
	private int correctNotes = 0;

	private string bonusX2 = "¡bonus!\nX2";
	private string bonusX3 = "¡bonus!\nX3";
	private string bonusX4 = "¡bonus!\nX2";

	[SerializeField]
	private Text bonusText;

	private Animator animator;

	private AudioSource baseMusic;
	private GameObject gameManager;
	private float songLength;

	void Awake () {
		gameManager = GameObject.Find("GameManager");
		points.InitializeValues ();
	}

	// Use this for initialization
	void Start () {
		// Bonus text
		bonusText.enabled = false;
		animator = bonusText.GetComponent<Animator> ();
		// Finish level menu
		baseMusic = gameObject.GetComponent <AudioSource> ();
		songLength = baseMusic.clip.length;
		NotificationCenter.DefaultCenter().AddObserver (this, "LevelFinished");
		StartCoroutine(FinishLevel());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}


	/************************************************/
	/* 				POINTS/SCORE METHODS			
	/************************************************/


	// Añadimos los puntos de la nota pulsada en el activador
	public void AddScore(){
		correctNotes++;
		int winnedPoints = GetScore ();
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") + winnedPoints);
		//NotificationCenter.DefaultCenter ().PostNotification (this, "AddScoreToBar");
		points.CurrentVal += winnedPoints;

		AddStreak ();
	}

	//Añadimos multiplicadores si el usuario realiza determinados aciertos seguidos
	private void AddStreak(){
		int auxMult = multiplier;
		string auxBonus = "";
		streak++;
		if (streak >= 24) {
			multiplier = 4;
			auxBonus = bonusX4;
		} else if (streak >= 16) {
			multiplier = 3;
			auxBonus = bonusX3;
		} else if (streak >= 8) {
			multiplier = 2;
			auxBonus = bonusX2;
		} else {
			multiplier = 1;
		}
		if (auxMult != multiplier) {
			ShowBonusText (auxBonus);
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

	/************************************************/
	/* 				BONUS TEXT METHODS
	/************************************************/
		
	private void ShowBonusText(string bonus){
		bonusText.text = bonus;
		bonusText.enabled = true;

		StartCoroutine(FinishAnimation());
	}
		
	// Bonus text hiddes when text animation it's over
	private IEnumerator FinishAnimation(){
	
		AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo( 0 );
		yield return new WaitForSeconds(state.length);
		bonusText.enabled = false;
	}

	/************************************************/
	/* 			FINISH LEVEL MENU METHODS
	/************************************************/
	private IEnumerator FinishLevel(){
		yield return new WaitForSeconds(songLength);
		NotificationCenter.DefaultCenter ().PostNotification (this, "LevelFinished");
	}

	private void LevelFinished(Notification notification){
		// Save level data in levelObject
		SaveLevelByName(levelName);
			Debug.Log (GameManager.gameManager.lastLevelPlayed.LevelName);
			Debug.Log (GameManager.gameManager.lastLevelPlayed.CorrectNotes);
			Debug.Log (GameManager.gameManager.lastLevelPlayed.Stars);
			Debug.Log (GameManager.gameManager.lastLevelPlayed.LevelScore);
		gameManager.GetComponent <SceneController> ().LoadScene ("FinishMenuScene");
	}

	private void SaveLevelByName(string levelName){
		for(int i = 0; i < GameManager.gameManager.levels.Count; i++){
			if(GameManager.gameManager.levels[i].LevelName == levelName){
				GameManager.gameManager.levels [i].IsCompleted = IsCompleted(correctNotes, GameManager.gameManager.levels [i].TotalNotes);
				GameManager.gameManager.levels [i].CorrectNotes = correctNotes;
				GameManager.gameManager.levels [i].LevelScore = points.CurrentVal;
				if (GameManager.gameManager.levels [i].IsCompleted) {
					GameManager.gameManager.levels [i].Stars = CalculateStars (points.CurrentVal, points.MaxVal);
				}

				GameManager.gameManager.lastLevelPlayed = GameManager.gameManager.levels [i];
			}
		}
	}

	private bool IsCompleted(int correctNotes, int totalNotes){
		float div = totalNotes / 3;
		if (correctNotes >= Math.Ceiling (div * 2)) {
			return true;
		} else {
			return false;
		}
	}

	private int CalculateStars(float currentScore, float totalScore){
		float div = totalScore / 3;
		if (currentScore <= div) {
			return 1;
		} else if (currentScore > div && currentScore <= div * 2) {
			return 2;
		}else if (currentScore > div*2) {
			return 3;
		}
		return 0;
	}

}
