using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class dialogSkyLevel : MonoBehaviour {

	[SerializeField]
	private GameObject textObject;
	private Text textComponent;
	[SerializeField]
	private GameObject btnNext;
	[SerializeField]
	private GameObject btnSkip;

	
	[SerializeField]
	private GameObject elf;
	[SerializeField]
	private GameObject rytmus;
	private GameObject player;
	[SerializeField]
	private GameObject characterList;

	private Color elfColor = Color.green;
	private Color playerColor = Color.white;
	private Color rytmusColor = Color.grey;

	private Animator elfAnimator;
	private Animator playerAnimator;
	private Animator rytmusAnimator;

	private static int counter = 0;

	private string text1 = "¡Ahí estás! ¿Eres tú, no? ¡Sí, tienes que ser tú! La persona elegida que ayudará a Armonisia a volver a su alegría de antes... ¡Estoy seguro, eres tú!";
	private string text2 = "¿Cómo? ¿Dónde estoy? ¿Por qué está todo tan oscuro y silencioso? Lo último que recuerdo es quedarme dormido leyendo un libro...";
	private string text3 = "Estás en el reino de Armonisia, pero ya nada es igual. Desde hace tiempo se ha perdido la magia y la alegría.";
	private string text4 = "Nuestro rey ha desaparecido y el ritmo se ha ido por completo de nuestras tierras.";
	private string text5 = "¿Qué significa que el ritmo se ha ido?";
	private string text6 = "Significa que ya no podemos tocar nuestros instrumentos, que el tiempo cambia porque el reloj no se mueve como antes, que el mar no tiene olas... ¡Ayúdanos!, por favor.";
	private string text7 = "¿Cómo os puedo ayudar? Ni siquiera sé donde estoy, no sabría por dónde empezar...";
	private string text8 = "¡Tú vienes de un lugar donde nada de esto pasa! ¡Rytmus te ayudará! Él conoce todos los rincones de Armonisia...";
	private string text9 = "¿Quién es Rytmus?";
	private string text10 = "¡Él es Rytmus! Con él podrás ir a cualquier parte... ¡Buena suerte, Andy!";
	private string text11 = "¡Espera! ¿Cómo sabes mi nombre?";
	private string text12 = "...";
	private string text13 = "Supongo que no tengo otra opción... ¡La aventura nos llama! ¿A dónde vamos primero, Rytmus?";

	// If the level was already played, we can skip the animation scene
	void Awake(){
		if(GameManager.gameManager.levels.Count > 0){
			btnSkip.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {
		GetPlayerOptions ();
		counter = 0;
		elfAnimator = elf.GetComponent <Animator> ();
		playerAnimator = player.GetComponent <Animator> ();
		rytmusAnimator = rytmus.GetComponent <Animator> ();
		textComponent = textObject.GetComponent <Text> ();
		elfAnimator.SetBool("isTalking", true);
		StartCoroutine(DialogController.dialogController.ShowText (text1, elfColor, textComponent));
		StartCoroutine(ActiveButton (9));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void StartAnimation (int counter){

		switch (counter)
		{
		case 1:
			elfAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool ("isTalking", true);
			StartCoroutine (DialogController.dialogController.ShowText (text2, playerColor, textComponent));
			StartCoroutine(ActiveButton (8));
			break;
		case 2:
			playerAnimator.SetBool ("isTalking", false);
			elfAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text3, elfColor, textComponent));
			StartCoroutine(ActiveButton (7));
			break;
		case 3:
			StartCoroutine(DialogController.dialogController.ShowText (text4, elfColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		case 4:
			elfAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text5, playerColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		case 5:
			playerAnimator.SetBool ("isTalking", false);
			elfAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text6, elfColor, textComponent));
			StartCoroutine(ActiveButton (11));
			break;
		case 6:
			elfAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text7, playerColor, textComponent));
			StartCoroutine(ActiveButton (6));
			break;
		case 7:
			playerAnimator.SetBool ("isTalking", false);
			elfAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text8, elfColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		case 8:
			elfAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text9, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		case 9:
			playerAnimator.SetBool ("isTalking", false);
			elfAnimator.SetBool ("isTalking", true);
			StartCoroutine (DialogController.dialogController.ShowText (text10, elfColor, textComponent));
			rytmus.SetActive (true);
			rytmusAnimator.SetBool ("isRunningX", true);
			StartCoroutine(ActiveButton (4));
			break;
		case 10:
			elfAnimator.SetBool ("isTalking", false);
			elfAnimator.SetBool ("isRunningMoveX", true);
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text11, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		case 11:
			playerAnimator.SetBool("isTalking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text12, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		case 12:
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text13, playerColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		case 13:
			SceneManager.LoadScene ("SkyLevel");
			break;
		default: 
			StartCoroutine (DialogController.dialogController.ShowText ("ERROR", playerColor, textComponent));
			break;
		}

	}

	public void NextTextDialog(){
		counter++;
		StartAnimation (counter);
	}

	private void GetPlayerOptions(){
		int index = PlayerPrefs.GetInt ("MainCharacterSelected");
		player = characterList.transform.GetChild(index).gameObject;
		player.SetActive (true);
	}

	private IEnumerator ActiveButton(int wait){
		btnNext.SetActive (false);
		yield return new WaitForSeconds (wait);
		btnNext.SetActive (true);
	}
}
