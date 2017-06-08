using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSettings : MonoBehaviour {
	
	private AudioSource mainMusic;
	[SerializeField]
	private GameObject pauseMenuCanvas;
	[SerializeField]
	private Sprite musicCrossSprite;
	[SerializeField]
	private Sprite effectsCrossSprite;
	[SerializeField]
	private Sprite effectSprite;
	[SerializeField]
	private Sprite musicSprite;
	[SerializeField]
	private Image effectObject;
	[SerializeField]
	private Image musicObject;

	private bool settings = true;
	private bool musicCross;
	private bool effectsCross;

	// Use this for initialization
	void Start () {
		musicCross = GameManager.gameManager.musicOn;
		effectsCross = GameManager.gameManager.effectsOn;
		mainMusic = GameObject.Find ("MainMenuMusic").GetComponent <AudioSource>();
		if (musicCross == false) {
			musicObject.sprite = musicCrossSprite;
		} else {
			musicObject.sprite = musicSprite;
		}
		if (effectsCross == false) {
			effectObject.sprite = effectsCrossSprite;
		} else {
			effectObject.sprite = effectSprite;
		}
	}
		
	public void SettingsOnOff(){
		pauseMenuCanvas.SetActive (settings);
		settings = !settings;
		NotificationCenter.DefaultCenter ().PostNotification (this, "SaveData");
	}


	public void BaseMusicOnOff(){
		GameManager.gameManager.musicOn = !GameManager.gameManager.musicOn;
		musicCross = !musicCross;
		if (musicCross == false) {
			musicObject.sprite = musicCrossSprite;
			mainMusic.Stop ();
		} else {
			musicObject.sprite = musicSprite;
			Debug.Log ("la musica es" + mainMusic.name);
			mainMusic.Play ();
		}
	}

	public void EffectMusicOnOff(){
		GameManager.gameManager.effectsOn = !GameManager.gameManager.effectsOn;
		effectsCross = !effectsCross;
		if (effectsCross == false) {
			effectObject.sprite = effectsCrossSprite;
		} else {
			effectObject.sprite = effectSprite;
		}
	}


}
