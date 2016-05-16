using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public GameObject menuImage;
	public GameObject bgImage;
	public GameObject menuPanel;

	public GridLines gridLines;
	public TextController textController;

	private bool menuUp;
	// Use this for initialization
	void Start () {
		menuPanel = GameObject.Find ("Menu Panel");
		menuImage = GameObject.Find ("Menu Image");
		bgImage = GameObject.Find ("Background");

		//gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLines> ();
		if (!Application.loadedLevelName.Equals ("Mini Golf Editor Tutorial")) {
			textController = GameObject.Find ("Number of Tries").GetComponent<TextController> ();
		}

		menuUp = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Restart") && Application.loadedLevelName.Equals ("Mini Golf Editor Tutorial")) {
			if (menuUp) {
				menuUp = false;

				menuPanel.transform.localScale = new Vector3 (0f, 0f, 0f);
				menuImage.transform.localScale = new Vector3 (0f, 0f, 0f);
				bgImage.transform.localScale = new Vector3 (0f, 0f, 0f);
			}
			else if (!menuUp) {
				menuUp = true;

				menuPanel.transform.localScale = new Vector3 (1f, 1f, 1f);
				menuImage.transform.localScale = new Vector3 (1f, 1f, 1f);
				bgImage.transform.localScale = new Vector3 (1f, 1f, 1f);
			}
		}
		else if (Input.GetButtonUp ("Restart") && !textController.hasWon) {
			if (menuUp) {
				menuUp = false;
				
				menuPanel.transform.localScale = new Vector3 (0f, 0f, 0f);
				menuImage.transform.localScale = new Vector3 (0f, 0f, 0f);
				bgImage.transform.localScale = new Vector3 (0f, 0f, 0f);
			}
			else if (!menuUp) {
				menuUp = true;
				
				menuPanel.transform.localScale = new Vector3 (1f, 1f, 1f);
				menuImage.transform.localScale = new Vector3 (1f, 1f, 1f);
				bgImage.transform.localScale = new Vector3 (1f, 1f, 1f);
			}
		}

		if (!Application.loadedLevelName.Equals ("Mini Golf Editor Tutorial") && textController.hasWon) {
			menuPanel.transform.localScale = new Vector3 (0f, 0f, 0f);
			menuImage.transform.localScale = new Vector3 (0f, 0f, 0f);			
			bgImage.transform.localScale = new Vector3 (0f, 0f, 0f);
		}

		if (menuUp) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1.0f;
		}
	}

	public void RestartLevel () {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void SkipLevel () {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void GoToMainMenu () {
		Application.LoadLevel (0);
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
