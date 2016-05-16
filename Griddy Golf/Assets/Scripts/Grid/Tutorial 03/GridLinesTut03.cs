using UnityEngine;
using System.Collections;

public class GridLinesTut03 : MonoBehaviour {
	
	public LineRenderer lineRenderer;
	public GameObject point1, point2;
	public TriangleControllerTut03 triangleController;
	public TutorialControllerLvl3 tutorialCtrl1;
	public AudioSource gridSound;
	public TextControllerTut03 textController;
	public TileControllerTut03 tileController;

	public LineRenderer gridLine;
	public bool linesDrawn;
	public bool stopTime;

	public static int numOfGridLines;
	// Use this for initialization

	void Start () {
		gridSound = GameObject.Find ("Dots For Horizontal Grid Line").GetComponent<AudioSource> ();
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut03> ();
		tileController = GameObject.Find ("Tile 1").GetComponent<TileControllerTut03> ();

		linesDrawn = false;
		stopTime = false;

		numOfGridLines = 0;

		lineRenderer = GameObject.Find ("GridLineRenderer").GetComponent<LineRenderer> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut03> ();
		tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl3> ();
	}

	// Update is called once per frame
	void Update () {
		//Tutorial stuff
		if (tutorialCtrl1.inTutorialGL) {
			if (Input.GetButtonUp ("Interact") && !textController.hasWon) {
				if (!linesDrawn && !stopTime) {
					stopTime = true;
					InstantiateGridLines ();
				} else if (linesDrawn && stopTime) {
					stopTime = false;
					DestroyGridLines ();
				}
				
				//More tutorial stuff
				if (numOfGridLines == 26) {
					gridSound.Play ();
					
					tutorialCtrl1.inTutorialGL = false;
					//tutorialCtrl1.inTutorialBC = false;
					
					//tutorialCtrl1.startPart2 = false;
					//tutorialCtrl1.startPart3 = true;
					//Debug.Log ("Grids done");
					//tutorialCtrl1.TutorialPart2 ();
					tileController.InstantiateTileDots ();
					
					triangleController.UpdateGridDotsAndLines (stopTime);

					if (tutorialCtrl1.messageCurrentlyOn == 9) {
						tutorialCtrl1.messageCurrentlyOn += 1;
						tutorialCtrl1.startPart3 = true;
					}
				}
				
				if (numOfGridLines == 0) {
					gridSound.Play ();
					
					tutorialCtrl1.inTutorialGL = false;
					//tutorialCtrl1.inTutorialBC = true;
					//tutorialCtrl1.inTutorialBC = false;
					
					//tutorialCtrl1.startPart2 = false;
					//tutorialCtrl1.startPart3 = true;
					//tutorialCtrl1.startPart4 = false;
					//tutorialCtrl1.tutorialDialogue4.gameObject.SetActive (false);
					//Debug.Log (tutorialCtrl1.inTutorialGL.ToString ());
					tileController.DestroyTileDots ();

					triangleController.UpdateGridDotsAndLines (stopTime);

					if (tutorialCtrl1.messageCurrentlyOn == 13) {
						Time.timeScale = 1f;
					}
				}
			}
			
			if (!stopTime && (tutorialCtrl1.messageCurrentlyOn != 9) && (tutorialCtrl1.messageCurrentlyOn != 13) 
			    && (tutorialCtrl1.messageCurrentlyOn != 14)) {
				Time.timeScale = 1.0f;
			} else if (stopTime && (tutorialCtrl1.messageCurrentlyOn != 9) && (tutorialCtrl1.messageCurrentlyOn != 13) 
			           && (tutorialCtrl1.messageCurrentlyOn != 14)) {
				Time.timeScale = 0f;
			}
		}
	}

	void InstantiateGridLines () {
		gridLine = Instantiate (lineRenderer);

		gridLine.material.color = Color.black;

		gridLine.SetPosition (0, point1.transform.position);
		gridLine.SetPosition (1, point2.transform.position);

		gridLine.SetWidth (0.020f, 0.020f);

		/*
		BoxCollider col = new GameObject ("Grid Collider").AddComponent<BoxCollider> ();

		col.gameObject.AddComponent<GridController> ();
		
		col.transform.parent = gridLine.transform; // Collider is added as child object of line
		
		float lineLength = Vector3.Distance (point1.transform.position, point2.transform.position); // length of line
		
		col.size = new Vector3 (lineLength, 0.025f, 0.025f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		
		Vector3 midPoint = (point1.transform.position + point2.transform.position)/2;
		
		col.transform.position = midPoint; // setting position of collider object

		if (point1.transform.position.x == point2.transform.position.y) {
			col.transform.Rotate (new Vector3 (0f, 0f, 0f));
		} else if (point1.transform.position.x == point2.transform.position.x) {
			col.transform.Rotate (new Vector3 (0f, 90f, 0f));
		}

		col.isTrigger = true;
		*/

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
