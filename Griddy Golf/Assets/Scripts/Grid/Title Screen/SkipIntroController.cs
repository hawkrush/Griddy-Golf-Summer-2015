using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkipIntroController : MonoBehaviour {

	public BallControllerTitle ballController;
	public AudioSource bgSound;
	public Animator titleScreenAnimation;

	public Text titleText;
	public Button tutorialBtn;
	public Button quitBtn;
	public Button level01Btn;
	public Button level02Btn;
	public Button level03Btn;

	public bool skipIntro;
	// Use this for initialization
	void Start () {
		ballController = GameObject.Find ("Release Ball").GetComponent<BallControllerTitle> ();
		bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
		titleScreenAnimation = GameObject.Find ("Canvas").GetComponent<Animator> ();

		titleText = GameObject.Find ("Title Text").GetComponent<Text> ();
		tutorialBtn = GameObject.Find ("Tutorial Button").GetComponent<Button> ();
		quitBtn = GameObject.Find ("Quit Button").GetComponent<Button> ();
		level01Btn = GameObject.Find ("Level 01 Button").GetComponent<Button> ();
		level02Btn = GameObject.Find ("Level 02 Button").GetComponent<Button> ();
		level03Btn = GameObject.Find ("Level 03 Button").GetComponent<Button> ();

		skipIntro = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Restart")) {
			skipIntro = true;

			bgSound.Play ();

			if (ballController.releaseBall) {
				ballController.DestroyBall ();
			}

			titleScreenAnimation.SetTrigger ("SkipTitleScreenIntro");
		}

		if (skipIntro) {
			titleText.rectTransform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			tutorialBtn.transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);
			quitBtn.transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);
			level01Btn.transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);
			level02Btn.transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);
			level03Btn.transform.localScale = new Vector3 (2.0f, 2.0f, 1.0f);
		}
	}
}
