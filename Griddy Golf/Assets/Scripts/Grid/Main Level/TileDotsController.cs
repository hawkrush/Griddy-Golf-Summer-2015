using UnityEngine;
using System.Collections;

public class TileDotsController : MonoBehaviour {

	public GridLines gridLines;
	public TriangleController triangleController;
	
	private Renderer rend;
	private Color startColor;
	private bool allowMouseOver;

	public bool dotSelected;
	public bool buttonOver;

	// Use this for initialization
	void Start () {
		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLines> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleController> ();
		//tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl1> ();

		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;

		allowMouseOver = false;
		dotSelected = false;
		buttonOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (buttonOver.ToString ());
		if (gridLines.stopTime) {
			allowMouseOver = true;
			//this.gameObject.SetActive (true);
		} else if (!gridLines.stopTime) {
			allowMouseOver = false;
			//this.gameObject.SetActive (false);
		}


		if (dotSelected && Input.GetButtonUp ("Create Triangle") && !triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			dotSelected = true;
			triangleController.CreateGridDot (this.transform.position);
		}
		else if (dotSelected && Input.GetButtonUp ("Create Triangle") && triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			dotSelected = true;
			triangleController.RecreateGridDot (this.transform.position);
			triangleController.gridDotSelected = false;
		}



		/*
		if (dotSelected && Input.GetButtonUp ("Fire2") && !triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			dotSelected = true;
			triangleController.CreateGridDot (this.transform.position);
		}
		else if (dotSelected && Input.GetButtonUp ("Fire2") && triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			dotSelected = true;
			triangleController.RecreateGridDot (this.transform.position);
			triangleController.gridDotSelected = false;
		}
		*/


	}

	void OnMouseEnter () {
		if (allowMouseOver) {
			Debug.Log (transform.position.ToString ());
			dotSelected = true;
			rend.material.color = Color.yellow;
		}
	}

	void OnMouseExit () {
		if (allowMouseOver) {
			dotSelected = false;
			rend.material.color = startColor;
		}
	}

	void OnMouseUp () {
		if (!triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			//Debug.Log ("WHY");
			dotSelected = true;
			triangleController.CreateGridDot (this.transform.position);
		} else if (triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			dotSelected = true;
			triangleController.RecreateGridDot (this.transform.position);
			triangleController.gridDotSelected = false;
		}
	}
}
