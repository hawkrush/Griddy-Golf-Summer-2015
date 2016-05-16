using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class TriangleControllerTut03 : MonoBehaviour {

	public GameObject gridDot;
	public GameObject createdGridDot;
	public LineRenderer lineRenderer;
	public TutorialControllerLvl3 tutorialCtrl1;
	public AudioSource soundClip;
	public AudioClip bounceFX, dotsFX;
	//public AudioSource dotsClip;
	public BounceSoundTut03 bounceSound;
	public GridLinesTut03 gridLines;
	public ManipulateVerticesTut03 manipulateVertices;
	public TextControllerTut03 textController;
	public BallControllerTut03 ballController;

	public Camera cam;

	private Vector3 mousePos;
	private Vector3 gridDotPos;
	public int numOfGridDots;
	//public int numOfActiveGridDots;
	public int numOfTotalGridDots;

	public bool hasBeenCreated;
	public bool doNotCreateDot;
	public bool doNotSelectGridDots;
	//public bool updateDotsAndLines;

	//public static LineRenderer[] lineRenderer;
	public LineRenderer lr1, lr2, lr3;
	public static GameObject[] gridDots;

	//private int numOfResets;

	void Start () {
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut03> ();
		ballController = GameObject.Find ("Release Ball").GetComponent<BallControllerTut03> ();

		numOfGridDots = 0;
		hasBeenCreated = false;

		gridDots = new GameObject[30];

		numOfTotalGridDots = 0;

		hasBeenCreated = false;
		doNotCreateDot = false;
		doNotSelectGridDots = false;

		//bounceSound = GetComponent<BounceSound> ();
		//updateDotsAndLines = false;
	}

	// Update is called once per frame
	void Update () {
		if (tutorialCtrl1.inTutorialTC && (numOfTotalGridDots > 0) && (numOfTotalGridDots % 3 == 0) && gridLines.stopTime) {
			CreateTriangle ();
			numOfGridDots = 0;
			tutorialCtrl1.inTutorialTC = false;
			if (numOfTotalGridDots == 3) {
				tutorialCtrl1.startPart1 = false;
				tutorialCtrl1.startPart2 = true;
			} else if (numOfTotalGridDots == 6) {
				tutorialCtrl1.startPart3 = false;
				tutorialCtrl1.startPart4 = true;
			} else if (numOfTotalGridDots == 9) {
				tutorialCtrl1.inTutorialGL = true;
				//tutorialCtrl1.startPart4 = true;
			} else if (numOfTotalGridDots == 12) {
				TutCreateGridDot (new Vector3 (gridDots [11].transform.position.x + 0.5f, -12f, gridDots [11].transform.position.z));
				tutorialCtrl1.messageCurrentlyOn += 1;
				tutorialCtrl1.startPart4 = false;
				tutorialCtrl1.startPart5 = true;
			}
			//tutorialCtrl1.startPart5 = true;
			//tutorialCtrl1.TutorialPart3 ();
		}
		
		if (tutorialCtrl1.inTutorialTC) {
			if (Input.GetButtonUp ("Fire2") && !textController.hasWon) {
				/*
				if (gridLines.stopTime && !doNotCreateDot && (numOfTotalGridDots < 3)) { //(numOfTotalGridDots <= 30), changed for tutorial
					//Debug.Log ("GridDot");
					CreateGridDot ();
					soundClip.clip = dotsFX;
					soundClip.Play ();

				} else if (doNotCreateDot) {
					doNotCreateDot = false;
				}


				if ((numOfTotalGridDots % 3 == 0) && gridLines.stopTime) {
					CreateTriangle ();
					numOfGridDots = 0;
					tutorialCtrl1.inTutorialTC = false;
					tutorialCtrl1.startPart3 = false;
					//tutorialCtrl1.TutorialPart3 ();
				}*/
			}
			
			//Removed for Tutorial

			if (Input.GetButtonUp ("Reset") && gridLines.stopTime && numOfTotalGridDots == 13) {
				tutorialCtrl1.inTutorialTC = false;
				if (numOfTotalGridDots > 0) {
					Destroy (GameObject.Find ("Grid Dot " + numOfTotalGridDots.ToString ()));
					if (numOfTotalGridDots % 3 == 0) {
						DestroyLines (numOfTotalGridDots);
						numOfGridDots = 3;
					}
					//numOfGridDots -= 1;
					numOfTotalGridDots -= 1;
					tutorialCtrl1.startPart5 = true;
				}
			}

		}

	}

	public void UpdateGridDotsAndLines (bool stoppingTime) {
		//Debug.Log (stoppingTime.ToString ()); //bug with gridLines.stopTime
		if (stoppingTime && (numOfTotalGridDots > 0)) { //bug with gridLines.stopTime
			for (int i=1; i<=numOfTotalGridDots; i++) {
				GameObject.Find ("Grid Dot " + i.ToString ()).transform.position = new Vector3 (GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.x, 
				                                                                                -12f, 
				                                                                                GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.z);
			}
			
			if ((numOfTotalGridDots%3 == 0) && lr1 != null) {
				int tempTotal = numOfTotalGridDots;
				while (tempTotal > 0) {
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			} else if ((numOfTotalGridDots - 1)%3 == 0) {
				int tempTotal = numOfTotalGridDots - 1;
				while (tempTotal > 0) {
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			} else if ((numOfTotalGridDots - 2)%3 == 0) {
				int tempTotal = numOfTotalGridDots - 2;
				while (tempTotal > 0) {
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			}
							
		} else if (!stoppingTime && (numOfTotalGridDots > 0)) { //bug with gridLines.stopTime
			for (int i=1; i<=numOfTotalGridDots; i++) {
				GameObject.Find ("Grid Dot " + i.ToString ()).transform.position = new Vector3 (GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.x, 
				                                                                                -12.95978f, 
				                                                                                GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.z);
			}

			if ((numOfTotalGridDots%3 == 0) && lr1 != null) {
				int tempTotal = numOfTotalGridDots;
				while (tempTotal > 0) {
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			} else if ((numOfTotalGridDots - 1)%3 == 0) {
				int tempTotal = numOfTotalGridDots - 1;
				while (tempTotal > 0) {
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			} else if ((numOfTotalGridDots - 2)%3 == 0) {
				int tempTotal = numOfTotalGridDots - 2;
				while (tempTotal > 0) {
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			}
		}
	}

	public void TutCreateGridDot (Vector3 newDotPos) {
		createdGridDot = Instantiate (gridDot, newDotPos, gridDot.transform.rotation) as GameObject;
		createdGridDot.transform.position = new Vector3 (createdGridDot.transform.position.x, -12f, createdGridDot.transform.position.z);
		
		gridDots[numOfTotalGridDots] = createdGridDot;
		//createdGridDot.name = "Grid Dot " + numOfTotalGridDots.ToString ();
		numOfTotalGridDots += 1;
		createdGridDot.name = "Grid Dot " + numOfTotalGridDots.ToString ();
		
		soundClip.clip = dotsFX;
		soundClip.Play ();
		
		if ((numOfTotalGridDots > 0) && (numOfTotalGridDots%3 == 0)) {
			tutorialCtrl1.inTutorialHDC = false;
			tutorialCtrl1.inTutorialTC = true;
		}
	}

	void CreateGridDot () {
		mousePos = Input.mousePosition;
		mousePos.z = 26.75f;
		gridDotPos = cam.ScreenToWorldPoint(mousePos);
		createdGridDot = Instantiate (gridDot, gridDotPos, gridDot.transform.rotation) as GameObject;
		createdGridDot.transform.position = new Vector3 (createdGridDot.transform.position.x, -12f, createdGridDot.transform.position.z);
		gridDots[numOfTotalGridDots] = createdGridDot;
		//numOfGridDots += 1;
		numOfTotalGridDots += 1;
		createdGridDot.name = "Grid Dot " + numOfTotalGridDots.ToString ();
		//Debug.Log ("NumOfTotalGridDots: " + numOfTotalGridDots.ToString ());
	}


	void CreateTriangle () {
		lr1 = Instantiate (lineRenderer);
		lr2 = Instantiate (lineRenderer);
		lr3 = Instantiate (lineRenderer);

		lr1.name = "Triangle Line " + (numOfTotalGridDots - 2).ToString ();
		lr2.name = "Triangle Line " + (numOfTotalGridDots - 1).ToString ();
		lr3.name = "Triangle Line " + numOfTotalGridDots.ToString ();

		lr1.material.color = Color.magenta;
		lr2.material.color = Color.magenta;
		lr3.material.color = Color.magenta;

		lr1.SetPosition (0, gridDots [numOfTotalGridDots - 3].transform.position);
		lr2.SetPosition (0, gridDots [numOfTotalGridDots - 2].transform.position);
		lr3.SetPosition (0, gridDots [numOfTotalGridDots - 1].transform.position);

		lr1.SetPosition (1, gridDots [numOfTotalGridDots - 2].transform.position);
		lr2.SetPosition (1, gridDots [numOfTotalGridDots - 1].transform.position);
		lr3.SetPosition (1, gridDots [numOfTotalGridDots - 3].transform.position);

		lr1.SetWidth (0.20f, 0.20f);
		lr2.SetWidth (0.20f, 0.20f);
		lr3.SetWidth (0.20f, 0.20f);

		BoxCollider col1 = new GameObject("Real Line Collider").AddComponent<BoxCollider> ();
		BoxCollider col2 = new GameObject("Real Line Collider").AddComponent<BoxCollider> ();
		BoxCollider col3 = new GameObject("Real Line Collider").AddComponent<BoxCollider> ();

		//col1.gameObject.AddComponent<AudioSource> ().clip = bounceClip;
		//col2.gameObject.AddComponent<AudioSource> ().clip = bounceClip;
		//col3.gameObject.AddComponent<AudioSource> ().clip = bounceClip;
		
		col1.gameObject.AddComponent<BounceSoundTut03> ();
		col2.gameObject.AddComponent<BounceSoundTut03> ();
		col3.gameObject.AddComponent<BounceSoundTut03> ();
		
		BounceSoundTut03 bounce1 = col1.gameObject.GetComponent<BounceSoundTut03> ();
		BounceSoundTut03 bounce2 = col2.gameObject.GetComponent<BounceSoundTut03> ();
		BounceSoundTut03 bounce3 = col3.gameObject.GetComponent<BounceSoundTut03> ();

		bounce1.SetInfo ();
		bounce2.SetInfo ();
		bounce3.SetInfo ();

		col1.transform.parent = lr1.transform; // Collider is added as child object of line
		col2.transform.parent = lr2.transform; // Collider is added as child object of line
		col3.transform.parent = lr3.transform; // Collider is added as child object of line

		float lineLength1 = Vector3.Distance (gridDots [numOfTotalGridDots - 3].transform.position, gridDots [numOfTotalGridDots - 2].transform.position); // length of line
		float lineLength2 = Vector3.Distance (gridDots [numOfTotalGridDots - 2].transform.position, gridDots [numOfTotalGridDots - 1].transform.position); // length of line
		float lineLength3 = Vector3.Distance (gridDots [numOfTotalGridDots - 1].transform.position, gridDots [numOfTotalGridDots - 3].transform.position); // length of line

		col1.size = new Vector3 (lineLength1, 0.25f, 0.20f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		col2.size = new Vector3 (lineLength2, 0.25f, 0.20f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		col3.size = new Vector3 (lineLength3, 0.25f, 0.20f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement

		Vector3 midPoint1 = (gridDots [numOfTotalGridDots - 3].transform.position + gridDots [numOfTotalGridDots - 2].transform.position)/2;
		Vector3 midPoint2 = (gridDots [numOfTotalGridDots - 2].transform.position + gridDots [numOfTotalGridDots - 1].transform.position)/2;
		Vector3 midPoint3 = (gridDots [numOfTotalGridDots - 1].transform.position + gridDots [numOfTotalGridDots - 3].transform.position)/2;

		col1.transform.position = midPoint1; // setting position of collider object
		col2.transform.position = midPoint2; // setting position of collider object
		col3.transform.position = midPoint3; // setting position of collider object

		// Following lines calculate the angle between startPos and endPos
		float angle1 = (Mathf.Abs (gridDots [numOfTotalGridDots - 3].transform.position.z - gridDots [numOfTotalGridDots - 2].transform.position.z) / Mathf.Abs (gridDots [numOfTotalGridDots - 3].transform.position.x - gridDots [numOfTotalGridDots - 2].transform.position.x));
		float angle2 = (Mathf.Abs (gridDots [numOfTotalGridDots - 2].transform.position.z - gridDots [numOfTotalGridDots - 1].transform.position.z) / Mathf.Abs (gridDots [numOfTotalGridDots - 2].transform.position.x - gridDots [numOfTotalGridDots - 1].transform.position.x));
		float angle3 = (Mathf.Abs (gridDots [numOfTotalGridDots - 1].transform.position.z - gridDots [numOfTotalGridDots - 3].transform.position.z) / Mathf.Abs (gridDots [numOfTotalGridDots - 1].transform.position.x - gridDots [numOfTotalGridDots - 3].transform.position.x));

		if((gridDots [numOfTotalGridDots - 3].transform.position.z<gridDots [numOfTotalGridDots - 2].transform.position.z && gridDots [numOfTotalGridDots - 3].transform.position.x<gridDots [numOfTotalGridDots - 2].transform.position.x) || 
		   (gridDots [numOfTotalGridDots - 2].transform.position.z<gridDots [numOfTotalGridDots - 3].transform.position.z && gridDots [numOfTotalGridDots - 2].transform.position.x<gridDots [numOfTotalGridDots - 3].transform.position.x))
		{
			angle1 *=-1;
		}
		if((gridDots [numOfTotalGridDots - 2].transform.position.z<gridDots [numOfTotalGridDots - 1].transform.position.z && gridDots [numOfTotalGridDots - 2].transform.position.x<gridDots [numOfTotalGridDots - 1].transform.position.x) || 
		   (gridDots [numOfTotalGridDots - 1].transform.position.z<gridDots [numOfTotalGridDots - 2].transform.position.z && gridDots [numOfTotalGridDots - 1].transform.position.x<gridDots [numOfTotalGridDots - 2].transform.position.x))
		{
			angle2 *=-1;
		}
		if((gridDots [numOfTotalGridDots - 1].transform.position.z<gridDots [numOfTotalGridDots - 3].transform.position.z && gridDots [numOfTotalGridDots - 1].transform.position.x<gridDots [numOfTotalGridDots - 3].transform.position.x) || 
		   (gridDots [numOfTotalGridDots - 3].transform.position.z<gridDots [numOfTotalGridDots - 1].transform.position.z && gridDots [numOfTotalGridDots - 3].transform.position.x<gridDots [numOfTotalGridDots - 1].transform.position.x))
		{
			angle3 *=-1;
		}

		angle1 = Mathf.Rad2Deg * Mathf.Atan (angle1);
		angle2 = Mathf.Rad2Deg * Mathf.Atan (angle2);
		angle3 = Mathf.Rad2Deg * Mathf.Atan (angle3);

		col1.transform.Rotate (new Vector3 (0f, angle1, 0f));
		col2.transform.Rotate (new Vector3 (0f, angle2, 0f));
		col3.transform.Rotate (new Vector3 (0f, angle3, 0f));

		//- See more at: http://www.theappguruz.com/unity/add-collider-to-line-renderer-unity/#sthash.ICkbKemQ.dpuf
		//
		//hasBeenCreated = true;
	
	}

	public void RecreateTriangle (int tempNum) {

		lr1 = Instantiate (lineRenderer);
		lr2 = Instantiate (lineRenderer);
		lr3 = Instantiate (lineRenderer);
		
		lr1.name = "Triangle Line " + (tempNum - 2).ToString ();
		lr2.name = "Triangle Line " + (tempNum - 1).ToString ();
		lr3.name = "Triangle Line " + tempNum.ToString ();
		
		lr1.material.color = Color.magenta;
		lr2.material.color = Color.magenta;
		lr3.material.color = Color.magenta;
		
		lr1.SetPosition (0, GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position);
		lr2.SetPosition (0, GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position);
		lr3.SetPosition (0, GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position);
		
		lr1.SetPosition (1, GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position);
		lr2.SetPosition (1, GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position);
		lr3.SetPosition (1, GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position);
		
		lr1.SetWidth (0.20f, 0.20f);
		lr2.SetWidth (0.20f, 0.20f);
		lr3.SetWidth (0.20f, 0.20f);
		
		BoxCollider col1 = new GameObject("Real Line Collider").AddComponent<BoxCollider> ();
		BoxCollider col2 = new GameObject("Real Line Collider").AddComponent<BoxCollider> ();
		BoxCollider col3 = new GameObject("Real Line Collider").AddComponent<BoxCollider> ();
		
		col1.gameObject.AddComponent<BounceSoundTut03> ();
		col2.gameObject.AddComponent<BounceSoundTut03> ();
		col3.gameObject.AddComponent<BounceSoundTut03> ();
		
		BounceSoundTut03 bounce1 = col1.gameObject.GetComponent<BounceSoundTut03> ();
		BounceSoundTut03 bounce2 = col2.gameObject.GetComponent<BounceSoundTut03> ();
		BounceSoundTut03 bounce3 = col3.gameObject.GetComponent<BounceSoundTut03> ();
		
		bounce1.SetInfo ();
		bounce2.SetInfo ();
		bounce3.SetInfo ();

		col1.transform.parent = lr1.transform; // Collider is added as child object of line
		col2.transform.parent = lr2.transform; // Collider is added as child object of line
		col3.transform.parent = lr3.transform; // Collider is added as child object of line
		
		float lineLength1 = Vector3.Distance (GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position, 
		                                      GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position); // length of line
		float lineLength2 = Vector3.Distance (GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position, 
		                                      GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position); // length of line
		float lineLength3 = Vector3.Distance (GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position, 
		                                      GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position); // length of line
		
		col1.size = new Vector3 (lineLength1, 0.25f, 0.20f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		col2.size = new Vector3 (lineLength2, 0.25f, 0.20f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		col3.size = new Vector3 (lineLength3, 0.25f, 0.20f); // size of collider is set where X is length of line, Y is width of line, Z will be set as per requirement
		
		Vector3 midPoint1 = (GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position + GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position)/2;
		Vector3 midPoint2 = (GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position + GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position)/2;
		Vector3 midPoint3 = (GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position + GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position)/2;
		
		col1.transform.position = midPoint1; // setting position of collider object
		col2.transform.position = midPoint2; // setting position of collider object
		col3.transform.position = midPoint3; // setting position of collider object
		
		// Following lines calculate the angle between startPos and endPos
		float angle1 = (Mathf.Abs (GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.z - GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.z) / Mathf.Abs (GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.x - GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.x));
		float angle2 = (Mathf.Abs (GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.z - GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.z) / Mathf.Abs (GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.x - GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.x));
		float angle3 = (Mathf.Abs (GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.z - GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.z) / Mathf.Abs (GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.x - GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.x));
		
		if((GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.z<GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.z && GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.x<GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.x) || 
		   (GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.z<GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.z && GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.x<GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.x))
		{
			angle1 *=-1;
		}
		if((GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.z<GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.z && GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.x<GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.x) || 
		   (GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.z<GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.z && GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.x<GameObject.Find ("Grid Dot " + (tempNum - 1).ToString ()).transform.position.x))
		{
			angle2 *=-1;
		}
		if((GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.z<GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.z && GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.x<GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.x) || 
		   (GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.z<GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.z && GameObject.Find ("Grid Dot " + (tempNum - 2).ToString ()).transform.position.x<GameObject.Find ("Grid Dot " + tempNum.ToString ()).transform.position.x))
		{
			angle3 *=-1;
		}

		angle1 = Mathf.Rad2Deg * Mathf.Atan (angle1);
		angle2 = Mathf.Rad2Deg * Mathf.Atan (angle2);
		angle3 = Mathf.Rad2Deg * Mathf.Atan (angle3);

		col1.transform.Rotate (new Vector3 (0f, angle1, 0f));
		col2.transform.Rotate (new Vector3 (0f, angle2, 0f));
		col3.transform.Rotate (new Vector3 (0f, angle3, 0f));

		//Debug.Log ("Recreated");
	}

	public void DestroyDotsAndLines () {
		Destroy (GameObject.Find ("Grid Dot " + (numOfTotalGridDots - 2).ToString ()));
		Destroy (GameObject.Find ("Grid Dot " + (numOfTotalGridDots - 1).ToString ()));
		Destroy (GameObject.Find ("Grid Dot " + (numOfTotalGridDots).ToString ()));

		Destroy (GameObject.Find ("Triangle Line " + (numOfTotalGridDots - 2).ToString ()));
		Destroy (GameObject.Find ("Triangle Line " + (numOfTotalGridDots - 1).ToString ()));
		Destroy (GameObject.Find ("Triangle Line " + (numOfTotalGridDots).ToString ()));

		numOfTotalGridDots -= 3;
	}

	public void DestroyLines (int tempNum) {
		Destroy (GameObject.Find ("Triangle Line " + (tempNum - 2).ToString ()));
		Destroy (GameObject.Find ("Triangle Line " + (tempNum - 1).ToString ()));
		Destroy (GameObject.Find ("Triangle Line " + (tempNum).ToString ()));

		//Debug.Log ("Destroyed");

	}

	public void playBounceSound () {
		soundClip.clip = bounceFX;
		soundClip.Play ();

		if ((numOfTotalGridDots%3 == 0) && (numOfTotalGridDots != 12)) {
			//tutorialCtrl1.startPart2 = true;
			tutorialCtrl1.freezeTime = true;
		}
	}

	public void SetGridDotSelected () {
		if (!doNotSelectGridDots) {
			doNotSelectGridDots = true;
		} else if (doNotSelectGridDots) {
			doNotSelectGridDots = false;
		}
	}
}