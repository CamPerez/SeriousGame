using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishedLevel : MonoBehaviour {

	[SerializeField]
	private GameObject finishMenu;
	[SerializeField]
	private GameObject finishMenuLost;
	[SerializeField]
	private GameObject star1;
	[SerializeField]
	private GameObject star2;
	[SerializeField]
	private GameObject star3;
	[SerializeField]
	private Text scoreValue;
	[SerializeField]
	private Text noteValue;
	[SerializeField]
	private Text totalNotesValue;
	[SerializeField]
	private Text scoreValueLost;
	[SerializeField]
	private Text noteValueLost;
	[SerializeField]
	private Text totalNotesValueLost;
	[SerializeField]
	private GameObject characterList;
	[SerializeField]
	private GameObject characterListLost;

	void Awake(){

	}

	// Use this for initialization
	void Start () {

		if (GameManager.gameManager.lastLevelPlayed.IsCompleted) {
			finishMenu.SetActive (true);
			CheckStars ();
		} else {
			finishMenuLost.SetActive (true);
		}
		CheckScoreAndNotes ();
		ActiveCharacter ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void CheckStars(){
		if(GameManager.gameManager.lastLevelPlayed.Stars == 1){
			star1.SetActive (true);
		}else if(GameManager.gameManager.lastLevelPlayed.Stars == 2){
			star1.SetActive (true);
			star2.SetActive (true);
		}else if(GameManager.gameManager.lastLevelPlayed.Stars == 3){
			star1.SetActive (true);
			star2.SetActive (true);
			star3.SetActive (true);
		}
	}

	private void CheckScoreAndNotes(){
		if(GameManager.gameManager.lastLevelPlayed.IsCompleted){
			scoreValue.text = GameManager.gameManager.lastLevelPlayed.LevelScore.ToString ();
			noteValue.text = GameManager.gameManager.lastLevelPlayed.CorrectNotes.ToString ();
			totalNotesValue.text = GameManager.gameManager.lastLevelPlayed.TotalNotes.ToString ();
		}else{
			scoreValueLost.text = GameManager.gameManager.lastLevelPlayed.LevelScore.ToString ();
			noteValueLost.text = GameManager.gameManager.lastLevelPlayed.CorrectNotes.ToString ();
			totalNotesValueLost.text = GameManager.gameManager.lastLevelPlayed.TotalNotes.ToString ();
		}

	}

	private void ActiveCharacter(){
		GameObject listAux;
		if(GameManager.gameManager.lastLevelPlayed.IsCompleted){
			listAux = characterList;
		}else{
			listAux = characterListLost;
		}
		foreach (Transform t in listAux.transform){
			if(t.name == GameManager.gameManager.lastLevelPlayed.CharacterName){
				t.gameObject.SetActive (true);
			}
		}

	}


}
