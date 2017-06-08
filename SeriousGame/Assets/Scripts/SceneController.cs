using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	private AudioSource mainMusic;
	private Scene currentScene;

	private AudioSource source;
	[SerializeField]
	private AudioClip clickSound;

	// Use this for initialization
	void Start () {
		mainMusic = GameObject.Find("MainMenuMusic").GetComponent <AudioSource>();
		source = this.GetComponent <AudioSource> ();
	}

	//Cargamos la siguiente escena
	public void LoadScene(string sceneName){
		StartCoroutine (waitChangeScene ());
		SceneManager.LoadScene (sceneName);
		if ((sceneName != "MainScene" && sceneName != "LevelMapScene" && sceneName != "CharacterSelectorScene" && sceneName != "ReportScene"
			&& sceneName != "InfoScene" && sceneName != "NameCharacterScene") || !GameManager.gameManager.musicOn) {
			mainMusic.Stop ();
		}
	}

	public IEnumerator waitChangeScene(){
		yield return new WaitForSeconds (1f);
	}

	public void LoadSameLevelScene(){
		SceneManager.LoadScene (GameManager.gameManager.lastLevelPlayed.LevelName);
	}

	public void LoadWithCharacterAndNameSelector(){
		Debug.Log (GameManager.gameManager.levels.Count);
		if (GameManager.gameManager.levels.Count > 0) {
			SceneManager.LoadScene ("dialogSkyScene");
		} else {
			SceneManager.LoadScene ("CharacterSelectorScene");
		}
	}

	public void OnClick(){
		if (!GameManager.gameManager.effectsOn) {
			source.volume = 0;
		} else {
			source.volume = 1;
		}
		source.PlayOneShot (clickSound);
	}
}
