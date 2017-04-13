using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ReportManager : MonoBehaviour {

	[SerializeField]
	private GameObject infoLevels;

	// Use this for initialization
	void Start () {
		CheckLevelsReport ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void CheckLevelsReport(){
	
		List<LevelData> levels = GameManager.gameManager.levels;
		GameObject levelInfoAux, infoAux;

		foreach(LevelData level in levels){
			if(level.IsCompleted){
				levelInfoAux = infoLevels.transform.FindChild ("level"+ level.LevelID.ToString ()).gameObject;
				infoAux = levelInfoAux.transform.FindChild ("info").gameObject;
				CheckLevelInfo (level, infoAux);
				infoAux.SetActive (true);
			}
		}
	
	}


	private void CheckLevelInfo(LevelData level, GameObject infoAux){

		GameObject starsLevelAux, score, notes, notesTotal, music, sound;
		starsLevelAux = infoAux.transform.FindChild ("stars").gameObject;
		PaintStars (level, starsLevelAux);
		score = infoAux.transform.FindChild ("score").gameObject;
		score.GetComponent <Text>().text = level.TotalScore.ToString ();
		notes = infoAux.transform.FindChild ("notes").gameObject;
		notes.GetComponent <Text>().text = level.CorrectNotes.ToString ();
		notesTotal = infoAux.transform.FindChild ("notesTotal").gameObject;
		notesTotal.GetComponent <Text>().text = level.TotalNotes.ToString ();
		music = infoAux.transform.FindChild ("music").gameObject;
		sound = infoAux.transform.FindChild ("sound").gameObject;

	}

	private void PaintStars(LevelData level, GameObject starsLevelAux){

		GameObject star1, star2, star3;

		star1 = starsLevelAux.transform.FindChild ("star1").gameObject;
		star2 = starsLevelAux.transform.FindChild ("star2").gameObject;
		star3 = starsLevelAux.transform.FindChild ("star3").gameObject;

		if(level.Stars == 1){
			star1.SetActive (true);
		}else if(level.Stars == 2){
			star1.SetActive (true);
			star2.SetActive (true);
		}else if(level.Stars == 3){
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
		}
	}
}
