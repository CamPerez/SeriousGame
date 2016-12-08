using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Cargamos la siguiente escena
	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}
}
