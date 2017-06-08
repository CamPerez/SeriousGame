using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class NameSelector : MonoBehaviour {

	[SerializeField]
	private InputField inputField;

	[SerializeField]
	private Button startButton;

	private string name = "";

	void Awake(){
		startButton.interactable = false;
	}

	public void GetInput(string nameInput){
		name = nameInput;
		startButton.interactable = true;
	}

	public void LoadScene(){
		GameManager.gameManager.playerName = name;	
		SceneManager.LoadScene ("dialogSkyScene");
	}
}
