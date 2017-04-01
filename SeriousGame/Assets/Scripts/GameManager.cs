using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager gameManager;

	private string filePath;

	// Data in DataBase
	public string playerName = "Camila";
	public List<LevelData> levels = new List<LevelData>();
	public LevelData lastLevelPlayed;

	void Awake () {
		filePath = Application.persistentDataPath + "/data.dat";
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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SaveData () {

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create(filePath);

		DataBase data = new DataBase (playerName, levels);

		bf.Serialize (file, data);

		file.Close ();

	}

	void LoadData () {
		if (File.Exists (filePath)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (filePath, FileMode.Open);

			DataBase data = (DataBase)bf.Deserialize (file);

			playerName = data.PlayerName;
			levels = data.Levels;

			file.Close ();
		} else {
			playerName = "Camila";
			List<LevelData> levels = new List<LevelData>();
		}
	}
		
}

[Serializable]
class DataBase{

	private string playerName = "Camila";
	private List<LevelData> levels = new List<LevelData>();

	public DataBase(string playerName, List<LevelData> levels){
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

	public List<LevelData> Levels {
		get {
			return this.levels;
		}
		set{
			this.levels = value;
		}
	}
}


public class LevelData{

	private string levelName;
	private string levelCode;
	private string characterName;
	private bool isCompleted;
	private int totalScore;
	private float levelScore;
	private int correctNotes;
	private int totalNotes;
	private int stars;

	public LevelData(string levelName, string levelCode, string characterName, bool isCompleted, int totalScore, int levelScore, int totalNotes, int correctNotes, int stars){
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