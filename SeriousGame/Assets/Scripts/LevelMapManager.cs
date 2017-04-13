using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelMapManager : MonoBehaviour {


	[SerializeField]
	private GameObject lockedLevels;
	[SerializeField]
	private GameObject starsLevels;


	// Use this for initialization
	void Start () {

		CheckLevelsStars ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void CheckLevelsStars(){

		List<LevelData> levels = GameManager.gameManager.levels;
		GameObject starsUnlockedLevel, nextLockedLevel;
		int nextLevelID;

		foreach(LevelData level in levels){
			nextLevelID = level.LevelID + 1;
			nextLockedLevel = lockedLevels.transform.FindChild ("level"+nextLevelID.ToString ()).gameObject;
			nextLockedLevel.SetActive (false);
			if(level.IsCompleted){
				starsUnlockedLevel = starsLevels.transform.FindChild (level.LevelCode).gameObject;
				PaintStars (level, starsUnlockedLevel);
			}
		}


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
