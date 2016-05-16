using UnityEngine;
using System.Collections;

public class ManipulateVertices : MonoBehaviour {
	
	public GridLines gridLines;
	public TriangleController triangleController;
	public TextController textController;
	public TileDotsController tileDotsController;

	public Camera cam;
	public Color startColor;
	public Renderer rend;

	private bool allowMouseOver;
	private bool highlighted;
	public bool isDotHighlighted;
	private bool isSelected;

	private Vector3 mousePos;


	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		
		highlighted = false;
		isDotHighlighted = false;
		allowMouseOver = false;
		isSelected = false;

		if (!Application.loadedLevelName.Equals ("Mini Golf Editor Title Screen")) {
			gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLines> ();
			triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleController> ();
			textController = GameObject.Find ("Number of Tries").GetComponent<TextController> ();
			cam = GameObject.Find ("Game View").GetComponent<Camera> ();
		}

	}

	void Update () {
		if (!Application.loadedLevelName.Equals ("Mini Golf Editor Title Screen")) {
			if (!textController.hasWon) {
				if (gridLines.stopTime) {
					allowMouseOver = true;
				} else if (!gridLines.stopTime) {
					allowMouseOver = false;
				}

				if (Input.GetButtonUp ("Interact") && isSelected) {
					highlighted = false;
					isDotHighlighted = false;
					isSelected = false;
					rend.material.color = startColor;
					triangleController.SpecialOccasionRequiresAttention ();
				}
			}
		}
	}

	void OnMouseEnter () {
		if (allowMouseOver && !highlighted && !triangleController.gridDotSelected) {
			rend.material.color = Color.yellow;
			//triangleController.doNotCreateDot = true;
		}
	}

	void OnMouseExit () {
		if (allowMouseOver && !highlighted && !triangleController.gridDotSelected) {
			rend.material.color = startColor;
			//triangleController.doNotCreateDot = false;
		}

	}


	void OnMouseUp () {
		//Add one to number of moves performed
		if (isDotHighlighted) {
			highlighted = false;
			isDotHighlighted = false;
			isSelected = false;
			rend.material.color = startColor;
			triangleController.gridDotSelected = false;
			triangleController.RecreateGridDot (this.transform.position);
		} else if (!isDotHighlighted && !triangleController.gridDotSelected) {
			Debug.Log ("First step to recreate dot");
			highlighted = true;
			isDotHighlighted = true;
			isSelected = true;
			rend.material.color = Color.yellow;
			triangleController.SetCurrentGridDot (this.gameObject);
			triangleController.numOfSelectedLines = 0;
		}
	}

	/*
	void OnMouseDrag () { 
		if (allowMouseOver) {
			highlighted = true;
			isDotHighlighted = true;

			triangleController.doNotCreateDot = true;

			rend.material.color = Color.magenta;

			mousePos = Input.mousePosition;
			mousePos.z = 26.75f;

			this.transform.position = cam.ScreenToWorldPoint(mousePos);
			this.transform.position = new Vector3 (this.transform.position.x, -12f, this.transform.position.z);

			int tempNum = triangleController.numOfTotalGridDots;
			if (tempNum%3 == 0) {
				int tempNum2 = tempNum;
				while (tempNum2 != 0) {
					//Debug.Log ("Again");
					triangleController.DestroyLines (tempNum2);
					triangleController.RecreateTriangle (tempNum2);

					tempNum2 -= 3;
				}

			} else if ((tempNum - 1)%3 == 0) {
				int tempNum2 = tempNum - 1;
				while (tempNum2 != 0) {
					triangleController.DestroyLines (tempNum2);
					triangleController.RecreateTriangle (tempNum2);
					
					tempNum2 -= 3;
				}

			} else if ((tempNum - 2)%3 == 0) {
				int tempNum2 = tempNum - 2;
				while (tempNum2 != 0) {
					triangleController.DestroyLines (tempNum2);
					triangleController.RecreateTriangle (tempNum2);
					
					tempNum2 -= 3;
				}

			}

			//triangleController.UpdateGridDotsAndLines (gridLines.stopTime);
		}
	}*/
}
