using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class dialogCemeteryLevel : MonoBehaviour {

	[SerializeField]
	private GameObject textObject;
	private Text textComponent;
	[SerializeField]
	private GameObject btnNext;
	[SerializeField]
	private GameObject btnSkip;

	
	[SerializeField]
	private GameObject skeleton;
	[SerializeField]
	private GameObject rytmus;
	private GameObject player;
	[SerializeField]
	private GameObject characterList;

	private Color skeletonColor = Color.cyan;
	private Color playerColor = Color.white;
	private Color rytmusColor = Color.magenta;

	private Animator skeletonAnimator;
	private Animator playerAnimator;
	private Animator rytmusAnimator;

	private static int counter = 0;

	private string text1 = "¿Dónde me has traido Rytmus? ¿Y por qué se ha hecho de noche tan rápido? Este lugar da un poco de miedo...";
	private string text2 = "Gr... Grr... Gr...";
	private string text3 = "¿Qué significa eso?";
	private string text4 = "...";
	private string text5 = "¿¡Qué es ese ruido!?";
	private string text6 = "Gr...";
	private string text7 = "¡AAAAAHHHHH!";
	private string text8 = "¡Shhh! ¡No hace falta que grites! ¿Por qué siempre se asustan de mí?";
	private string text9 = "¿Que por qué se asustan? ¡Has salido del suelo y llevas una espada en la mano!";
	private string text10 = "¿De dónde voy a salir sino? ¡Oh! ¡Hola Rytmus! ";
	private string text11 = "Gr... Gr...";
	private string text12 = "¿Conoces a Rytmus?";
	private string text13 = "¡Claro! Rytmus y yo nos conocemos desde que yo era un mini esqueleto y desde que él salió de su cascarón.";
	private string text14 = "Vaya... Entonces supongo que me puedo fiar de ti.";
	private string text15 = "¡Pues claro! Soy Huesitos, ¿y tú?";
	private string text16 = "Me llamo " + GameManager.gameManager.playerName +" y la verdad es que no tengo muy claro que hago aquí... Solo sé que un elfo me ha dicho que he de ayudar a recuperar el ritmo a Armonisia.";
	private string text17 = "¿Tú eres " + GameManager.gameManager.playerName +" ? ¡Por fin! Hace tiempo que esperamos que vinieras para ayudarnos. ¿Así que Rytmus te está llevando al castillo?"; 
	private string text18 = "No tengo muy claro dónde estamos yendo... ¿Cuál es ese castillo del que hablas?";
	private string text19 = "¡El castillo del rey Compás, por supuesto! Ha desaparecido y el ritmo se ha ido, ¡tienes que ir hasta allí para buscar pistas y encontrarlo!";
	private string text20 = "Grr... Grr...¡Gr...!";
	private string text21 = "Oh, tienes razón Rytmus... ¡No podréis pasar si Colmillos sigue despierto!";
	private string text22 = "¿Colmillos? ¿Quién es ese?";
	private string text23 = "Un vampiro no muy amigable cuando le molestan... Y sin ritmo, el día y la noche cambian sin parar y hace que esté de peor humor...";
	private string text24 = "¡Seguro que si le explicamos porque tenemos que pasar nos dejará ir sin ningún problema!";
	private string text25 = "Con el humor que tiene ahora mismo no creo que se pare a escucharos..."; 
	private string text26 = "¡Grr!";
	private string text27 = "¡Buena idea Rytmus, podemos ahuyentarlo con ajos, así seguro que se esconderá y tendréis tiempo de pasar!";
	// If the level was already played, we can skip the animation scene
	void Awake(){
		if(GameManager.gameManager.levels.Count > 1){
			btnSkip.SetActive (true);
		} 
	}

	// Use this for initialization
	void Start () {
		GetPlayerOptions ();
		counter = 0;
		skeletonAnimator = skeleton.GetComponent <Animator> ();
		playerAnimator = player.GetComponent <Animator> ();
		rytmusAnimator = rytmus.GetComponent <Animator> ();
		textComponent = textObject.GetComponent <Text> ();
		skeleton.SetActive (false);
		//"¿Dónde me has traido Rytmus? ¿Y por qué se ha hecho de noche tan rápido? Este lugar da un poco de miedo...";
		playerAnimator.SetBool ("isTalking", true);
		rytmusAnimator.SetBool ("isFlying", false);
		rytmusAnimator.SetBool ("isStanding", true);
		StartCoroutine(DialogController.dialogController.ShowText (text1, playerColor, textComponent));
		StartCoroutine(ActiveButton (7));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void StartAnimation (int counter){

		switch (counter)
		{
		//"Gr..."
		case 1:
			playerAnimator.SetBool ("isTalking", false);
			playerAnimator.SetBool ("isStanding", true);
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isStanding", false);
			StartCoroutine (DialogController.dialogController.ShowText (text2, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¿Qué significa eso?"
		case 2:
			playerAnimator.SetBool ("isTalking", true);
			rytmusAnimator.SetBool("isJumping", false);
			rytmusAnimator.SetBool("isStanding", true);
			StartCoroutine(DialogController.dialogController.ShowText (text3, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"..."
		case 3:
			playerAnimator.SetBool ("isTalking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text4, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¿¡Qué es ese ruido!?"
		case 4:
			playerAnimator.SetBool ("isTalking", true);
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isStanding", false);
			StartCoroutine(DialogController.dialogController.ShowText (text5, playerColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"Gr..."
		case 5:
			playerAnimator.SetBool ("isTalking", false);
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isStanding", false);
			StartCoroutine(DialogController.dialogController.ShowText (text6, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¡AAAAAHHHHH!"
		case 6:
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isStanding", true);
			playerAnimator.SetBool ("isStanding", false);
			playerAnimator.SetBool("isHit", true);
			skeleton.SetActive (true);
			skeletonAnimator.SetBool ("isStanding", true);
			skeletonAnimator.SetBool ("isAppearing", false);
			StartCoroutine(DialogController.dialogController.ShowText (text7, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¡Shhh! ¡No hace falta que grites! ¿Por qué siempre se asustan de mí?"
		case 7:
			skeletonAnimator.SetBool ("isStanding", false);
			skeletonAnimator.SetBool ("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text8, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		//"¿Que por qué se asustan? ¡Has salido del suelo y llevas una espada en la mano!"
		case 8:
			skeletonAnimator.SetBool ("isStanding", true);
			skeletonAnimator.SetBool ("isAttacking", false);
			playerAnimator.SetBool("isTalking", true);
			playerAnimator.SetBool("isHit", false);
			StartCoroutine(DialogController.dialogController.ShowText (text9, playerColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		//"¿De dónde voy a salir sino? ¡Oh! ¡Hola Rytmus! "
		case 9:
			playerAnimator.SetBool ("isTalking", false);
			skeletonAnimator.SetBool ("isStanding", true);
			rytmusAnimator.SetBool ("isStanding", false);
			rytmusAnimator.SetBool ("isFlying", true);
			StartCoroutine (DialogController.dialogController.ShowText (text10, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"Gr... Gr..."
		case 10:
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isFlying", false);
			StartCoroutine(DialogController.dialogController.ShowText (text11, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¿Conoces a Rytmus?"
		case 11:
			playerAnimator.SetBool("isTalking", true);
			playerAnimator.SetBool("isStanding", true);
			playerAnimator.SetBool("isHit", false);
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isFlying", true);
			StartCoroutine(DialogController.dialogController.ShowText (text12, playerColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¡Claro! Rytmus y yo nos conocemos desde que yo era un mini esqueleto y desde que él salió de su cascarón."
		case 12:
			playerAnimator.SetBool("isTalking", false);
			rytmusAnimator.SetBool ("isStanding", true);
			rytmusAnimator.SetBool ("isFlying", false);
			StartCoroutine(DialogController.dialogController.ShowText (text13, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (6));
			break;
		//"Vaya... Entonces supongo que me puedo fiar de ti.
		case 13:
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text14, playerColor, textComponent));
			StartCoroutine(ActiveButton (3));
			break;
		//"¡Pues claro! Soy Huesitos,¿y tú?"
		case 14:
			playerAnimator.SetBool("isTalking", false);
			skeletonAnimator.SetBool ("isStanding", false);
			skeletonAnimator.SetBool ("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text15, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"Me llamo Andy y la verdad es que no tengo muy claro que hago aquí... Solo sé que un elfo me ha dicho que he de ayudar a recuperar el ritmo a Armonisia."
		case 15:
			skeletonAnimator.SetBool ("isStanding", true);
			skeletonAnimator.SetBool ("isAttacking", false);
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text16, playerColor, textComponent));
			StartCoroutine(ActiveButton (9));
			break;
		//"¿Tú eres Andy? ¡Por fin! Hace tiempo que esperamos que vinieras para ayudarnos. ¿Así que Rytmus te está llevando al castillo?"
		case 16:
			playerAnimator.SetBool("isTalking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text17, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (7));
			break;
		//"No tengo muy claro dónde estamos yendo... ¿Cuál es ese castillo del que hablas?"
		case 17:
			playerAnimator.SetBool("isTalking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text18, playerColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		//"¡El castillo del rey Compás, por supuesto! Ha desaparecido y el ritmo se ha ido, ¡tienes que ir hasta allí para buscar pistas y encontrarlo!"
		case 18:
			playerAnimator.SetBool("isTalking", false);
			skeletonAnimator.SetBool ("isStanding", false);
			skeletonAnimator.SetBool ("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text19, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (9));
			break;
		//"Grr... Grr...¡Gr...!"
		case 19:
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isStanding", false);
			skeletonAnimator.SetBool ("isStanding", true);
			skeletonAnimator.SetBool ("isAttacking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text20, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"Oh, tienes razón Rytmus... ¡No podréis pasar si Colmillos sigue despierto!"
		case 20:
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isStanding", false);
			rytmusAnimator.SetBool ("isHit", true);
			StartCoroutine(DialogController.dialogController.ShowText (text21, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (6));
			break;
		//"¿Colmillos? ¿Quién es ese?"
		case 21:
			playerAnimator.SetBool("isTalking", true);
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isStanding", true);
			rytmusAnimator.SetBool ("isHit", false);
			StartCoroutine(DialogController.dialogController.ShowText (text22, playerColor, textComponent));
			StartCoroutine(ActiveButton (2));
			break;
		//"Un vampiro no muy amigable cuando le molestan... Y sin ritmo, el día y la noche cambian sin parar y esto solo hace que esté de pero humor..."
		case 22:
			playerAnimator.SetBool("isTalking", true);
			skeletonAnimator.SetBool ("isStanding", false);
			skeletonAnimator.SetBool ("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text23, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (9));
			break;
		//"¡Seguro que si le explicamos porque tenemos que pasar nos dejará ir sin ningún problema!"
		case 23:
			playerAnimator.SetBool("isTalking", false);
			playerAnimator.SetBool("isStanding", true);
			playerAnimator.SetBool("isHit", true);
			skeletonAnimator.SetBool ("isStanding", true);
			skeletonAnimator.SetBool ("isAttacking", false);
			StartCoroutine(DialogController.dialogController.ShowText (text24, playerColor, textComponent));
			StartCoroutine(ActiveButton (5));
			break;
		//"Con el humor que tiene ahora mismo no creo que se pare a escucharos...";
		case 24:
			playerAnimator.SetBool("isHit", false);
			playerAnimator.SetBool("isStanding", true);
			rytmusAnimator.SetBool ("isFlying", true);
			rytmusAnimator.SetBool ("isStanding", false);
			StartCoroutine(DialogController.dialogController.ShowText (text25, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (4));
			break;
		//"¡Grr!"
		case 25:
			rytmusAnimator.SetBool ("isJumping", true);
			rytmusAnimator.SetBool ("isStanding", false);
			StartCoroutine(DialogController.dialogController.ShowText (text26, rytmusColor, textComponent));
			StartCoroutine(ActiveButton (1));
			break;
		//"¡Buena idea Rytmus, podemos ahuyentarlo con ajos, así seguro que se esconderá y tendréis tiempo de pasar!"
		case 26:
			rytmusAnimator.SetBool ("isJumping", false);
			rytmusAnimator.SetBool ("isStanding", true);
			skeletonAnimator.SetBool ("isStanding", false);
			skeletonAnimator.SetBool ("isAttacking", true);
			StartCoroutine(DialogController.dialogController.ShowText (text27, skeletonColor, textComponent));
			StartCoroutine(ActiveButton (6));
			break;
		case 27:
			SceneManager.LoadScene ("CemeteryLevel");
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
