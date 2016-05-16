using UnityEngine;
using System.Collections;

public class HelperDotControllerTut03 : MonoBehaviour {

	public TriangleControllerTut03 triangleController;
	public TutorialControllerLvl3 tutorialCtrl1;
	public GridLinesTut03 gridLines;
	
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
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut03> ();
		tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl3> ();
		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut03> ();
		
		//InstantiateHelperDots ();
	}
	
	void Update () {
		//We need 
		if (tutorialCtrl1.inTutorialHDC) {
			if (gridLines.stopTime) {
				allowMouseOver = true;
				//Debug.Log ("let's do this");
			} else if (!gridLines.stopTime) {
				allowMouseOver = false;
			}
		}
		
	}
	
	void OnMouseEnter () {
		if (allowMouseOver && tutorialCtrl1.inTutorialHDC) {
			rend.material.color = Color.yellow;
			//triangleController.doNotCreateDot = true;
		}
	}
	
	void OnMouseExit () {
		if (allowMouseOver && tutorialCtrl1.inTutorialHDC) {
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
		}
	}
	
	//public void InstantiateHelperDots (Vector3 helperDotPos) {
	//	helperDot = Instantiate (origHelperDot, helperDotPos, origHelperDot.transform.rotation);
	//}
}
