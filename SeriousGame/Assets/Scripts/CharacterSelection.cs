using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {

	private GameObject[] characterList;
	private int index;

	void Awake(){

	}

	void Start () {
		
		index = PlayerPrefs.GetInt ("MainCharacterSelected");

		// List with all the possible main characters
		characterList = new GameObject[transform.childCount];

		for(int i = 0; i < transform.childCount; i++){
			characterList[i] = transform.GetChild(i).gameObject;
		}

		// All characters hidden
		foreach(GameObject go in characterList){
			go.SetActive (false);
		}

		// We toggle on the selected character
		if (characterList[index]) {
			characterList[index].SetActive (true);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleLeft(){

		// Toggle off the current model
		characterList[index].SetActive (false);

		index--; 
		if(index < 0){
			index = characterList.Length - 1;
		}

		// Toggle on the new model
		characterList[index].SetActive (true);
		SetMainCharacter ();
	}

	public void ToggleRight(){

		// Toggle off the current model
		characterList[index].SetActive (false);

		index++; 
		if(index == characterList.Length){
			index = 0;
		}

		// Toggle on the new model
		characterList[index].SetActive (true);
		SetMainCharacter ();
	}

	public void SetMainCharacter(){
		PlayerPrefs.SetInt ("MainCharacterSelected", index);
		if (index == 0) {
			GameManager.gameManager.isAGirl = true;
		} else {
			GameManager.gameManager.isAGirl = false;
		} 
	}
}
