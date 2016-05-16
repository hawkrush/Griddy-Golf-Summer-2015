using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLevelController : MonoBehaviour {

	public TextController textController;
	public Animator endSplatAnimation;
	public Button releaseButton;

	public Text playerNumOfTries;
	public Text playerTime;
	public Text pressEnter;
	public Text pressEsc;

	private float timerDelay;
	private float timerLimit;
	private string pressEnterMessage;
	private string pressEscMessage;
	// Use this for initialization
	void Start () {
		textController = GameObject.Find ("Number of Tries").GetComponent<TextController> ();
		endSplatAnimation = GetComponent<Animator> ();

		playerNumOfTries = GameObject.Find ("EndSplatTextActualNumOfTries").GetComponent<Text> ();
		playerTime = GameObject.Find ("EndSplatTextActualTime").GetComponent<Text> ();
		pressEnter = GameObject.Find ("Press Enter To Continue").GetComponent<Text> ();
		pressEsc = GameObject.Find ("Press Esc To Restart").GetComponent<Text> ();

		releaseButton = GameObject.Find ("Release Button").GetComponent<Button> ();

		pressEnterMessage = pressEnter.text.ToString ();
		pressEscMessage = pressEsc.text.ToString ();

		playerNumOfTries.text = "";
		playerTime.text = "";
		pressEnter.text = "";
		pressEsc.text = "";

		timerDelay = 0;
		timerLimit = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		if (textController.hasWon) {
			//releaseButton.gameObject.SetActive (false);
			playerNumOfTries.text = textController.movesDone.ToString ();
			playerTime.text = textController.minutes.ToString () + ":" + textController.tensSeconds.ToString () + textController.onesSeconds.ToString ();
			timerDelay += Time.deltaTime;
			if (timerDelay > timerLimit) {
				pressEnter.text = pressEnterMessage;
				pressEsc.text = pressEscMessage;
				if (Input.GetButtonUp ("Restart")) {
					Application.LoadLevel (Application.loadedLevel);
				}
				if (Input.GetButtonUp ("Next")) {
					if (Application.loadedLevelName.Equals ("Mini Golf Editor 04.02")) {
						Application.LoadLevel (0);
					}
					else {
						Application.LoadLevel (Application.loadedLevel + 1);
					}
				}
			}
		}
	}

	public void AnimateEndSplat () {
		endSplatAnimation.SetTrigger ("StartEndSplat");
		releaseButton.gameObject.SetActive (false);
	}
}
