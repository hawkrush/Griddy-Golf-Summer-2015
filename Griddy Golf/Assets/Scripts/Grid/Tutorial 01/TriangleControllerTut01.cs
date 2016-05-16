using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriangleControllerTut01 : MonoBehaviour {

	public GameObject gridDot;
	public GameObject createdGridDot;
	public LineRenderer lineRenderer;
	public AudioSource soundClip;
	public AudioClip bounceFX, dotsFX;
	//public AudioSource dotsClip;
	public BounceSoundTut01 bounceSound;
	public GridLinesTut01 gridLines;
	public ManipulateVerticesTut01 manipulateVertices;
	public TextControllerTut01 textController;
	public GameObject tileDots;
	public TileDotsControllerTut01 tileDotsController;
	//public GameObject anglesPanel;
	public Text anglesText;
	public TutorialControllerLvl1 tutorialCtrl1;

	public Camera cam;

	private Vector3 mousePos;
	private Vector3 gridDotPos;
	public int numOfGridDots;
	public int numOfTotalGridDots;
	public int maxNumOfGridDots;
	public int numOfSelectedLines;
	public GameObject currentGridDot;
	public GameObject firstSelectedLine, secondSelectedLine, thirdSelectedLine;
	public float firstSelectedTriangleLine, secondSelectedTriangleLine, thirdSelectedTriangleLine;
	public float lengthOfFirstLine, lengthOfSecondLine, lengthOfThirdLine;
	public int numOfTriangleLines;
	public int numOfNegativeAngles, numOfPositiveAngles;
	
	public float finalAngle;
	
	public bool hasBeenCreated;
	public bool doNotCreateDot;
	public bool gridDotSelected;
	public bool linesHaveBeenSelected;
	public bool specialAngles;
	public bool doNotSelectGridDots;

	//public static LineRenderer[] lineRenderer;
	public LineRenderer lr1, lr2, lr3;
	public static GameObject[] gridDots;

	//private int numOfResets;

	void Start () {
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut01> ();
		//anglesPanel = GameObject.Find ("Angles Panel");
		anglesText = GameObject.Find ("Angles Text").GetComponent<Text> ();
		cam = GameObject.Find ("Game View").GetComponent<Camera> ();
		lineRenderer = GameObject.Find ("TriangleLineRenderer").GetComponent<LineRenderer> ();
		
		//anglesPanel.SetActive (false);
		anglesText.text = "";
		//tileDotsController = tileDots.GetComponent<TileDotsController> ();
		
		numOfGridDots = 0;
		hasBeenCreated = false;
		
		gridDots = new GameObject[maxNumOfGridDots];
		
		numOfTotalGridDots = 0;
		numOfSelectedLines = 0;
		numOfTriangleLines = 0;
		numOfNegativeAngles = 0;
		numOfPositiveAngles = 0;
		
		hasBeenCreated = false;
		doNotCreateDot = false;
		gridDotSelected = false;
		linesHaveBeenSelected = false;
	}

	// Update is called once per frame
	void Update () {
		if (numOfSelectedLines == 2) {
			//anglesText.text = "";
			CalculateAngles ();
			anglesText.text = "Angle: " + finalAngle.ToString ();
			linesHaveBeenSelected = true;
			//numOfSelectedLines = 0;
		}

		/*
		if (tutorialCtrl1.inTutorialTC) {
			if (Input.GetButtonUp ("Reset") && gridLines.stopTime && !textController.hasWon) {
				if (numOfTotalGridDots > 0) {
					if (currentGridDot != null && currentGridDot.transform.position == GameObject.Find ("Grid Dot " + numOfTotalGridDots.ToString ()).transform.position) {
						currentGridDot = null;
					}
					Destroy (GameObject.Find ("Grid Dot " + numOfTotalGridDots.ToString ()));
					soundClip.clip = dotsFX;
					soundClip.Play ();
					if (numOfTotalGridDots % 3 == 0) {
						DestroyLines (numOfTotalGridDots);
						numOfGridDots = 3;
					}
					//numOfGridDots -= 1;
					numOfTotalGridDots -= 1;
				}
			}
		}*/

	}

	public void TutReset () {
		if (numOfTotalGridDots > 0) {
			if (currentGridDot != null && currentGridDot.transform.position == GameObject.Find ("Grid Dot " + numOfTotalGridDots.ToString ()).transform.position) {
				currentGridDot = null;
			}
			Destroy (GameObject.Find ("Grid Dot " + numOfTotalGridDots.ToString ()));
			soundClip.clip = dotsFX;
			soundClip.Play ();
			if (numOfTotalGridDots % 3 == 0) {
				DestroyLines (numOfTotalGridDots);
				numOfGridDots = 3;
			}
			//numOfGridDots -= 1;
			numOfTotalGridDots -= 1;
		}
	}
	
	public void UpdateGridDotsAndLines (bool stoppingTime) {
		//Debug.Log ("update");
		//Debug.Log (stoppingTime.ToString ()); //bug with gridLines.stopTime
		if (stoppingTime && (numOfTotalGridDots > 0)) { //bug with gridLines.stopTime
			Debug.Log ("this one");
			for (int i=1; i<=numOfTotalGridDots; i++) {
				GameObject.Find ("Grid Dot " + i.ToString ()).transform.position = new Vector3 (GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.x, 
				                                                                                -12f, 
				                                                                                GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.z);
			}
			
			if (numOfTotalGridDots%3 == 0) {
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
			Debug.Log ("then this one");
			for (int i=1; i<=numOfTotalGridDots; i++) {
				GameObject.Find ("Grid Dot " + i.ToString ()).transform.position = new Vector3 (GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.x, 
				                                                                                -12.95978f, 
				                                                                                GameObject.Find ("Grid Dot " + i.ToString ()).transform.position.z);
			}
			//Debug.Log (lr1.ToString ());
			//Debug.Log (numOfTotalGridDots.ToString ());
			if (numOfTotalGridDots%3 == 0) {
				int tempTotal = numOfTotalGridDots;
				while (tempTotal > 0) {
					Debug.Log ("C'mon");
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			} else if ((numOfTotalGridDots - 1)%3 == 0) {
				int tempTotal = numOfTotalGridDots - 1;
				while (tempTotal > 0) {
					Debug.Log ("C'mon no");
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			} else if ((numOfTotalGridDots - 2)%3 == 0) {
				int tempTotal = numOfTotalGridDots - 2;
				while (tempTotal > 0) {
					Debug.Log ("C'mon now");
					DestroyLines (tempTotal);
					RecreateTriangle (tempTotal);
					tempTotal -= 3;
				}
			}
		}
	}
	
	public void CreateGridDot (Vector3 tileDotPos) {
		if (numOfTotalGridDots < maxNumOfGridDots) {
			/*
			mousePos = Input.mousePosition;
			mousePos.z = 26.75f;
			gridDotPos = cam.ScreenToWorldPoint (mousePos);
			*/
			createdGridDot = Instantiate (gridDot, tileDotPos, gridDot.transform.rotation) as GameObject;
			createdGridDot.transform.position = new Vector3 (createdGridDot.transform.position.x, 
			                                                 -12f, 
			                                                 createdGridDot.transform.position.z);
			gridDots [numOfTotalGridDots] = createdGridDot;
			//gridDots[numOfTotalGridDots].name = "Grid Dot " + numOfTotalGridDots.ToString ();
			numOfGridDots += 1;
			numOfTotalGridDots += 1;
			createdGridDot.name = "Grid Dot " + numOfTotalGridDots.ToString ();
			gridDots [numOfTotalGridDots - 1].name = "Grid Dot " + numOfTotalGridDots.ToString ();
			tileDotsController.dotSelected = false;
			
			soundClip.clip = dotsFX;
			soundClip.Play ();
			
			if ((numOfTotalGridDots % 3 == 0) && gridLines.stopTime) {
				CreateTriangle ();
				numOfGridDots = 0;
			}
		}
		
	}

	public void RecreateGridDot (Vector3 recreatedTileDotPos) {
		Debug.Log ("Recreate to :" + recreatedTileDotPos.ToString ());
		if ((recreatedTileDotPos.x == 8.0f && (recreatedTileDotPos.z >= 28.6f && recreatedTileDotPos.z <= 28.8) && tutorialCtrl1.messageCurrentlyOn == 15) |
		    (recreatedTileDotPos.x == 8.0f && (recreatedTileDotPos.z >= 26.6f && recreatedTileDotPos.z <= 26.8) && tutorialCtrl1.messageCurrentlyOn == 16) |
		    (recreatedTileDotPos.x == 4.0f && (recreatedTileDotPos.z >= 27.1f && recreatedTileDotPos.z <= 27.3) && tutorialCtrl1.messageCurrentlyOn == 20)) {
			Debug.Log ("Recreate Dot");
			int i = 0;
			while (gridDots [i] != null) {
				if (currentGridDot != null && gridDots [i].transform.position == currentGridDot.transform.position) {
					Destroy (gridDots [i].gameObject);
					mousePos = Input.mousePosition;
					mousePos.z = 26.75f;
					gridDotPos = cam.ScreenToWorldPoint (mousePos);
					createdGridDot = Instantiate (gridDot, recreatedTileDotPos, gridDot.transform.rotation) as GameObject;
					createdGridDot.transform.position = new Vector3 (createdGridDot.transform.position.x, 
					                                                 -12f, 
					                                                 createdGridDot.transform.position.z);
					gridDots [i] = createdGridDot;
					createdGridDot.name = "Grid Dot " + (i + 1).ToString ();
					gridDots [i].name = "Grid Dot " + (i + 1).ToString ();
					tileDotsController.dotSelected = false;
					
					soundClip.clip = dotsFX;
					soundClip.Play ();
					
					if (((i + 1) % 3 == 0) && (gridDots [i] != null)) {
						//DestroyLines (i+1);
						RecreateTriangle (i + 1);
					} else if (((i + 2) % 3 == 0) && (gridDots [i + 1] != null)) {
						//DestroyLines (i+2);
						RecreateTriangle (i + 2);
					} else if (((i + 3) % 3 == 0) && (gridDots [i + 2] != null)) {
						//DestroyLines (i+3);
						Debug.Log ("Why not");
						RecreateTriangle (i + 3);
					}
					
					gridLines.specialOccasion = true;
					
					break;
				} else {
					i++;
				}
			}

			if (tutorialCtrl1.messageCurrentlyOn == 15 | tutorialCtrl1.messageCurrentlyOn == 16) {
				tutorialCtrl1.inTutorialMV = false;
				tutorialCtrl1.inTutorialTDC = false;
				tutorialCtrl1.messageCurrentlyOn += 1;
				tutorialCtrl1.startPart3 = true;
			}
		}
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

		BoxCollider col1 = new GameObject("Line Collider " + (numOfTotalGridDots - 2).ToString ()).AddComponent<BoxCollider> ();
		BoxCollider col2 = new GameObject("Line Collider " + (numOfTotalGridDots - 1).ToString ()).AddComponent<BoxCollider> ();
		BoxCollider col3 = new GameObject("Line Collider " + numOfTotalGridDots.ToString ()).AddComponent<BoxCollider> ();

		col1.gameObject.AddComponent<BounceSoundTut01> ();
		col2.gameObject.AddComponent<BounceSoundTut01> ();
		col3.gameObject.AddComponent<BounceSoundTut01> ();
		
		BounceSoundTut01 bounce1 = col1.gameObject.GetComponent<BounceSoundTut01> ();
		BounceSoundTut01 bounce2 = col2.gameObject.GetComponent<BounceSoundTut01> ();
		BounceSoundTut01 bounce3 = col3.gameObject.GetComponent<BounceSoundTut01> ();
		
		bounce1.SetInfo ();
		bounce2.SetInfo ();
		bounce3.SetInfo ();

		col1.gameObject.AddComponent<AnglesTextTut01> ();
		col2.gameObject.AddComponent<AnglesTextTut01> ();
		col3.gameObject.AddComponent<AnglesTextTut01> ();

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

		col1.gameObject.GetComponent<AnglesTextTut01> ().SetAngle (angle1);
		col2.gameObject.GetComponent<AnglesTextTut01> ().SetAngle (angle2);
		col3.gameObject.GetComponent<AnglesTextTut01> ().SetAngle (angle3);

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
	
		BoxCollider col1 = new GameObject("Line Collider " + (tempNum - 2).ToString ()).AddComponent<BoxCollider> ();
		BoxCollider col2 = new GameObject("Line Collider " + (tempNum - 1).ToString ()).AddComponent<BoxCollider> ();
		BoxCollider col3 = new GameObject("Line Collider " + tempNum.ToString ()).AddComponent<BoxCollider> ();

		col1.gameObject.AddComponent<BounceSoundTut01> ();
		col2.gameObject.AddComponent<BounceSoundTut01> ();
		col3.gameObject.AddComponent<BounceSoundTut01> ();

		BounceSoundTut01 bounce1 = col1.gameObject.GetComponent<BounceSoundTut01> ();
		BounceSoundTut01 bounce2 = col2.gameObject.GetComponent<BounceSoundTut01> ();
		BounceSoundTut01 bounce3 = col3.gameObject.GetComponent<BounceSoundTut01> ();
		
		bounce1.SetInfo ();
		bounce2.SetInfo ();
		bounce3.SetInfo ();

		col1.gameObject.AddComponent<AnglesTextTut01> ();
		col2.gameObject.AddComponent<AnglesTextTut01> ();
		col3.gameObject.AddComponent<AnglesTextTut01> ();
		
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

		col1.gameObject.GetComponent<AnglesTextTut01> ().SetAngle (angle1);
		col2.gameObject.GetComponent<AnglesTextTut01> ().SetAngle (angle2);
		col3.gameObject.GetComponent<AnglesTextTut01> ().SetAngle (angle3);
	}

	public void DestroyDotsAndLines () {
		Destroy (GameObject.Find ("Grid Dot " + (numOfTotalGridDots - 2).ToString ()).gameObject);
		Destroy (GameObject.Find ("Grid Dot " + (numOfTotalGridDots - 1).ToString ()).gameObject);
		Destroy (GameObject.Find ("Grid Dot " + (numOfTotalGridDots).ToString ()).gameObject);
		
		Destroy (GameObject.Find ("Triangle Line " + (numOfTotalGridDots - 2).ToString ()).gameObject);
		Destroy (GameObject.Find ("Triangle Line " + (numOfTotalGridDots - 1).ToString ()).gameObject);
		Destroy (GameObject.Find ("Triangle Line " + (numOfTotalGridDots).ToString ()).gameObject);
		
		numOfTotalGridDots -= 3;
	}

	public void DestroyLines (int tempNum) {
		Destroy (GameObject.Find ("Triangle Line " + (tempNum - 2).ToString ()).gameObject);
		Destroy (GameObject.Find ("Triangle Line " + (tempNum - 1).ToString ()).gameObject);
		Destroy (GameObject.Find ("Triangle Line " + (tempNum).ToString ()).gameObject);
	}

	public void SetCurrentGridDot (GameObject thisGridDot) {
		//Debug.Log ("Set recreated dot");
		currentGridDot = thisGridDot;
		gridDotSelected = true;
		
		int j = 0;
		while (true) {
			if (currentGridDot.transform.position == gridDots [j].transform.position) {
				if( ((j+1)%3 == 0) && (gridDots [j] != null)) {
					DestroyLines (j+1);
				} else if (((j+2)%3 == 0) && (gridDots [j+1] != null)) {
					DestroyLines (j+2);
				} else if (((j+3)%3 == 0) && (gridDots [j+2] != null)) {
					DestroyLines (j+3);
				}
				break;
			}
			j++;
		}	
	}

	public void SpecialOccasionRequiresAttention () {
		gridDotSelected = false;
		int j = 0;
		while (true) {
			if (currentGridDot.transform.position == gridDots [j].transform.position) {
				if( ((j+1)%3 == 0) && (gridDots [j] != null)) {
					RecreateTriangle (j+1);
				} else if (((j+2)%3 == 0) && (gridDots [j+1] != null)) {
					RecreateTriangle (j+2);
				} else if (((j+3)%3 == 0) && (gridDots [j+2] != null)) {
					RecreateTriangle (j+3);
				}
				break;
			}
			j++;
		}
	}

	public bool SelectTriangleLines (float lengthOfLine, GameObject selectedTriangleLine, float selectedTriangeLineAngle, string nameOfLine) {
		if (numOfSelectedLines == 0) {
			firstSelectedLine = selectedTriangleLine;
			firstSelectedTriangleLine = (int) Mathf.Round (selectedTriangeLineAngle);
			if (firstSelectedTriangleLine < 0) {
				numOfNegativeAngles += 1;
			} else if ((firstSelectedTriangleLine > 0) && (firstSelectedTriangleLine != 90f) && (firstSelectedTriangleLine != 0f)) {
				numOfPositiveAngles += 1;
			}
			
			int k = 1;
			//int twoLinesFound = 0;
			while (GameObject.Find ("Line Collider " + k.ToString ()) != null) {
				if (GameObject.Find ("Line Collider " + k.ToString ()).name.Equals (nameOfLine)) {
					if (k%3 == 0) {
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesTextTut01> ().startBlinking = true;
						GameObject.Find ("Line Collider " + (k-2).ToString ()).GetComponent<AnglesTextTut01> ().startBlinking = true;
						break;
					} else if ((k+1)%3 == 0) {
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesTextTut01> ().startBlinking = true;
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesTextTut01> ().startBlinking = true;
						break;
					} else if ((k+2)%3 == 0) {
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesTextTut01> ().startBlinking = true;
						GameObject.Find ("Line Collider " + (k+2).ToString ()).GetComponent<AnglesTextTut01> ().startBlinking = true;
						break;
					}
				} else {
					k++;
				}
			}
			
			//lengthOfFirstLine = lengthOfLine;
			numOfSelectedLines += 1;
			//Debug.Log (selectedTriangeLineAngle.ToString ());
			return true;
		} else if (numOfSelectedLines == 1) {
			Debug.Log ("we here");
			bool foundLine = false;
			int k = 1;
			//Debug.Log (nameOfLine);
			while (GameObject.Find ("Line Collider " + k.ToString ()) != null) {
				if (GameObject.Find ("Line Collider " + k.ToString ()).name.Equals (nameOfLine)) {
					//Debug.Log (GameObject.Find ("Line Collider " + k.ToString ()).GetComponent<AnglesText> ().startBlinking.ToString ());
					GameObject.Find ("Line Collider " + k.ToString ()).GetComponent<AnglesTextTut01> ().startBlinking = false;
					GameObject.Find ("Line Collider " + k.ToString ()).GetComponent<AnglesTextTut01> ().lineRend.material.color = Color.magenta;
					GameObject.Find ("Line Collider " + k.ToString ()).GetComponent<AnglesTextTut01> ().blinkingTimer = 0f;
					//Debug.Log ("Found Line");
					if (k%3 == 0) {
						if (firstSelectedLine.name.Equals ("Line Collider " + (k-1).ToString ())) {
							thirdSelectedLine = GameObject.Find ("Line Collider " + (k-2).ToString ());
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().startBlinking = false;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().lineRend.material.color = Color.magenta;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().blinkingTimer = 0f;
							foundLine = true;
							break;
						} else if (firstSelectedLine.name.Equals ("Line Collider " + (k-2).ToString ())) {
							thirdSelectedLine = GameObject.Find ("Line Collider " + (k-1).ToString ());
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().startBlinking = false;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().lineRend.material.color = Color.magenta;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().blinkingTimer = 0f;
							foundLine = true;
							break;
						}
					} else if ((k+1)%3 == 0) {
						if (firstSelectedLine.name.Equals ("Line Collider " + (k+1).ToString ())) {
							thirdSelectedLine = GameObject.Find ("Line Collider " + (k-1).ToString ());
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().startBlinking = false;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().lineRend.material.color = Color.magenta;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().blinkingTimer = 0f;
							foundLine = true;
							break;
						} else if (firstSelectedLine.name.Equals ("Line Collider " + (k-1).ToString ())) {
							thirdSelectedLine = GameObject.Find ("Line Collider " + (k+1).ToString ());
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().startBlinking = false;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().lineRend.material.color = Color.magenta;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().blinkingTimer = 0f;
							foundLine = true;
							break;
						}
					} else if ((k+2)%3 == 0) {
						if (firstSelectedLine.name.Equals ("Line Collider " + (k+2).ToString ())) {
							thirdSelectedLine = GameObject.Find ("Line Collider " + (k+1).ToString ());
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().startBlinking = false;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().lineRend.material.color = Color.magenta;
							foundLine = true;
							break;
						} else if (firstSelectedLine.name.Equals ("Line Collider " + (k+1).ToString ())) {
							thirdSelectedLine = GameObject.Find ("Line Collider " + (k+2).ToString ());
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().startBlinking = false;
							thirdSelectedLine.GetComponent<AnglesTextTut01> ().lineRend.material.color = Color.magenta;
							foundLine = true;
							break;
						}
					}
				} else {
					k++;
				}
			}
			
			if (foundLine) {
				secondSelectedLine = selectedTriangleLine;
				
				secondSelectedTriangleLine = (int) Mathf.Round (selectedTriangeLineAngle);
				if (secondSelectedTriangleLine < 0) {
					numOfNegativeAngles += 1;
				} else if ((secondSelectedTriangleLine > 0) && (secondSelectedTriangleLine != 90f) && (secondSelectedTriangleLine != 0f)) {
					numOfPositiveAngles += 1;
				}
				
				float temp = thirdSelectedLine.GetComponent<AnglesTextTut01> ().angleOfLine;
				thirdSelectedTriangleLine = (int) Mathf.Round (temp);
				if (thirdSelectedTriangleLine < 0) {
					numOfNegativeAngles += 1;
				} else if ((thirdSelectedTriangleLine > 0) && (thirdSelectedTriangleLine != 90f) && (thirdSelectedTriangleLine != 0f)) {
					numOfPositiveAngles += 1;
				}
				
				numOfSelectedLines += 1;
				return true;
			}
		}
		return false;
		
	}

	public void playBounceSound () {
		soundClip.clip = bounceFX;
		soundClip.Play ();

		//tutorialCtrl1.startPart5 = false;
		//tutorialCtrl1.startPart6 = true;
		//tutorialCtrl1.freezeTime = true;
	}

	void CalculateAngles () {
		Debug.Log (numOfNegativeAngles.ToString () + " & " + numOfPositiveAngles.ToString ());
		
		/*Here we have multiple cases for calculating the different angles in each triangle*/
		
		//One negative angle only
		//3 cases
		//Status: Good to go!
		if ((numOfNegativeAngles == 1) && (numOfPositiveAngles == 0)) {
			//Case 1
			if ((firstSelectedTriangleLine == 90f && secondSelectedTriangleLine == 0f) ||
			    (firstSelectedTriangleLine == 0f && secondSelectedTriangleLine == 90f)) {
				finalAngle = firstSelectedTriangleLine + secondSelectedTriangleLine;
			} 
			//Case 2
			else if ((firstSelectedTriangleLine == 90f && secondSelectedTriangleLine < 0f) ||
			         (firstSelectedTriangleLine < 0f && secondSelectedTriangleLine == 90f)) {
				finalAngle = firstSelectedTriangleLine + secondSelectedTriangleLine;
			} 
			//Case 3
			else if ((firstSelectedTriangleLine == 0f && secondSelectedTriangleLine < 0f) ||
			         (firstSelectedTriangleLine < 0f && secondSelectedTriangleLine == 0f)) {
				finalAngle = Mathf.Abs ((int)Mathf.Round (firstSelectedTriangleLine)) + Mathf.Abs ((int)Mathf.Round (secondSelectedTriangleLine));
			}
		}
		//One positive angle only
		//4 cases
		//Status: Good to go!
		else if (numOfPositiveAngles == 1 && numOfNegativeAngles == 0) {
			//Case 1
			if ((firstSelectedTriangleLine == 90f && secondSelectedTriangleLine == 0f) ||
			    (firstSelectedTriangleLine == 0f && secondSelectedTriangleLine == 90f)) {
				finalAngle = firstSelectedTriangleLine + secondSelectedTriangleLine;
			} 
			//Case 2
			else if (firstSelectedTriangleLine == 90f && secondSelectedTriangleLine > 0f) {
				finalAngle = firstSelectedTriangleLine - secondSelectedTriangleLine;
			} 
			//Case 3
			else if (firstSelectedTriangleLine > 0f && secondSelectedTriangleLine == 90f) {
				finalAngle = secondSelectedTriangleLine - firstSelectedTriangleLine;
			} 
			//Case 4
			else if ((firstSelectedTriangleLine == 0f && secondSelectedTriangleLine > 0f) ||
			         (firstSelectedTriangleLine > 0f && secondSelectedTriangleLine == 0f)) {
				finalAngle = Mathf.Abs ((int)Mathf.Round (firstSelectedTriangleLine)) + Mathf.Abs ((int)Mathf.Round (secondSelectedTriangleLine));
			}
		}
		//One negative angle and one positive angle only
		//5 cases
		//Status: Good to go!
		else if (numOfNegativeAngles == 1 && numOfPositiveAngles == 1) {
			//Case 1
			if ((firstSelectedTriangleLine == 90f && secondSelectedTriangleLine < 0f) ||
			    (firstSelectedTriangleLine < 0f && secondSelectedTriangleLine == 90f)) {
				finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine + (int)secondSelectedTriangleLine);
			} 
			//Case 2
			else if ((firstSelectedTriangleLine == 0f && secondSelectedTriangleLine < 0f) ||
			         (firstSelectedTriangleLine < 0f && secondSelectedTriangleLine == 0f)) {
				finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine + (int)secondSelectedTriangleLine);
			}
			//Case 3
			else if ((firstSelectedTriangleLine == 90f && secondSelectedTriangleLine > 0f) ||
			         (firstSelectedTriangleLine > 0f && secondSelectedTriangleLine == 90f)) {
				finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine - (int)secondSelectedTriangleLine);
			} 
			//Case 4
			else if ((firstSelectedTriangleLine == 0f && secondSelectedTriangleLine > 0f) ||
			         (firstSelectedTriangleLine > 0f && secondSelectedTriangleLine == 0f)) {
				finalAngle = firstSelectedTriangleLine + secondSelectedTriangleLine;
			}
			//Case 5
			else if ((firstSelectedTriangleLine > 0f && secondSelectedTriangleLine < 0f) ||
			         (firstSelectedTriangleLine < 0f && secondSelectedTriangleLine > 0f)) {
				//Case 5.1
				if (thirdSelectedTriangleLine == 90f) {
					finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine) + Mathf.Abs ((int)secondSelectedTriangleLine);
				} 
				//Case 5.2
				else if (thirdSelectedTriangleLine == 0f) {
					Debug.Log ("C'mon");
					finalAngle = 180f - Mathf.Abs ((int)firstSelectedTriangleLine) - Mathf.Abs ((int)secondSelectedTriangleLine);
				}
			}
		}
		//Two negative angles only
		//3 cases
		//Status: Good to go!
		else if (numOfNegativeAngles == 2 && numOfPositiveAngles == 0) {
			//Case 1.1
			if (firstSelectedTriangleLine == 90f) {
				//Case 1.1.1
				if (Mathf.Abs ((int)secondSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = firstSelectedTriangleLine + Mathf.Abs ((int)secondSelectedTriangleLine);
				}
				//Case 1.1.2
				else if (Mathf.Abs ((int)secondSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = firstSelectedTriangleLine - Mathf.Abs ((int)secondSelectedTriangleLine);
				}
			} 
			//Case 1.2
			else if (secondSelectedTriangleLine == 90f) {
				//Case 1.2.1
				if (Mathf.Abs ((int)firstSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = secondSelectedTriangleLine + Mathf.Abs ((int)firstSelectedTriangleLine);
				}
				//Case 1.2.2
				else if (Mathf.Abs ((int)firstSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = secondSelectedTriangleLine - Mathf.Abs ((int)firstSelectedTriangleLine);
				}
			}
			//Case 2.1
			else if (firstSelectedTriangleLine == 0f) {
				//Case 2.1.1
				if (Mathf.Abs ((int)secondSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = firstSelectedTriangleLine + Mathf.Abs ((int)secondSelectedTriangleLine);
				}
				//Case 2.1.2
				else if (Mathf.Abs ((int)secondSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = 180f - firstSelectedTriangleLine - Mathf.Abs ((int)secondSelectedTriangleLine);
				}
			}
			//Case 2.2
			else if (secondSelectedTriangleLine == 0f) {
				//Case 2.2.1
				if (Mathf.Abs ((int)firstSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = secondSelectedTriangleLine + Mathf.Abs ((int)firstSelectedTriangleLine);
				}
				//Case 2.2.2
				else if (Mathf.Abs ((int)firstSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = 180f - secondSelectedTriangleLine - Mathf.Abs ((int)firstSelectedTriangleLine);
				}
			}
			//Case 3
			else if (firstSelectedTriangleLine < 0f && secondSelectedTriangleLine < 0f) {
				finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine) - Mathf.Abs ((int)secondSelectedTriangleLine);
			}
		}
		//Two positive angles only
		//3 cases
		//Status: Good to go!
		else if (numOfNegativeAngles == 0 && numOfPositiveAngles == 2) {
			//Case 1.1
			if (firstSelectedTriangleLine == 90f) {
				//Case 1.1.1
				if (Mathf.Abs ((int)secondSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = firstSelectedTriangleLine + Mathf.Abs ((int)secondSelectedTriangleLine);
				}
				//Case 1.1.2
				else if (Mathf.Abs ((int)secondSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = firstSelectedTriangleLine - Mathf.Abs ((int)secondSelectedTriangleLine);
				}
			} 
			//Case 1.2
			else if (secondSelectedTriangleLine == 90f) {
				//Case 1.2.1
				if (Mathf.Abs ((int)firstSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = secondSelectedTriangleLine + Mathf.Abs ((int)firstSelectedTriangleLine);
				}
				//Case 1.2.2
				else if (Mathf.Abs ((int)firstSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = secondSelectedTriangleLine - Mathf.Abs ((int)firstSelectedTriangleLine);
				}
			}
			//Case 2.1
			else if (firstSelectedTriangleLine == 0f) {
				//Case 2.1.1
				if (Mathf.Abs ((int)secondSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = firstSelectedTriangleLine + Mathf.Abs ((int)secondSelectedTriangleLine);
				}
				//Case 2.1.2
				else if (Mathf.Abs ((int)secondSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = 180f - firstSelectedTriangleLine - Mathf.Abs ((int)secondSelectedTriangleLine);
				}
			}
			//Case 2.2
			else if (secondSelectedTriangleLine == 0f) {
				//Case 2.2.1
				if (Mathf.Abs ((int)firstSelectedTriangleLine) < Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = secondSelectedTriangleLine + Mathf.Abs ((int)firstSelectedTriangleLine);
				}
				//Case 2.2.2
				else if (Mathf.Abs ((int)firstSelectedTriangleLine) > Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = 180f - secondSelectedTriangleLine - Mathf.Abs ((int)firstSelectedTriangleLine);
				}
			}
			//Case 3
			else if (firstSelectedTriangleLine > 0f && secondSelectedTriangleLine > 0f) {
				finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine) - Mathf.Abs ((int)secondSelectedTriangleLine);
			}
		}
		//Two negative angles and one positive angle
		//2 cases
		//Status: Good to go!
		else if (numOfNegativeAngles == 2 && numOfPositiveAngles == 1) {
			//Case 1
			if (firstSelectedTriangleLine >= 0f) {
				//Case 1.1
				if (secondSelectedTriangleLine <= 0f && Mathf.Abs ((int)secondSelectedTriangleLine) >= Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = 180f - firstSelectedTriangleLine - Mathf.Abs ((int)secondSelectedTriangleLine);
				}
				//Case 1.2
				else if (secondSelectedTriangleLine <= 0f && Mathf.Abs ((int)secondSelectedTriangleLine) <= Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = firstSelectedTriangleLine + Mathf.Abs ((int)secondSelectedTriangleLine);
				}
			}
			//Case 2
			else if (firstSelectedTriangleLine <= 0f) {
				//Case 2.1
				if (secondSelectedTriangleLine <= 0f) {
					finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine - (int)secondSelectedTriangleLine);
				}
				//Case 2.2
				else if (secondSelectedTriangleLine >= 0f && Mathf.Abs ((int)thirdSelectedTriangleLine) >= Mathf.Abs ((int)firstSelectedTriangleLine)) {
					finalAngle = secondSelectedTriangleLine + Mathf.Abs ((int)firstSelectedTriangleLine);
				}
				//Case 2.3
				else {
					finalAngle = 180f - secondSelectedTriangleLine - Mathf.Abs ((int)firstSelectedTriangleLine);
				}
			}
		}
		//Two positive angles and one negative angle
		//2 cases
		//Status: Good to go!
		else if (numOfNegativeAngles == 1 && numOfPositiveAngles == 2) {
			//Case 1
			if (firstSelectedTriangleLine <= 0f) {
				//Case 1.1
				if (secondSelectedTriangleLine >= 0f && Mathf.Abs ((int)secondSelectedTriangleLine) >= Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = 180f - Mathf.Abs ((int)firstSelectedTriangleLine) - secondSelectedTriangleLine;
				}
				//Case 1.2
				else if (secondSelectedTriangleLine >= 0f && Mathf.Abs ((int)secondSelectedTriangleLine) <= Mathf.Abs ((int)thirdSelectedTriangleLine)) {
					finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine) + secondSelectedTriangleLine;
				}
			}
			//Case 2
			else if (firstSelectedTriangleLine >= 0f) {
				//Case 2.1
				if (secondSelectedTriangleLine >= 0f) {
					finalAngle = Mathf.Abs ((int)firstSelectedTriangleLine - secondSelectedTriangleLine);
				}
				//Case 2.2
				else if (secondSelectedTriangleLine <= 0f && Mathf.Abs ((int)thirdSelectedTriangleLine) >= Mathf.Abs ((int)firstSelectedTriangleLine)) {
					finalAngle = Mathf.Abs ((int)secondSelectedTriangleLine) + firstSelectedTriangleLine;
				}
				//Case 2.3
				else {
					finalAngle = 180f - Mathf.Abs ((int)secondSelectedTriangleLine) - firstSelectedTriangleLine;
				}
			}
		}
		//Three negative angles
		//3 cases
		//Status: Good to go!
		else if (numOfNegativeAngles == 3 && numOfPositiveAngles == 0) {
			//Case 1
			if (firstSelectedTriangleLine >= secondSelectedTriangleLine && firstSelectedTriangleLine >= thirdSelectedTriangleLine) {
				//Case 1.1
				if (secondSelectedTriangleLine >= thirdSelectedTriangleLine) {
					finalAngle = Mathf.Abs ((int) firstSelectedTriangleLine - (int) secondSelectedTriangleLine);
				}
				//Case 1.2
				else if (secondSelectedTriangleLine <= thirdSelectedTriangleLine) {
					Debug.Log ("180, " + firstSelectedTriangleLine.ToString () + ", " + secondSelectedTriangleLine.ToString ());
					finalAngle = 180f + Mathf.Abs ((int) firstSelectedTriangleLine) - Mathf.Abs ((int) secondSelectedTriangleLine);
				}
			}
			//Case 2
			if ((firstSelectedTriangleLine >= secondSelectedTriangleLine && firstSelectedTriangleLine <= thirdSelectedTriangleLine) ||
			    (firstSelectedTriangleLine <= secondSelectedTriangleLine && firstSelectedTriangleLine >= thirdSelectedTriangleLine)) {
				finalAngle = Mathf.Abs ((int) firstSelectedTriangleLine - (int) secondSelectedTriangleLine);
			}
			//Case 3
			if (firstSelectedTriangleLine <= secondSelectedTriangleLine && firstSelectedTriangleLine <= thirdSelectedTriangleLine) {
				//Case 3.1
				if (secondSelectedTriangleLine <= thirdSelectedTriangleLine) {
					finalAngle = Mathf.Abs ((int) firstSelectedTriangleLine - (int) secondSelectedTriangleLine);
				}
				//Case 3.2
				else if (secondSelectedTriangleLine >= thirdSelectedTriangleLine) {
					finalAngle = 180f - Mathf.Abs ((int) firstSelectedTriangleLine) + Mathf.Abs ((int) secondSelectedTriangleLine);
				}
			}
		}
		//Three positive angles
		//3 Cases
		//Status: Good to go!
		else if (numOfNegativeAngles == 0 && numOfPositiveAngles == 3) {
			//Case 1
			if (firstSelectedTriangleLine >= secondSelectedTriangleLine && firstSelectedTriangleLine >= thirdSelectedTriangleLine) {
				//Case 1.1
				if (secondSelectedTriangleLine >= thirdSelectedTriangleLine) {
					finalAngle = Mathf.Abs ((int) firstSelectedTriangleLine - (int) secondSelectedTriangleLine);
				}
				//Case 1.2
				else if (secondSelectedTriangleLine <= thirdSelectedTriangleLine) {
					Debug.Log ("180, " + firstSelectedTriangleLine.ToString () + ", " + secondSelectedTriangleLine.ToString ());
					finalAngle = 180f - Mathf.Abs ((int) firstSelectedTriangleLine) + Mathf.Abs ((int) secondSelectedTriangleLine);
				}
			}
			//Case 2
			if ((firstSelectedTriangleLine >= secondSelectedTriangleLine && firstSelectedTriangleLine <= thirdSelectedTriangleLine) ||
			    (firstSelectedTriangleLine <= secondSelectedTriangleLine && firstSelectedTriangleLine >= thirdSelectedTriangleLine)) {
				finalAngle = Mathf.Abs ((int) firstSelectedTriangleLine - (int) secondSelectedTriangleLine);
			}
			//Case 3
			if (firstSelectedTriangleLine <= secondSelectedTriangleLine && firstSelectedTriangleLine <= thirdSelectedTriangleLine) {
				//Case 3.1
				if (secondSelectedTriangleLine <= thirdSelectedTriangleLine) {
					finalAngle = Mathf.Abs ((int) firstSelectedTriangleLine - (int) secondSelectedTriangleLine);
				}
				//Case 3.2
				else if (secondSelectedTriangleLine >= thirdSelectedTriangleLine) {
					finalAngle = 180f + Mathf.Abs ((int) firstSelectedTriangleLine) - Mathf.Abs ((int) secondSelectedTriangleLine);
				}
			}
		}
		
		numOfNegativeAngles = 0;
		numOfPositiveAngles = 0;

		if (tutorialCtrl1.messageCurrentlyOn == 18 | tutorialCtrl1.messageCurrentlyOn == 20) {
			tutorialCtrl1.inTutorialAT = false;
			tutorialCtrl1.messageCurrentlyOn += 1;
			tutorialCtrl1.startPart4 = true;
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