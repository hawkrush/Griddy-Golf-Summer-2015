using UnityEngine;
using System.Collections;

public class AnglesTextTut02 : MonoBehaviour {

	//public GameObject anglesPanel;
	//public Text anglesText;
	public TriangleControllerTut02 triangleController;
	public TutorialControllerLvl2 tutorialCtrl;
	public GridLinesTut02 gridLines;
	public LineRenderer lineRend;
	private Color startColor;
	
	private GameObject selectedLine;
	public float angleOfLine;
	public bool isSelected;
	public bool negAngle, posAngle;
	public bool onlySelectThis;
	public bool highlighted;
	
	// Use this for initialization
	void Start () {
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut02> ();
		tutorialCtrl = GameObject.Find ("Tutorial Panel").GetComponent<TutorialControllerLvl2> ();
		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLinesTut02> ();

		lineRend = transform.parent.GetComponent<LineRenderer> ();
		startColor = lineRend.material.color;
		
		isSelected = false;
		highlighted = false;
		//negAngle = false;
		//posAngle = false;
		//neitherNegOrPos = true;
	}
	
	void Update () {
		if (triangleController.linesHaveBeenSelected && isSelected) {
			isSelected = false;
			lineRend.material.color = startColor;
			triangleController.numOfSelectedLines -= 1;
			if (triangleController.numOfSelectedLines == 0) {
				triangleController.linesHaveBeenSelected = false;
			}
		}
		
		if (triangleController.gridDotSelected) {
			//Debug.Log ("Leggo");
			isSelected = false;
			lineRend.material.color = startColor;
			triangleController.numOfSelectedLines = 0;
		}

		if (tutorialCtrl.inTutorialAT && (angleOfLine == 0f || angleOfLine < 0f) && !isSelected && !highlighted) {
			lineRend.material.color = Color.green;
		} else if (!tutorialCtrl.inTutorialMV && !isSelected && !highlighted) {
			lineRend.material.color = startColor;
		}
	}
	
	public void SetAngle (float tempAngleOfLine) {
		angleOfLine = tempAngleOfLine;
		if (tempAngleOfLine < 0f) {
			//angleOfLine = tempAngleOfLine - (2f * tempAngleOfLine);
			//triangleController.numOfNegativeAngles += 1;
		} else if (tempAngleOfLine > 0f) {
			//triangleController.numOfPositiveAngles += 1;
		}
		//triangleController.numOfTriangleLines += 1;
	}
	
	void OnMouseEnter () {
		if (!isSelected && tutorialCtrl.inTutorialAT && gridLines.stopTime) {
			lineRend.material.color = Color.yellow;
			highlighted = true;
		}
	}
	
	void OnMouseExit () {
		if (tutorialCtrl.inTutorialAT && !isSelected && gridLines.stopTime) {
			lineRend.material.color = Color.green;
			highlighted = false;
		}
		else if (!isSelected) {
			lineRend.material.color = startColor;
		}
	}
	
	void OnMouseUp () {
		if (!isSelected && gridLines.stopTime && tutorialCtrl.inTutorialAT && (angleOfLine == 0f || angleOfLine < 0f)) {
			Debug.Log (angleOfLine.ToString ());
			isSelected = true;
			lineRend.material.color = Color.yellow;
			if (triangleController.SelectTriangleLines (this.transform.position.magnitude, this.gameObject, angleOfLine, this.name) == false) {
				isSelected = false;
				lineRend.material.color = startColor;
			}
			onlySelectThis = false;
		} else if (isSelected && gridLines.stopTime && tutorialCtrl.inTutorialAT && (angleOfLine == 0f || angleOfLine < 0f)) {
			isSelected = false;
			triangleController.numOfSelectedLines -= 1;
			if (triangleController.numOfNegativeAngles > 0) {
				triangleController.numOfNegativeAngles -= 1;
			} 
			if (triangleController.numOfPositiveAngles > 0) {
				triangleController.numOfPositiveAngles -= 1;
			}
			lineRend.material.color = Color.green;
			onlySelectThis = true;
		}
	}
}
