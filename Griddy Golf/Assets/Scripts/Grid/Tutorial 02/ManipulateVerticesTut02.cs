using UnityEngine;
using System.Collections;

public class ManipulateVerticesTut02 : MonoBehaviour {
	
	public GridLinesTut02 gridLines;
	public TriangleControllerTut02 triangleController;
	public TutorialControllerLvl2 tutorialCtrl1;
	public TextControllerTut02 textController;


	public Camera cam;
	public Color startColor;
	public Renderer rend;

	private bool allowMouseOver;
	private bool highlighted;
	public bool isDotHighlighted;
	public bool startBlinking;
	public bool isSelected;

	public bool numOfAdjustmants;
	private Vector3 mousePos;

	private float blinkingTimer;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		startBlinking = false;
		
		highlighted = false;
		isDotHighlighted = false;
		allowMouseOver = false;
		isSelected = false;

		blinkingTimer = 0f;

		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut02> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut02> ();
		tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl2> ();
		//textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut02> ();
		cam = GameObject.Find ("Game View").GetComponent<Camera> ();

	}

	void Update () {
		if (gridLines.stopTime && tutorialCtrl1.inTutorialMV) {
			allowMouseOver = true;
		} else if (!gridLines.stopTime && tutorialCtrl1.inTutorialMV) {
			allowMouseOver = false;
		}

		if (startBlinking) {
			blinkingTimer += Time.unscaledDeltaTime;
			if (blinkingTimer >= 1f) {
				if (rend.material.color == startColor) {
					rend.material.color = Color.yellow;
				} else if (rend.material.color == Color.yellow) {
					rend.material.color = startColor;
				}
				blinkingTimer = 0f;
			}
		}

		if (Input.GetButtonUp ("Interact") && isSelected) {
			highlighted = false;
			isDotHighlighted = false;
			isSelected = false;
			rend.material.color = startColor;
			triangleController.SpecialOccasionRequiresAttention ();
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

	/*
	void OnMouseUp () {
		//Add one to number of moves performed
		if (isDotHighlighted) {
			highlighted = false;
			isDotHighlighted = false;

			rend.material.color = startColor;
		}
	}
	*/

	/*
	void OnMouseDrag () { 
		if (allowMouseOver && tutorialCtrl1.inTutorialMV && startBlinking) {
			//this.GetComponent<SphereCollider> ().isTrigger = true;

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

			if ((this.transform.position.x >= 5.52f && this.transform.position.x <= 5.56f) &&
			    (this.transform.position.z >= 27.920f && this.transform.position.x <= 27.929f) &&
			    startBlinking && (GameObject.Find ("Adjust Helper Dot 2.1") != null)) {
				Debug.Log ("done");
				allowMouseOver = false;
				this.transform.position = GameObject.Find ("Adjust Helper Dot 2.1").transform.position;
				Destroy (GameObject.Find ("Adjust Helper Dot 2.1").gameObject);
				tutorialCtrl1.inTutorialMV = false;
				tutorialCtrl1.messageCurrentlyOn += 1;
				tutorialCtrl1.startPart2 = true;
				rend.material.color = startColor;
				startBlinking = false;

				//Just destroy the lines at the end of the recreation;
				//Interesting bug
				triangleController.DestroyLines (3);
				//triangleController.DestroyLines (3);
				triangleController.RecreateTriangle (3);
			}

			else if ((this.transform.position.x >= 2.40f && this.transform.position.x <= 2.44f) &&
			    	 (this.transform.position.z >= 27.210f && this.transform.position.x <= 27.213f) &&
			   		  startBlinking && (GameObject.Find ("Adjust Helper Dot 2.2") != null)) {
				Debug.Log ("done");
				allowMouseOver = false;
				this.transform.position = GameObject.Find ("Adjust Helper Dot 2.2").transform.position;
				Destroy (GameObject.Find ("Adjust Helper Dot 2.2").gameObject);
				tutorialCtrl1.inTutorialMV = false;
				tutorialCtrl1.messageCurrentlyOn += 1;
				tutorialCtrl1.startPart3 = true;
				rend.material.color = startColor;
				startBlinking = false;
				
				//Just destroy the lines at the end of the recreation;
				//Interesting bug
				triangleController.DestroyLines (3);
				triangleController.DestroyLines (3);
				triangleController.RecreateTriangle (3);
			}
			//triangleController.UpdateGridDotsAndLines (gridLines.stopTime);
		}
	}
	*/

	void OnMouseUp () {
		//Add one to number of moves performed
		if (!isDotHighlighted && tutorialCtrl1.inTutorialMV && startBlinking) {
			triangleController.doNotCreateDot = true;
			Debug.Log ("stop blinking");
			highlighted = true;
			isDotHighlighted = true;
			isSelected = true;
			rend.material.color = Color.yellow;
			//triangleController.gridDotSelected = false;
			startBlinking = false;
			triangleController.SetCurrentGridDot (this.gameObject);
		} else if (isDotHighlighted && !triangleController.gridDotSelected && tutorialCtrl1.inTutorialMV && startBlinking) {
			triangleController.doNotCreateDot = false;
			//Debug.Log ("First step to recreate dot");
			Debug.Log ("stop blinking now");
			highlighted = false;
			isDotHighlighted = false;
			isSelected = false;
			rend.material.color = startColor;
			triangleController.gridDotSelected = false;
			//triangleController.SetCurrentGridDot (this.gameObject);
			triangleController.numOfSelectedLines = 0;
			startBlinking = true;
		}
	}
}
