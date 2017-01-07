using UnityEngine;
using System.Collections;

public class SkyLevel : MonoBehaviour {

	private GameObject Rytmus;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rytmus = GameObject.Find("Rytmus");
		animator = Rytmus.GetComponent <Animator> ();
		animator.SetBool("isFlying", true);
		NotificationCenter.DefaultCenter().AddObserver (this, "NoteFailed");
		NotificationCenter.DefaultCenter().AddObserver (this, "NotePressedCorrectly");
		NotificationCenter.DefaultCenter().AddObserver (this, "PointsIncresed");
	}
	
	// Update is called once per frame
	void Update () {


	}

	void NoteFailed(Notification notification){
		animator.SetBool("isFlyingHit",true);
		animator.SetBool("isFlying",false);
		animator.SetBool("isFlyingJump",false);
	}

	void NotePressedCorrectly(Notification notification){
		animator.SetBool("isFlying",true);
		animator.SetBool("isFlyingHit",false);
		animator.SetBool("isFlyingJump",false);
	}

	void PointsIncresed(Notification notification){
		animator.SetBool("isFlyingJump",true);
		animator.SetBool("isFlying",false);
		animator.SetBool("isFlyingHit",false);
	}
		
}
