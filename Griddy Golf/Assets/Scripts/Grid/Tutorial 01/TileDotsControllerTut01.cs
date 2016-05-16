using UnityEngine;
using System.Collections;

public class TileDotsControllerTut01 : MonoBehaviour {

	public GridLinesTut01 gridLines;
	public TriangleControllerTut01 triangleController;
	public TutorialControllerLvl1 tutorialCtrl1;
	
	private Renderer rend;
	private Color startColor;
	private bool allowMouseOver;
	
	public bool dotSelected;
	public bool buttonOver;
	public float blinkingTimer;
	public bool isHighlighted;

	// Use this for initialization
	void Start () {
		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut01> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut01> ();
		tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl1> ();
		
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		
		allowMouseOver = false;
		dotSelected = false;
		buttonOver = false;
		isHighlighted = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (buttonOver.ToString ());
		if (tutorialCtrl1.inTutorialTDC && gridLines.stopTime) {
			//Debug.Log (tutorialCtrl1.messageCurrentlyOn.ToString ());
			if (transform.position.x == 8.0f && (transform.position.z >= 28.6f && transform.position.z <= 28.8f) && tutorialCtrl1.messageCurrentlyOn == 15) {
				allowMouseOver = true;
			} else if (transform.position.x == 8.0f && (transform.position.z >= 26.6f && transform.position.z <= 26.8f) && tutorialCtrl1.messageCurrentlyOn == 16) {
				allowMouseOver = true;
			}
			//this.gameObject.SetActive (true);
		} else if (tutorialCtrl1.inTutorialTDC && !gridLines.stopTime) {
			if (transform.position.x == 8.0f && (transform.position.z >= 28.6f && transform.position.z <= 28.8f) && tutorialCtrl1.messageCurrentlyOn == 15) {
				allowMouseOver = true;
			} else if (transform.position.x == 8.0f && (transform.position.z >= 26.6f && transform.position.z <= 26.8f) && tutorialCtrl1.messageCurrentlyOn == 16) {
				allowMouseOver = true;
			}
			//this.gameObject.SetActive (false);
		}

		if (!isHighlighted && transform.position.x == 8.0f && (transform.position.z >= 28.6f && transform.position.z <= 28.8f) && tutorialCtrl1.messageCurrentlyOn == 15) {
			//Debug.Log ("this colored green");
			rend.material.color = Color.green;
		} else if (!isHighlighted && transform.position.x == 8.0f && (transform.position.z >= 26.6f && transform.position.z <= 26.8f) && tutorialCtrl1.messageCurrentlyOn == 16) {
			rend.material.color = Color.green;
		}

		//if (tutorialCtrl1.messageCurrentlyOn == 20) {
		//	if (tutorialCtrl1.count == 4 && transform.position.x == 0.0f && (transform.position.z >= 26.6f && transform.position.z <= 26.8f)) {
		//		triangleController.RecreateGridDot (this.transform.position);
		//		//rend.material.color = startColor;
		//		triangleController.gridDotSelected = false;
		//	}
		//}
	}
	
	void OnMouseEnter () {
		//Debug.Log (transform.position.z.ToString ());
		if (allowMouseOver) {
			//Debug.Log (transform.position);
			isHighlighted = true;
			dotSelected = true;
			rend.material.color = Color.yellow;
		}
	}
	
	void OnMouseExit () {
		if (allowMouseOver) {
			isHighlighted = false;
			dotSelected = false;
			rend.material.color = startColor;
		}
	}
	
	void OnMouseUp () {
		/*
		if (allowMouseOver && !triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			//Debug.Log ("WHY");
			dotSelected = true;
			triangleController.CreateGridDot (this.transform.position);
		} 
		*/
		if (allowMouseOver && triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			Debug.Log ("Recreate dot now");
			dotSelected = true;
			triangleController.RecreateGridDot (this.transform.position);
			rend.material.color = startColor;
			triangleController.gridDotSelected = false;
		}
	}
}
