using UnityEngine;
using System.Collections;

public class ManipulateVerticesTut03 : MonoBehaviour {
	
	public GridLinesTut03 gridLines;
	public TriangleControllerTut03 triangleController;
	public TutorialControllerLvl3 tutorialCtrl1;
	public TextControllerTut03 textController;

	public Camera cam;
	public Color startColor;
	public Renderer rend;

	private bool allowMouseOver;
	private bool highlighted;
	public bool isDotHighlighted;

	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		
		highlighted = false;
		isDotHighlighted = false;
		allowMouseOver = false;

		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut03> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut03> ();
		tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl3> ();
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut03> ();
		cam = GameObject.Find ("Game View").GetComponent<Camera> ();

	}

	void Update () {
		if (tutorialCtrl1.inTutorialMV && !textController.hasWon) {
			if (gridLines.stopTime) {
				allowMouseOver = true;
			} else if (!gridLines.stopTime) {
				allowMouseOver = false;
			}
		}

	}

	void OnMouseEnter () {
		if (allowMouseOver && !highlighted) {
			rend.material.color = Color.yellow;
			//triangleController.doNotCreateDot = true;
		}
	}

	void OnMouseExit () {
		if (allowMouseOver && !highlighted) {
			rend.material.color = startColor;
			//triangleController.doNotCreateDot = false;
		}

	}


	void OnMouseUp () {
		//Add one to number of moves performed
		if (isDotHighlighted) {
			highlighted = false;
			isDotHighlighted = false;

			rend.material.color = startColor;
		}
	}

	
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
	}
}
