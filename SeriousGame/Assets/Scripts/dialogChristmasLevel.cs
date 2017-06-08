using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class dialogChristmasLevel : MonoBehaviour {

	[SerializeField]
	private GameObject textObject;
	private Text textComponent;
	[SerializeField]
	private GameObject btnNext;
	[SerializeField]
	private GameObject btnSkip;

	
	[SerializeField]
	private GameObject santaClaus;
	private AudioSource santaClausLaugh;
	[SerializeField]
	private GameObject rytmus;
	private GameObject player;
	[SerializeField]
	private GameObject characterList;

	private Color santaClausColor = Color.red;
	private Color playerColor = Color.white;
	private Color rytmusColor = Color.magenta;

	private Animator santaClausAnimator;
	private Animator playerAnimator;
	private Animator rytmusAnimator;

	private static int counter = 0;

	private string text1 = "¡Santa Claus!";
	private string text2 = "¡Jojojo! Así me llaman. Hola " + GameManager.gameManager.playerName +" , te estaba esperando, me han dicho que necesitáis mi ayuda, ¡Jojojo!";
	private string text3 = "Grr.. Grr..";
	private string text4 = "¡Hola Rytmus! Jojojo, ¿Te has portado bien éste año?";
	private string text5 = "Gr...";
	private string text6 = "Santa Claus, necesitamos llegar al castillo del rey Compás. ¿Podrías ayudarnos?";
	private string text7 = "Me encantaría ayudaros, pero antes tengo que recoger todos los regalos... ¡Se están escapando de mi saco!";
	private string text8 = "¿Cómo que se están escapando?";
	private string text9 = "Desde que ha desaparecido el rey, todo está descontrolado...";
	private string text10 = "Gr... Gr...";
	private string text11 = "¡Nosotros te ayudaremos Santa Claus!";
	private string text12 = "¡Jojojo! ¡Muchas gracias " + GameManager.gameManager.playerName +"!";

	// If the level was already played, we can skip the animation scene
	void Awake(){
		if(GameManager.gameManager.levels.Count > 3){
			btnSkip.SetActive (true);
		} 
	}

	// Use this for initialization
	void Start () {
		santaClausLaugh = this.GetComponent <AudioSource> ();
		GetPlayerOptions ();
		counter = 0;
		santaClausAnimator = santaClaus.GetComponent <Animator> ();
		playerAnimator = player.GetComponent <Animator> ();
		rytmusAnimator = rytmus.GetComponent <Animator> ();
		textComponent = textObject.GetComponent <Text> ();
		//"¡Santa Claus!"
		rytmusAnimator.SetBool ("isFlying", false);
		rytmusAnimator.SetBool ("isStanding", true);
		playerAnimator.SetBool ("isTalking", true);
		playerAnimator.SetBool ("isStanding", false);
		StartCoroutine(DialogController.dialogController.ShowText (text1, playerColor, textComponent));
		StartCoroutine(ActiveButton (2));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void StartAnimation (int counter){

		switch (counter)
		{
		//"¡Jojojo! Así me llaman. Hola Andy, te estaba esperando, me han dicho que necesitáis mi ayuda, ¡Jojojo!"
		case 1:
			santaClausLaugh.Play ();
			playerAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			santaClausAnimator.SetBool ("isStanding", false);
			santaClausAnimator.SetBool ("isJumping", true);
			StartCoroutine(DialogController.dialogController.ShowText (text2, santaClausColor, textComponent));
			StartCoroutine(ActiveButton (7));
			break;
		//"Grr.. Grr.."
		case 2:
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isStanding", false);
			santaClausAnimator.SetBool ("isStanding", true);
			santaClausAnimator.SetBool ("isJumping", false);
			StartCoroutine(DialogController.dialogController.ShowText (text3, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¡Hola Rytmus! Jojojo, ¿Te has portado bien éste año?"
		case 3:
			santaClausLaugh.Play ();
			StartCoroutine(DialogController.dialogController.ShowText (text4, santaClausColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"Gr..."
		case 4:
			santaClausAnimator.SetBool ("isStanding", true);
			santaClausAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isFlying", true);
			StartCoroutine(DialogController.dialogController.ShowText (text5, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"Santa Claus, necesitamos llegar al castillo del rey Compás. ¿Podrías ayudarnos?";
		case 5:
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isStanding", true);
			playerAnimator.SetBool ("isStanding", false);
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text6, playerColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		//"Me encantaría ayudaros, pero antes tengo que recoger todos los regalos... ¡Se están escapando de mi saco!"
		case 6:
			playerAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			StartCoroutine(DialogController.dialogController.ShowText (text7, santaClausColor, textComponent));
			StartCoroutine(ActiveButton (6));
			break;
		//"¿Cómo que se están escapando?"
		case 7:
			playerAnimator.SetBool("isTalking", true);
			playerAnimator.SetBool("isHit", false);
			StartCoroutine(DialogController.dialogController.ShowText (text8, playerColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"Desde que ha desaparecido el rey, todo está descontrolado..."
		case 8:
			playerAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			StartCoroutine (DialogController.dialogController.ShowText (text9, santaClausColor, textComponent));
			StartCoroutine(ActiveButton (4));
			break;
		//"Gr... Gr..."
		case 9:
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isStanding", false);
			StartCoroutine(DialogController.dialogController.ShowText (text10, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¡Nosotros te ayudaremos Santa Claus!"
		case 10:
			playerAnimator.SetBool("isJumping", true);
			playerAnimator.SetBool("isStanding", false);
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isFlying", true);
			StartCoroutine(DialogController.dialogController.ShowText (text11, playerColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"¡Jojojo! ¡Muchas gracias Andy!"
		case 11:
			santaClausLaugh.Play ();
			playerAnimator.SetBool("isTalking", false);
			playerAnimator.SetBool("isJumping", false);
			playerAnimator.SetBool("isStanding", true);
			rytmusAnimator.SetBool ("isStanding", true);
			rytmusAnimator.SetBool ("isFlying", false);
			santaClausAnimator.SetBool ("isStanding", false);
			santaClausAnimator.SetBool ("isJumping", true);
			StartCoroutine(DialogController.dialogController.ShowText (text12, santaClausColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"Vaya... Entonces supongo que me puedo fiar de ti.
		case 12:
			SceneManager.LoadScene ("ChristmasLevel");
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
