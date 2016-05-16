using UnityEngine;
using System.Collections;

public class TileControllerTitle : MonoBehaviour {

	public BallControllerTitle ballController;
	public Animator titleScreenAnimation;
	public SkipIntroController skipIntro;

	//public AudioSource tileSound;
	public AudioSource winSound;
	public AudioSource bgSound;

	private bool startTitleScreen;
	private float animationTimer;
	// Use this for initialization
	void Start () {
		bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
		titleScreenAnimation = GameObject.Find ("Canvas").GetComponent<Animator> ();
		skipIntro = GameObject.Find ("Canvas").GetComponent<SkipIntroController> ();

		startTitleScreen = false;
		animationTimer = 0f;
	}


	//Update is called once per frame
	void Update () {
		if (startTitleScreen) {
			animationTimer += Time.deltaTime;
			if (animationTimer >= 3f) {
				bgSound.Play ();
				startTitleScreen = false;
				
			}
		}
	
	}


	void OnTriggerEnter (Collider other) {
		if (!skipIntro.skipIntro) {
			titleScreenAnimation.SetTrigger ("StartTitleScreen");
			if (other.CompareTag ("Ball") && this.CompareTag ("End Point")) {
				//bgSound.Stop ();
				//textController.hasWon = true;
				ballController.DestroyBall ();
				//titleScreenAnimation.SetTrigger ("StartTitleScreen");
				winSound = GameObject.Find ("End").GetComponent<AudioSource> ();
				winSound.Play ();
				startTitleScreen = true;
				//Animate

				//Debug.Log ("WIN");
				//winLevelController.AnimateEndSplat ();
				
				//tutorialCtrl1.startPart4 = false;
				//tutorialCtrl1.TutorialPart4 ();
			}
		}
	}
}
