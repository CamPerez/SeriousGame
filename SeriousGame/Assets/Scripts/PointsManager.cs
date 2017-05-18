using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour {


	[SerializeField]
	private string levelName;
	[SerializeField]
	public Stat points;

	private GameObject pointsManager;

	private int multiplier = 1;
	private int streak = 0;
	private int correctNotes = 0;

	private string bonusX2 = "¡bonus!\nx2";
	private string bonusX3 = "¡bonus!\nx3";
	private string bonusX4 = "¡bonus!\nx2";

	[SerializeField]
	private Text bonusText;

	private Animator animator;

	[SerializeField]
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
		songLength = baseMusic.clip.length;
		NotificationCenter.DefaultCenter().AddObserver (this, "LevelFinished");
		StartCoroutine(FinishLevel());
	}
	
	// Update is called once per frame
	void Update () {
	
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
		SceneManager.LoadScene ("FinishMenuScene");
	}

	private void SaveLevelByName(string levelName){
		for(int i = 0; i < GameManager.gameManager.levels.Count; i++){
			if(GameManager.gameManager.levels[i].LevelName == levelName){
				if (GameManager.gameManager.levels [i].IsCompleted) {
					SaveLevelAlreadyPlayed (GameManager.gameManager.levels [i]);
				} else {
					SaveLevelFirstTimePlayed (GameManager.gameManager.levels [i]);
				}
				GameManager.gameManager.lastLevelPlayed = GameManager.gameManager.levels[i];
			}
		}
	}

	private void SaveLevelAlreadyPlayed(LevelData level){
		if (level.LevelScore < points.CurrentVal) {
			level.LevelScore = points.CurrentVal;
			level.CorrectNotes = correctNotes;
			level.Stars = CalculateStars (points.CurrentVal, points.MaxVal);
		} 
	}

	private void SaveLevelFirstTimePlayed(LevelData level){
		level.IsCompleted = IsCompleted(correctNotes, level.TotalNotes);
		level.CorrectNotes = correctNotes;
		level.LevelScore = points.CurrentVal;
		if (level.IsCompleted) {
			level.Stars = CalculateStars (points.CurrentVal, points.MaxVal);
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
