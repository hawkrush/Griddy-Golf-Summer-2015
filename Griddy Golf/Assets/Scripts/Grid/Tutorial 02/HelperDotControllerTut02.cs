using UnityEngine;
using System.Collections;

public class HelperDotControllerTut02 : MonoBehaviour {

	public TriangleControllerTut02 triangleController;
	public TutorialControllerLvl2 tutorialCtrl1;
	public GridLinesTut02 gridLines;
	
	public Color startColor;
	public Renderer rend;
	
	private bool allowMouseOver;
	//private bool highlighted;
	//public bool isDotHighlighted;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		
		//highlighted = false;
		//isDotHighlighted = false;
		allowMouseOver = false;
		
		//origHelperDot = GetComponent
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut02> ();
		tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl2> ();
		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut02> ();
		
		//InstantiateHelperDots ();
	}
	
	void Update () {
		//We need 
		if (tutorialCtrl1.inTutorialHDC || tutorialCtrl1.inTutorialMV) {
			if (gridLines.stopTime) {
				allowMouseOver = true;
				//Debug.Log ("let's do this");
			} else if (!gridLines.stopTime) {
				allowMouseOver = false;
			}
		}
		
	}
	
	void OnMouseEnter () {
		if (allowMouseOver && (tutorialCtrl1.inTutorialHDC || tutorialCtrl1.inTutorialMV)) {
			rend.material.color = Color.yellow;
			//triangleController.doNotCreateDot = true;
		}
	}
	
	void OnMouseExit () {
		if (allowMouseOver && (tutorialCtrl1.inTutorialHDC || tutorialCtrl1.inTutorialMV)) {
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
	}*/
	
	
	void OnMouseUp () { 
		if (allowMouseOver && tutorialCtrl1.inTutorialHDC) {
			//highlighted = true;
			//isDotHighlighted = true;
			triangleController.doNotCreateDot = true;
			triangleController.TutCreateGridDot (this.transform.position);
			Destroy (this.gameObject);
		} else if (allowMouseOver && tutorialCtrl1.inTutorialMV && triangleController.gridDotSelected) {
			Debug.Log ("c'mon already");
			//triangleController.doNotCreateDot = false;
			triangleController.RecreateGridDot (this.gameObject);
			//triangleController.SetCurrentGridDot (this.gameObject);
			Destroy (this.gameObject);
			tutorialCtrl1.inTutorialMV = false;
			tutorialCtrl1.messageCurrentlyOn += 4;
			if (tutorialCtrl1.messageCurrentlyOn != 18) {//15
				triangleController.UpdateGridDotsAndLines (gridLines.stopTime);
				tutorialCtrl1.startPart2 = true;
			} else {
				triangleController.UpdateGridDotsAndLines (gridLines.stopTime);
				tutorialCtrl1.startPart3 = true; //part3
			}
		}
	}

	/*
	void OnTriggerEnter (Collider other) {
		Debug.Log ("collision detected");
		if (other.name.Equals ("Grid Dot 1") || other.name.Equals ("Grid Dot 2") || other.name.Equals ("Grid Dot 3")) {
			other.transform.position = this.transform.position;
			Destroy (this.gameObject);
			tutorialCtrl1.inTutorialMV = false;
			tutorialCtrl1.messageCurrentlyOn += 1;
			rend.material.color = startColor;
			other.GetComponent<ManipulateVerticesTut02> ().startBlinking = false;
		}
	}
	*/
}
