using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridLines : MonoBehaviour {
	
	public LineRenderer lineRenderer;
	public GameObject point1, point2;
	public TriangleController triangleController;
	public AudioSource gridSound;
	public TextController textController;
	//public Button editButton;
	public TileController tileController;

	public LineRenderer gridLine;
	public bool linesDrawn;
	public bool stopTime;
	public bool specialOccasion;

	private bool controlLines;

	//public static bool overallLinesDrawn;
	//public static bool overallStopTime;
	public static int numOfGridLines;
	// Use this for initialization

	void Start () {
		gridSound = GameObject.Find ("Dots For Horizontal Grid Line").GetComponent<AudioSource> ();
		textController = GameObject.Find ("Number of Tries").GetComponent<TextController> ();
		//myEventSystem = GameObject.Find ("EventSystem");
		//editButton = GameObject.Find ("Edit Button").GetComponent<Button> ();
		tileController = GameObject.Find ("Tile 1").GetComponent<TileController> ();

		linesDrawn = false;
		stopTime = false;
		controlLines = false;
		specialOccasion = false;

		//overallLinesDrawn = false;
		//overallStopTime = false;

		numOfGridLines = 0;

		lineRenderer = GameObject.Find ("GridLineRenderer").GetComponent<LineRenderer> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleController> ();
		//tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl3> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Tutorial stuff
		//Input.GetButtonUp ("Interact")

		if (Input.GetButtonUp ("Interact") && !textController.hasWon) {
			if (!linesDrawn && !stopTime) {
				stopTime = true;
				InstantiateGridLines ();
			} else if (linesDrawn && stopTime) {
				//Debug.Log ("Destroy");
				stopTime = false;
				DestroyGridLines ();
			}


			//More tutorial stuff
			if (numOfGridLines == 26) {
				controlLines = false;
				//overallLinesDrawn = true;
				//overallStopTime = true;
				tileController.InstantiateTileDots ();
				gridSound.Play ();
				triangleController.UpdateGridDotsAndLines (stopTime);
				//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
			}

			
			if (numOfGridLines == 0) {
				controlLines = false;
				//overallLinesDrawn = false;
				//overallStopTime = false;
				tileController.DestroyTileDots ();
				gridSound.Play ();
				triangleController.UpdateGridDotsAndLines (stopTime);
				//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
			}

		} else if (specialOccasion) {
			if (!linesDrawn && !stopTime) {
				stopTime = true;
				InstantiateGridLines ();
			} else if (linesDrawn && stopTime) {
				//Debug.Log ("Destroy");
				stopTime = false;
				DestroyGridLines ();
			}

			if (numOfGridLines == 26) {
				controlLines = false;
				//overallLinesDrawn = true;
				//overallStopTime = true;
				//tileController.InstantiateTileDots ();
				triangleController.UpdateGridDotsAndLines (stopTime);
				//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
				specialOccasion = false;
				//triangleController.UpdateGridDotsAndLines (stopTime);
			}
			
			
			if (numOfGridLines == 0) {
				controlLines = false;
				//overallLinesDrawn = false;
				//overallStopTime = false;
				//tileController.DestroyTileDots ();
				triangleController.UpdateGridDotsAndLines (stopTime);
				//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
				//triangleController.UpdateGridDotsAndLines (stopTime);
			}
		}

		/*
		if (controlLines) {
			Debug.Log ("Leggo");
			if (!linesDrawn && !stopTime && numOfGridLines != 26) {
				InstantiateGridLines ();
			} else if (linesDrawn && stopTime && numOfGridLines != 0) {
				DestroyGridLines ();
			}
		}*/

		if (!stopTime) {
			Time.timeScale = 1.0f;
		} else if (stopTime) {
			Time.timeScale = 0f;
		}
	}

	public void ControlLines () {
		controlLines = true;
	}

	void InstantiateGridLines () {
		gridLine = Instantiate (lineRenderer);

		gridLine.material.color = Color.black;

		gridLine.SetPosition (0, point1.transform.position);
		gridLine.SetPosition (1, point2.transform.position);

		gridLine.SetWidth (0.020f, 0.020f);

		linesDrawn = true;

		numOfGridLines += 1;
	}

	void DestroyGridLines () {
		Destroy (gridLine.gameObject);
		
		linesDrawn = false;

		numOfGridLines -= 1;

	}

	void OnTriggerStay (Collider intersection) {
		if (intersection.CompareTag ("Grid Line")) {
			Debug.Log ("ddd");
		}
	}
}
