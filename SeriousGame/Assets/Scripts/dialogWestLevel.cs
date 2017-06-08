using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class dialogWestLevel : MonoBehaviour {

	[SerializeField]
	private GameObject textObject;
	private Text textComponent;
	[SerializeField]
	private GameObject btnNext;
	[SerializeField]
	private GameObject btnSkip;

	
	[SerializeField]
	private GameObject orc;
	[SerializeField]
	private GameObject rytmus;
	private GameObject player;
	[SerializeField]
	private GameObject characterList;

	private Color orcColor = Color.green;
	private Color playerColor = Color.white;
	private Color rytmusColor = Color.magenta;

	private Animator orcAnimator;
	private Animator playerAnimator;
	private Animator rytmusAnimator;

	private static int counter = 0;

	private string text1 = "¡Qué calor hace aquí! Menos mal que hemos podido distraer al vampiro, pero llevamos horas dando vueltas... ¿Dónde vamos ahora Rytmus?";
	private string text2 = "¡Tú, joven! ¿Dónde están mis diamantes? ¿¡Dónde!?";
	private string text3 = "¡AHHHHHH! ¡Yo no tengo nada!";
	private string text4 = "¡He visto que volaban hacia allí! Necesito mis diamantes...";
	private string text5 = "¡Yo no los tengo, de verdad! ¿Por qué los necesitas?";
	private string text6 = "¡Es mi trabajo recogerlos! Pero vuelan por todas partes y no puedo alcanzarlos... ¡Se van a enfadar conmigo en mi poblado!";
	private string text7 = "Grr... Grr...";
	private string text8 = "Vaya... Tranquilo, no te pongas así, ¡Yo puedo ayudarte!";
	private string text9 = "¿Harías eso por mí?";
	private string text10 = "¡Claro!";
	private string text11 = "Grr... Grr...";
	private string text12 = "¿Qué puedo hacer yo por ti?";
	private string text13 = "No hace falta que hagas nada, pero quizás podrías decirme dónde está el castillo del rey Compás.";
	private string text14 = "Yo no sé llegar hasta allí, nunca he salido de la zona arenosa del reino, pero conozco a alguien que puede llegar a cualquier parte de Armonisia.";
	private string text15 = "¡Genial! ¿Quién es?";
	private string text16 = "Te diré cómo llegar hasta él si consigues antes los diamantes.";
	private string text17 = "Grrr.. Gr...";
	private string text18 = "Trato hecho, ¡Vamos, Rytmus!";

	// If the level was already played, we can skip the animation scene
	void Awake(){
		if(GameManager.gameManager.levels.Count > 2){
			btnSkip.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {
		GetPlayerOptions ();
		counter = 0;
		orcAnimator = orc.GetComponent <Animator> ();
		playerAnimator = player.GetComponent <Animator> ();
		rytmusAnimator = rytmus.GetComponent <Animator> ();
		//"¡Qué calor hace aquí! Menos mal que hemos podido distraer al vampiro, pero llevamos horas dando vueltas... ¿Dónde vamos ahora Rytmus?";
		textComponent = textObject.GetComponent <Text> ();
		playerAnimator.SetBool("isTalking", true);
		StartCoroutine(DialogController.dialogController.ShowText (text1, playerColor, textComponent));
		StartCoroutine(ActiveButton (9));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void StartAnimation (int counter){

		switch (counter)
		{
		//"¡Tú, joven! ¿Dónde están mis diamantes? ¿¡Dónde!?";
		case 1:
			orc.SetActive (true);
			orcAnimator.SetBool ("isStanding", true);
			playerAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool ("isStanding", false);
			playerAnimator.SetBool ("isHit", true);
			StartCoroutine (DialogController.dialogController.ShowText (text2, orcColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"¡AHHHHHH! ¡Yo no tengo nada!";
		case 2:
			orcAnimator.SetBool("isStanding", false);
			orcAnimator.SetBool("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text3, playerColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"¡He visto que volaban hacia allí! Necesito mis diamantes..."
		case 3:
			orcAnimator.SetBool("isStanding", true);
			orcAnimator.SetBool("isAttacking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text4, orcColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"¡Yo no los tengo, de verdad! ¿Por qué los necesitas?";
		case 4:
			orcAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool("isTalking", true);
			playerAnimator.SetBool("isStanding", true);
			playerAnimator.SetBool("isHit", false);
			StartCoroutine(DialogController.dialogController.ShowText (text5, playerColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"¡Es mi trabajo recogerlos! Pero vuelan por todas partes y no puedo alcanzarlos... ¡Se van a enfadar conmigo en mi poblado!"
		case 5:
			playerAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			orcAnimator.SetBool("isStanding", false);
			orcAnimator.SetBool("isAttackingSpecial", true);
			StartCoroutine(DialogController.dialogController.ShowText (text6, orcColor, textComponent));
			StartCoroutine(ActiveButton (8));
			break;
		//"Grr... Grr..."
		case 6:
			rytmusAnimator.SetBool ("isFlying", false);
			rytmusAnimator.SetBool ("isFlyingJump", true);
			StartCoroutine(DialogController.dialogController.ShowText (text7, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"Vaya... Tranquilo, no te pongas así, ¡Yo puedo ayudarte!"
		case 7:
			rytmusAnimator.SetBool ("isFlying", true);
			rytmusAnimator.SetBool ("isFlyingJump", false);
			playerAnimator.SetBool ("isTalking", true);
			playerAnimator.SetBool ("isStanding", false);
			orcAnimator.SetBool("isStanding", true);
			orcAnimator.SetBool("isAttackingSpecial", false);
			StartCoroutine(DialogController.dialogController.ShowText (text8, playerColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"¿Harías eso por mí?";
		case 8:
			playerAnimator.SetBool("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			StartCoroutine(DialogController.dialogController.ShowText (text9, orcColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¡Claro!"
		case 9:
			playerAnimator.SetBool ("isTalking", true);
			playerAnimator.SetBool ("isStanding", false);
			StartCoroutine (DialogController.dialogController.ShowText (text10, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"Grr... Grr..."
		case 10:
			rytmusAnimator.SetBool ("isFlying", false);
			rytmusAnimator.SetBool ("isFlyingJump", true);
			playerAnimator.SetBool("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			StartCoroutine(DialogController.dialogController.ShowText (text11, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"¿Qué puedo hacer a cambio por ti?"
		case 11:
			rytmusAnimator.SetBool ("isFlying", true);
			rytmusAnimator.SetBool ("isFlyingJump", false);
			playerAnimator.SetBool("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			StartCoroutine(DialogController.dialogController.ShowText (text12, orcColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"No hace falta que hagas nada, pero quizás podrías decirme dónde está el castillo del rey Compás."
		case 12:
			playerAnimator.SetBool("isTalking", true);
			playerAnimator.SetBool ("isStanding", false);
			StartCoroutine(DialogController.dialogController.ShowText (text13, playerColor, textComponent));
			StartCoroutine(ActiveButton (6));
			break;
		//"Yo no sé llegar hasta allí, nunca he salido de la zona arenosa del reino, pero conozco a alguien que puede llegar a cualquier parte de Armonisia."
		case 13:
			playerAnimator.SetBool("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			orcAnimator.SetBool("isStanding", false);
			orcAnimator.SetBool("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text14, orcColor, textComponent));
			StartCoroutine(ActiveButton (9));
			break;
		//"¡Genial! ¿Quién es?"
		case 14:
			playerAnimator.SetBool("isStanding", false);
			playerAnimator.SetBool("isJumping", true);
			orcAnimator.SetBool("isStanding", true);
			orcAnimator.SetBool("isAttacking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text15, playerColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"Te diré cómo llegar hasta él si consigues antes los diamantes"
		case 15:
			playerAnimator.SetBool("isStanding", true);
			playerAnimator.SetBool("isJumping", false);
			orcAnimator.SetBool("isStanding", false);
			orcAnimator.SetBool("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text16, orcColor, textComponent));
			StartCoroutine(ActiveButton (4));
			break;
		//"Grrr.. Gr..."
		case 16:
			rytmusAnimator.SetBool ("isFlying", false);
			rytmusAnimator.SetBool ("isFlyingJump", true);
			playerAnimator.SetBool("isStanding", true);
			playerAnimator.SetBool("isJumping", false);
			orcAnimator.SetBool("isStanding", true);
			orcAnimator.SetBool("isAttacking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text17, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"Trato hecho, ¡Vamos, Rytmus!"
		case 17:
			playerAnimator.SetBool("isStanding", false);
			playerAnimator.SetBool("isJumping", true);
			StartCoroutine(DialogController.dialogController.ShowText (text18, playerColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		case 18:
			SceneManager.LoadScene ("WestLevel");
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
