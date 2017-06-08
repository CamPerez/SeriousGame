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

	[SerializeField]
	private AudioSource baseMusic;
	[SerializeField]
	private AudioSource hitMusic;
	[SerializeField]
	private AudioSource menuMusic;
	[SerializeField]
	private AudioSource menuMusicB;
	[SerializeField]
	private GameObject notesSound;

	private AudioSource baseMusicAux, hitMusicAux;
	private float finalVolumeBase, finalVolumeHit;

	private GameObject currentLevel;
	private string nameCurrentLevel = "";

	private bool musicStarted = false;


	// Use this for initialization
	void Start () {
		currentLevel = GameObject.Find("LevelManager");
		finalVolumeBase = baseMusic.volume;
		finalVolumeHit = hitMusic.volume;
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
		ChangeVolumeNotes ();
		if(musicStarted){
			baseMusic.Play();
		}
		menuMusic.Stop ();
		menuMusicB.Stop ();
		pauseMenuCanvas.SetActive (false);
	}

	public void Quit(){
		SceneManager.LoadScene (mainMenu);
		Time.timeScale = 1f;
	}

	public void Replay(){
		SceneManager.LoadScene (nameCurrentLevel);
		baseMusic.volume = finalVolumeBase;
		hitMusic.volume = finalVolumeHit;
		pauseMenuCanvas.SetActive (false);
	}

	public void Settings(){
		//Game paused
		isPaused = true;
		pauseMenuCanvas.SetActive (true);
		Time.timeScale = 0f;
		//Level music base paused
		if(baseMusic.isPlaying){
			musicStarted = true;
		}
		baseMusic.Pause();
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

	private void ChangeVolumeNotes(){
		foreach(Transform note in notesSound.transform){
			note.gameObject.GetComponent <AudioSource>().volume = finalVolumeHit;
		}
	
	}
}
