using UnityEngine;
using System.Collections;

public class GridLinesTut02 : MonoBehaviour {
	
	public LineRenderer lineRenderer;
	public GameObject point1, point2;
	public TriangleControllerTut02 triangleController;
	public TutorialControllerLvl2 tutorialCtrl1;
	public AudioSource gridSound;
	public TextControllerTut02 textController;
	public TileControllerTut02 tileController;

	public LineRenderer gridLine;
	public bool linesDrawn;
	public bool stopTime;
	public bool specialOccasion;

	public static int numOfGridLines;
	// Use this for initialization

	void Start () {
		gridSound = GameObject.Find ("Dots For Horizontal Grid Line").GetComponent<AudioSource> ();
		tileController = GameObject.Find ("Tile 5").GetComponent<TileControllerTut02> ();
		//textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut02> ();

		linesDrawn = false;
		stopTime = false;
		specialOccasion = false;

		numOfGridLines = 0;
	}

	// Update is called once per frame
	void Update () {
		if (tutorialCtrl1.inTutorialGL) {
			if (Input.GetButtonUp ("Interact")) {
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

					tileController.InstantiateTileDots ();
					tutorialCtrl1.inTutorialGL = false;
					triangleController.UpdateGridDotsAndLines (stopTime);
				}
				
				if (numOfGridLines == 0) {
					gridSound.Play ();

					tileController.DestroyTileDots ();
					tutorialCtrl1.inTutorialGL = false;
					triangleController.UpdateGridDotsAndLines (stopTime);
				}
			}
			
			if (!stopTime && tutorialCtrl1.messageCurrentlyOn != 14) {
				Time.timeScale = 1.0f;
			} else if (stopTime && tutorialCtrl1.messageCurrentlyOn != 14) {
				Time.timeScale = 0f;
			}

		} else if (specialOccasion) {
			if (!linesDrawn && !stopTime) {
				stopTime = true;
				InstantiateGridLines ();

				if (numOfGridLines == 26) {
					Debug.Log ("special");
					//controlLines = false;
					//overallLinesDrawn = true;
					//overallStopTime = true;
					//tileController.InstantiateTileDots ();
					triangleController.UpdateGridDotsAndLines (stopTime);
					//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
					specialOccasion = false;
					//triangleController.UpdateGridDotsAndLines (stopTime);
				}
				
				
				if (numOfGridLines == 0) {
					//controlLines = false;
					//overallLinesDrawn = false;
					//overallStopTime = false;
					//tileController.DestroyTileDots ();
					triangleController.UpdateGridDotsAndLines (stopTime);
					//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
					//triangleController.UpdateGridDotsAndLines (stopTime);
				}
			} else if (linesDrawn && stopTime) {
				//Debug.Log ("Destroy");
				stopTime = false;
				DestroyGridLines ();

				if (numOfGridLines == 26) {
					Debug.Log ("special");
					//controlLines = false;
					//overallLinesDrawn = true;
					//overallStopTime = true;
					//tileController.InstantiateTileDots ();
					triangleController.UpdateGridDotsAndLines (stopTime);
					//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
					specialOccasion = false;
					//triangleController.UpdateGridDotsAndLines (stopTime);
				}
				
				
				if (numOfGridLines == 0) {
					//controlLines = false;
					//overallLinesDrawn = false;
					//overallStopTime = false;
					//tileController.DestroyTileDots ();
					triangleController.UpdateGridDotsAndLines (stopTime);
					//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
					//triangleController.UpdateGridDotsAndLines (stopTime);
				}
			}
			
			if (numOfGridLines == 26) {
				Debug.Log ("special");
				//controlLines = false;
				//overallLinesDrawn = true;
				//overallStopTime = true;
				//tileController.InstantiateTileDots ();
				triangleController.UpdateGridDotsAndLines (stopTime);
				//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
				specialOccasion = false;
				Debug.Log (specialOccasion.ToString ());
				//triangleController.UpdateGridDotsAndLines (stopTime);
			}
			
			
			if (numOfGridLines == 0) {
				//controlLines = false;
				//overallLinesDrawn = false;
				//overallStopTime = false;
				//tileController.DestroyTileDots ();
				triangleController.UpdateGridDotsAndLines (stopTime);
				//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
				//triangleController.UpdateGridDotsAndLines (stopTime);
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
