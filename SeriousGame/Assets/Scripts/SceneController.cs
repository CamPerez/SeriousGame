using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	private AudioSource mainMusic;
	private Scene currentScene;

	// Use this for initialization
	void Start () {
		mainMusic = GameObject.Find("MainMenuMusic").GetComponent <AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Cargamos la siguiente escena
	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
		if (sceneName != "MainScene" && sceneName != "LevelMapScene" && sceneName != "CharacterSelector" && sceneName != "ReportScene" && sceneName != "InfoScene") {
			mainMusic.Stop ();
		}
	}

	public void LoadSameLevelScene(){
		SceneManager.LoadScene (GameManager.gameManager.lastLevelPlayed.LevelName);
	}

	public void LoadWithCharacterSelector(){
		Debug.Log (GameManager.gameManager.levels.Count);
		if (GameManager.gameManager.levels.Count > 0) {
			SceneManager.LoadScene ("dialogSkyScene");
		} else {
			SceneManager.LoadScene ("CharacterSelectorScene");
		}
	}
}
