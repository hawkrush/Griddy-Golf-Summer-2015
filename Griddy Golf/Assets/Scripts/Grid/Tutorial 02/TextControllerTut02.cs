using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextControllerTut02 : MonoBehaviour {

	public Text numOfMoves;
	public Text time;
	
	public int movesDone;
	public bool hasWon;
	
	private int minutes, tensSeconds, onesSeconds;
	private float seconds;

	// Use this for initialization
	void Start () {
		movesDone = 0;
		hasWon = false;
		
		seconds = -1f;
		minutes = 0;
		tensSeconds = 0;
		onesSeconds = 0;
		
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
		numOfMoves.text = "NUMBER OF TRIES: " + movesDone.ToString ();
		
	}
	
	void SetTime () {
		time.text = "TIME: " + minutes.ToString () + ":" + tensSeconds.ToString () + onesSeconds.ToString ();
	}
}
