using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
	private string mainMenu;

	[SerializeField]
	private bool isPaused;

	[SerializeField]
	private GameObject pauseMenuCanvas;

	private AudioSource baseMusic;
	[SerializeField]
	private AudioSource hitMusic;
	[SerializeField]
	private AudioSource menuMusic;
	[SerializeField]
	private AudioSource menuMusicB;

	private AudioSource baseMusicAux, hitMusicAux;
	private float finalVolumeBase, finalVolumeHit;

	private GameObject currentLevel;
	private string nameCurrentLevel = "";


	// Use this for initialization
	void Start () {
		currentLevel = GameObject.Find("LevelManager");
		baseMusic = currentLevel.GetComponent <AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			pauseMenuCanvas.SetActive (true);
		} else {
			pauseMenuCanvas.SetActive (false);
		}
	}

	public void Resume(){
		isPaused = false;
		Time.timeScale = 1f;
		baseMusic.volume = finalVolumeBase;
		hitMusic.volume = finalVolumeHit;
		baseMusic.Play();
		hitMusic.Play ();
		menuMusic.Stop ();
		menuMusicB.Stop ();
	}

	public void Quit(){
		SceneManager.LoadScene (mainMenu);
		Time.timeScale = 1f;
	}

	public void Replay(){
		SceneManager.LoadScene (nameCurrentLevel);
		baseMusic.volume = finalVolumeBase;
		hitMusic.volume = finalVolumeHit;
	}

	public void Settings(){
		isPaused = true;
		Time.timeScale = 0f;
		baseMusic.Pause();
		hitMusic.Pause ();
		menuMusic.volume = baseMusic.volume;
		menuMusic.Play ();
		menuMusicB.Play ();
	}

	public void VolumeControlBase(float volumeControl){
		menuMusic.volume = volumeControl;
		finalVolumeBase = volumeControl;
	}

	public void VolumeControlHit(float volumeControl){
		menuMusicB.volume = volumeControl;
		finalVolumeHit = volumeControl;
	}
}
