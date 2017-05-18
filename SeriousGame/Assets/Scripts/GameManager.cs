using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	private string filePath;

	private bool countdownDone;


	// Data in DataBase
	public string playerName = "Camila";
	public bool isAGirl = true;
	public List<LevelData> levels = new List<LevelData>();
	public LevelData lastLevelPlayed = new LevelData();

	void Awake () {
		filePath = Application.persistentDataPath + "/data.dat";
		Debug.Log (filePath);
		if(gameManager == null){
			gameManager = this;
			DontDestroyOnLoad (gameObject);
		}else if(gameManager != this){
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		LoadData ();
		NotificationCenter.DefaultCenter().AddObserver (this, "SaveData");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SaveData (Notification notification) {
		
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(filePath);

		DataBase data = new DataBase (isAGirl, playerName, levels);

		bf.Serialize (file, data);

		file.Close ();

	}


	void LoadData () {
		if (File.Exists (filePath)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (filePath, FileMode.Open);

			DataBase data = (DataBase)bf.Deserialize (file);

			playerName = data.PlayerName;
			isAGirl = data.IsAGirl;
			levels = data.Levels;

			file.Close ();
		} else {
			playerName = "Camila";
			List<LevelData> levels = new List<LevelData>();
			isAGirl = true;
		}
	}

	public bool CountdownDone {
		get {
			return this.countdownDone;
		}
		set{
			this.countdownDone = value;
		}
	}
		
}

[Serializable]
class DataBase{

	private bool isAGirl = true;
	private string playerName = "Camila";
	private List<LevelData> levels = new List<LevelData>();

	public DataBase(bool isAGirl, string playerName, List<LevelData> levels){
		this.isAGirl = isAGirl;
		this.playerName = playerName;
		this.levels = levels;
	}

	public string PlayerName {
		get {
			return this.playerName;
		}
		set{
			this.playerName = value;
		}
	}

	public bool IsAGirl{
		
		get {
			return this.isAGirl;
		}
		set{
			this.isAGirl = value;
		}
	}

	public List<LevelData> Levels {
		get {
			return this.levels;
		}
		set{
			this.levels = value;
		}
	}
}

[Serializable]
public class LevelData{

	private int levelID;
	private string levelName;
	private string levelCode;
	private string characterName;
	private bool isCompleted;
	private int totalScore;
	private float levelScore;
	private int correctNotes;
	private int totalNotes;
	private int stars;

	public LevelData(){
	}

	public LevelData(int levelID, string levelName, string levelCode, string characterName, bool isCompleted, int totalScore, int levelScore, int totalNotes, int correctNotes, int stars){
		this.levelID = levelID;
		this.levelName = levelName;
		this.levelCode = levelCode;
		this.characterName = characterName;
		this.isCompleted = isCompleted;
		this.totalScore = totalScore;
		this.levelScore = levelScore;
		this.totalNotes = totalNotes;
		this.correctNotes = correctNotes;
		this.stars = stars;
	}

	public int LevelID {
		get {
			return this.levelID;
		}
		set{
			this.levelID = value;
		}
	}

	public string LevelName {
		get {
			return this.levelName;
		}
		set{
			this.levelName = value;
		}
	}

	public string LevelCode {
		get {
			return this.levelCode;
		}
		set{
			this.levelCode = value;
		}
	}

	public string CharacterName {
		get {
			return this.characterName;
		}
		set{
			this.characterName = value;
		}
	}

	public bool IsCompleted {
		get {
			return this.isCompleted;
		}
		set{
			this.isCompleted = value;
		}
	}

	public float LevelScore {
		get {
			return this.levelScore;
		}
		set{
			this.levelScore = value;
		}
	}

	public int TotalScore {
		get {
			return this.totalScore;
		}
		set{
			this.totalScore = value;
		}
	}

	public int CorrectNotes {
		get {
			return this.correctNotes;
		}
		set{
			this.correctNotes = value;
		}
	}

	public int TotalNotes {
		get {
			return this.totalNotes;
		}
		set{
			this.totalNotes = value;
		}
	}

	public int Stars {
		get {
			return this.stars;
		}
		set{
			this.stars = value;
		}
	}

}