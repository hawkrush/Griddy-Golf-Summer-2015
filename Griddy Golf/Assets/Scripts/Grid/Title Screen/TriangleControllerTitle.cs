using UnityEngine;
using System.Collections;

public class TriangleControllerTitle : MonoBehaviour {

	public GameObject gridDot;
	public GameObject createdGridDot;
	public LineRenderer lineRenderer;
	public AudioSource soundClip;
	public AudioClip bounceFX, dotsFX;

	public BounceSoundTitle bounceSound;
	//public GridLines gridLines;
	//public ManipulateVertices manipulateVertices;
	//public TextController textController;
	public GameObject tileDots;
	public TileDotsController tileDotsController;

	private Vector3 mousePos;
	private Vector3 gridDotPos;
	public int numOfGridDots;
	public int numOfTotalGridDots;
	public int maxNumOfGridDots;
	public int numOfSelectedLines;
	public GameObject currentGridDot;
	public int numOfTriangleLines;

	public LineRenderer lr1, lr2, lr3;
	public static GameObject[] gridDots;

	void Start () {
		lineRenderer = GameObject.Find ("TriangleLineRenderer").GetComponent<LineRenderer> ();
		
		numOfGridDots = 0;
		gridDots = new GameObject[maxNumOfGridDots];
		
		numOfTotalGridDots = 0;

		/*First triangle*/
		CreateGridDot (new Vector3 (-1.0f, -12.3f, 28.7f));
		CreateGridDot (new Vector3 (-1.0f, -12.3f, 24.7f));
		CreateGridDot (new Vector3 (0.5f, -12.3f, 28.7f));
		/*Second triangle*/
		CreateGridDot (new Vector3 (3.0f, -12.3f, 28.7f));
		CreateGridDot (new Vector3 (4.0f, -12.3f, 28.7f));
		CreateGridDot (new Vector3 (3.5f, -12.3f, 32.2f));
		/*Third triangle*/
		CreateGridDot (new Vector3 (0.0f, -12.3f, 34.7f));
		CreateGridDot (new Vector3 (2.5f, -12.3f, 34.7f));
		CreateGridDot (new Vector3 (2.5f, -12.3f, 33.2f));
		/*Fourth triangle*/
		CreateGridDot (new Vector3 (-4.0f, -12.3f, 34.7f));
		CreateGridDot (new Vector3 (-2.0f, -12.3f, 34.7f));
		CreateGridDot (new Vector3 (-5.0f, -12.3f, 32.7f));
		/*Fifth triangle*/
		CreateGridDot (new Vector3 (-6.0f, -12.3f, 32.7f));
		CreateGridDot (new Vector3 (-6.0f, -12.3f, 28.7f));
		CreateGridDot (new Vector3 (-4.0f, -12.3f, 28.7f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateGridDot (Vector3 tileDotPos) {
		Debug.Log ("title start");
		if (numOfTotalGridDots < maxNumOfGridDots) {
			//mousePos = Input.mousePosition;
			//mousePos.z = 26.75f;
			//gridDotPos = cam.ScreenToWorldPoint (mousePos);
			createdGridDot = Instantiate (gridDot, tileDotPos, gridDot.transform.rotation) as GameObject;
			createdGridDot.transform.position = new Vector3 (createdGridDot.transform.position.x, 
			                                                 -12.95978f, 
			                                                 createdGridDot.transform.position.z);
			gridDots [numOfTotalGridDots] = createdGridDot;
			//gridDots[numOfTotalGridDots].name = "Grid Dot " + numOfTotalGridDots.ToString ();
			numOfGridDots += 1;
			numOfTotalGridDots += 1;
			createdGridDot.name = "Grid Dot " + numOfTotalGridDots.ToString ();
			gridDots [numOfTotalGridDots - 1].name = "Grid Dot " + numOfTotalGridDots.ToString ();
			
			//soundClip.clip = dotsFX;
			//soundClip.Play ();
			
			if (numOfTotalGridDots % 3 == 0) {
				CreateTriangle ();
				numOfGridDots = 0;
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
		
		col1.gameObject.AddComponent<BounceSoundTitle> ();
		col2.gameObject.AddComponent<BounceSoundTitle> ();
		col3.gameObject.AddComponent<BounceSoundTitle> ();
		
		BounceSoundTitle bounce1 = col1.gameObject.GetComponent<BounceSoundTitle> ();
		BounceSoundTitle bounce2 = col2.gameObject.GetComponent<BounceSoundTitle> ();
		BounceSoundTitle bounce3 = col3.gameObject.GetComponent<BounceSoundTitle> ();
		
		bounce1.SetInfo ();
		bounce2.SetInfo ();
		bounce3.SetInfo ();
		
		//col1.gameObject.AddComponent<AnglesText> ();
		//col2.gameObject.AddComponent<AnglesText> ();
		//col3.gameObject.AddComponent<AnglesText> ();
		
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
		
		//col1.gameObject.GetComponent<AnglesText> ().SetAngle (angle1);
		//col2.gameObject.GetComponent<AnglesText> ().SetAngle (angle2);
		//col3.gameObject.GetComponent<AnglesText> ().SetAngle (angle3);
		
		//- See more at: http://www.theappguruz.com/unity/add-collider-to-line-renderer-unity/#sthash.ICkbKemQ.dpuf
		//
		//hasBeenCreated = true;
		
	}

	public void playBounceSound () {
		soundClip.clip = bounceFX;
		soundClip.Play ();
		
	}
}
