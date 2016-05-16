using UnityEngine;
using System.Collections;

public class TileDotsControllerTut03 : MonoBehaviour {

	public GridLinesTut03 gridLines;
	public TriangleControllerTut03 triangleController;
	public TutorialControllerLvl3 tutorialCtrl;
	//public GameObjectController gameObjectCtrl;
	
	private Renderer rend;
	private Color startColor;
	private bool allowMouseOver;
	
	public bool dotSelected;
	public bool buttonOver;
	// Use this for initialization
	void Start () {
		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut03> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut03> ();
		tutorialCtrl = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl3> ();
		//triangleController.
		
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
	}
	
	void OnMouseEnter () {
		Debug.Log (transform.position.ToString ());
	}
	/*
	void OnMouseEnter () {
		if (allowMouseOver && tutorialCtrl.inTutorialTileDot1) {
			if (transform.position == new Vector3 (2.5f, -12.3f, 26.7f) ||
			    transform.position == new Vector3 (6.0f, -12.3f, 26.7f) ||
			    transform.position == new Vector3 (6.0f, -12.3f, 28.2f)) {
				Debug.Log (transform.position.ToString ());
				dotSelected = true;
				rend.material.color = Color.yellow;
			} //else if (tutorialCtrl.inTutorialTileDot2 &&
		}
	}
	
	void OnMouseExit () {
		if (allowMouseOver && tutorialCtrl.inTutorialTileDot1) {
			if (transform.position == new Vector3 (2.5f, -12.3f, 26.7f) ||
			    transform.position == new Vector3 (6.0f, -12.3f, 26.7f) ||
			    transform.position == new Vector3 (6.0f, -12.3f, 28.2f)) {
				dotSelected = false;
				rend.material.color = startColor;
			}
		}
	}
	*/

	/*
	void OnMouseUp () {
		if (!triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) {
			//Debug.Log ("WHY");
			dotSelected = true;
			triangleController.TutCreateGridDot (this.transform.position);
		}
		if (triangleController.gridDotSelected && !triangleController.doNotSelectGridDots) { //
			dotSelected = true;
			triangleController.RecreateGridDot (this.gameObject);
			triangleController.gridDotSelected = false;
		}
	}
	*/
}