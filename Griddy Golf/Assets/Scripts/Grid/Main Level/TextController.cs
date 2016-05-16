using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	
	public Text numOfMoves;
	public Text time;
	public Text maxNumOfTriangles;
	//public GameObject endLevelSplat;
	//public Text endLevelTries;
	//public Text endLevelTime;
	//public Animator endSplatAnimation;
	
	public int movesDone;
	public bool hasWon;

	public int minutes, tensSeconds, onesSeconds;
	private float seconds;

	public int numOfTimesSetText;

	// Use this for initialization
	void Start () {
		//endSplatAnimation = GetComponent<Animator> ();
		movesDone = 0;
		hasWon = false;

		seconds = -1f;
		minutes = 0;
		tensSeconds = 0;
		onesSeconds = 0;

		numOfTimesSetText = 0;

		SetText ();
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasWon) {
			seconds += Time.unscaledDeltaTime;

			if (seconds >= 1f) {
				onesSeconds += 1;
				seconds = 0f;
			}
			if (onesSeconds == 10) {
				tensSeconds += 1;
				onesSeconds = 0;

			}
			if (tensSeconds == 6) {
				tensSeconds = 0;
				minutes += 1;
			}

			SetTime ();

		}

	}

	public void SetText () { 
		movesDone += 1;
		if (numOfTimesSetText == 2) {
			movesDone -= 1;
		}
		numOfMoves.text = "NUMBER OF TRIES: " + movesDone.ToString ();
		maxNumOfTriangles.text = "MAX TRIANGLES: " + (GameObject.Find ("CreateDots").GetComponent<TriangleController> ().maxNumOfGridDots / 3).ToString ();
	}

	void SetTime () {
		time.text = "TIME: " + minutes.ToString () + ":" + tensSeconds.ToString () + onesSeconds.ToString ();
	}
}
