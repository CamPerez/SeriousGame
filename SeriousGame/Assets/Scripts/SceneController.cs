using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Cargamos la siguiente escena
	public void LoadScene(string sceneName){
		Debug.Log (sceneName);
		SceneManager.LoadScene (sceneName);
		Debug.Log (sceneName);
	}

	public void LoadSameLevelScene(){
		Debug.Log (GameManager.gameManager.lastLevelPlayed.LevelName);
		SceneManager.LoadScene (GameManager.gameManager.lastLevelPlayed.LevelName);

	}
}
