using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransistionController : MonoBehaviour {

	public Text loadingText;
	public Text pressEnterToStart;

	private float loadingTimer;

	// Use this for initialization
	void Start () {
		loadingText = GameObject.Find ("... (Loading)").GetComponent<Text> ();
		pressEnterToStart = GameObject.Find ("Press Enter").GetComponent<Text> ();

		loadingText.text = "";
		pressEnterToStart.text = "";

		loadingTimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		loadingTimer += Time.deltaTime;
		if (loadingTimer >= 5f) {
			loadingText.text = "";
			pressEnterToStart.text = "Press Enter To Start";

			if (Input.GetButtonUp ("Next")) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
		}
		else if (loadingTimer >= 1f) {
			loadingText.text = "Loading...";
		}
	}
}
