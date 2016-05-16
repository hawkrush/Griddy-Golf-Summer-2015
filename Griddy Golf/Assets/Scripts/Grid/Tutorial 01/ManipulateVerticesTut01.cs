using UnityEngine;
using System.Collections;

public class ManipulateVerticesTut01 : MonoBehaviour {
	
	public GridLinesTut01 gridLines;
	public TriangleControllerTut01 triangleController;
	public TextControllerTut01 textController;
	public TileDotsControllerTut01 tileDotsController;
	public TutorialControllerLvl1 tutorialCtrl1;

	public Camera cam;
	public Color startColor;
	public Renderer rend;

	private bool allowMouseOver;
	private bool highlighted;
	public bool isDotHighlighted;
	private bool isSelected;
	private bool startBlinking;
	private float blinkingTimer;

	private Vector3 mousePos;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		
		highlighted = false;
		isDotHighlighted = false;
		allowMouseOver = false;
		startBlinking = false;
		blinkingTimer = 0f;

		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut01> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut01> ();
		tutorialCtrl1 = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl1> ();
		cam = GameObject.Find ("Game View").GetComponent<Camera> ();
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut01> ();

	}

	void Update () {
		if (!textController.hasWon) {
			if (tutorialCtrl1.inTutorialMV && gridLines.stopTime && tutorialCtrl1.messageCurrentlyOn == 15 && this.transform.position.x == 2.0f && (this.transform.position.z >= 28.6f && this.transform.position.z <= 28.8f)) {
				allowMouseOver = true;
			} else if (tutorialCtrl1.inTutorialMV && gridLines.stopTime && tutorialCtrl1.messageCurrentlyOn == 16 && this.transform.position.x == 2.0f && (this.transform.position.z >= 26.6f && this.transform.position.z <= 26.8f)) {
				allowMouseOver = true;
			} else if (tutorialCtrl1.inTutorialMV && !gridLines.stopTime && tutorialCtrl1.messageCurrentlyOn == 15 && this.transform.position.x == 2.0f && (this.transform.position.z >= 28.6f && this.transform.position.z <= 28.8f)) {
				allowMouseOver = false;
			} else if (tutorialCtrl1.inTutorialMV && !gridLines.stopTime && tutorialCtrl1.messageCurrentlyOn == 16 && this.transform.position.x == 2.0f && (this.transform.position.z >= 26.6f && this.transform.position.z <= 26.8f)) {
				allowMouseOver = false;
			}
		}

		if (!isDotHighlighted && tutorialCtrl1.messageCurrentlyOn == 15 && this.transform.position.x == 2.0f && this.transform.position.z == 28.7f) {
			Debug.Log ("this colored blinking");
			tutorialCtrl1.inTutorialMV = true;
			startBlinking = true;
			blinkingTimer += Time.unscaledDeltaTime;
			if (blinkingTimer >= 1f) {
				if (rend.material.color == startColor) {
					rend.material.color = Color.yellow;
				} else if (rend.material.color == Color.yellow) {
					rend.material.color = startColor;
				}
				blinkingTimer = 0f;
			}
		} else if (!isDotHighlighted && tutorialCtrl1.messageCurrentlyOn == 16 && this.transform.position.x == 2.0f && this.transform.position.z == 26.7f) {
			tutorialCtrl1.inTutorialMV = true;
			startBlinking = true;
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

		if (tutorialCtrl1.inTutorialMV && Input.GetButtonUp ("Interact") && isSelected) {
			highlighted = false;
			isDotHighlighted = false;
			isSelected = false;
			rend.material.color = startColor;
			triangleController.SpecialOccasionRequiresAttention ();
		}

		if (tutorialCtrl1.messageCurrentlyOn == 20) {
			if (tutorialCtrl1.psuedoInTut && this.transform.position.x == 0.0f && this.transform.position.z == 26.7f) {
				tutorialCtrl1.psuedoInTut = false;
				Debug.Log ("TutOnMouseUp");
				TutOnMouseUp ();
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
		if (allowMouseOver && isDotHighlighted) {
			highlighted = false;
			isDotHighlighted = false;
			isSelected = false;
			rend.material.color = startColor;
			triangleController.gridDotSelected = false;
			triangleController.RecreateGridDot (this.transform.position);
		} else if (allowMouseOver && !isDotHighlighted && !triangleController.gridDotSelected) {
			Debug.Log ("First step to recreate dot");
			highlighted = true;
			isDotHighlighted = true;
			isSelected = true;
			rend.material.color = Color.yellow;
			triangleController.SetCurrentGridDot (this.gameObject);
			triangleController.numOfSelectedLines = 0;
		}
	}

	void TutOnMouseUp () {
		Debug.Log ("Selected");
		if (isDotHighlighted) {
			highlighted = false;
			isDotHighlighted = false;
			isSelected = false;
			rend.material.color = startColor;
			triangleController.gridDotSelected = false;
			triangleController.RecreateGridDot (new Vector3 (4.0f, this.transform.position.y, 27.2f));
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

}
