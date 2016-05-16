using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnglesText : MonoBehaviour {

	//public GameObject anglesPanel;
	//public Text anglesText;
	public GridLines gridLines;
	public TriangleController triangleController;
	public LineRenderer lineRend;
	private Color startColor;

	private GameObject selectedLine;
	public float angleOfLine;
	public bool isSelected;
	public bool negAngle, posAngle;
	public bool startBlinking;
	public float blinkingTimer;

	// Use this for initialization
	void Start () {
		gridLines = GameObject.Find ("Sphere 1").GetComponent<GridLines> ();
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleController> ();
		lineRend = transform.parent.GetComponent<LineRenderer> ();
		startColor = lineRend.material.color;

		isSelected = false;
		blinkingTimer = 0f;
		startBlinking = false;
		//negAngle = false;
		//posAngle = false;
		//neitherNegOrPos = true;
	}

	void Update () {
		if (!gridLines.stopTime) {
			lineRend.material.color = startColor;
			blinkingTimer = 0f;
			triangleController.firstSelectedLine = null;
			triangleController.secondSelectedLine = null;
			triangleController.thirdSelectedLine = null;
			triangleController.numOfSelectedLines = 0;
		}

		if (triangleController.linesHaveBeenSelected && isSelected) {
			isSelected = false;
			lineRend.material.color = startColor;
			triangleController.numOfSelectedLines -= 1;
			if (triangleController.numOfSelectedLines == 0) {
				triangleController.linesHaveBeenSelected = false;
			}
		}

		if (triangleController.gridDotSelected) {
			Debug.Log ("Leggo");
			isSelected = false;
			lineRend.material.color = startColor;
			triangleController.numOfSelectedLines = 0;
		}

		if (startBlinking && gridLines.stopTime) {
			blinkingTimer += Time.unscaledDeltaTime;
			if (blinkingTimer >= 0.5f) {
				if (lineRend.material.color == startColor) {
					lineRend.material.color = Color.yellow;
				} else if (lineRend.material.color == Color.yellow) {
					lineRend.material.color = startColor;
				}
				blinkingTimer = 0f;
			}
		}

		if (Input.GetButtonUp ("Reset")) {
			startBlinking = false;
			isSelected = false;
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
		if (!isSelected && gridLines.stopTime) {
			lineRend.material.color = Color.yellow;
		}
	}

	void OnMouseExit () {
		if (!isSelected && gridLines.stopTime) {
			lineRend.material.color = startColor;
		}
	}

	void OnMouseUp () {
		Debug.Log (transform.position.ToString ());
		if (!isSelected && gridLines.stopTime) {
			Debug.Log (angleOfLine.ToString ());
			isSelected = true;
			lineRend.material.color = Color.yellow;
			if (triangleController.SelectTriangleLines (this.transform.position.magnitude, this.gameObject, angleOfLine, this.name) == false) {
				isSelected = false;
				lineRend.material.color = startColor;
			}
		} else if (isSelected && gridLines.stopTime) {
			isSelected = false;
			triangleController.numOfSelectedLines -= 1;
			if (triangleController.numOfNegativeAngles > 0) {
				triangleController.numOfNegativeAngles -= 1;
			} 
			if (triangleController.numOfPositiveAngles > 0) {
				triangleController.numOfPositiveAngles -= 1;
			}
			lineRend.material.color = startColor;

			int k = 1;
			while (GameObject.Find ("Line Collider " + k.ToString ()) != null) {
				if (GameObject.Find ("Line Collider " + k.ToString ()).name.Equals (this.gameObject.name)) {
					if (k%3 == 0) {
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesText> ().startBlinking = false;
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesText> ().lineRend.material.color = Color.magenta;
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesText> ().blinkingTimer = 0f;
						GameObject.Find ("Line Collider " + (k-2).ToString ()).GetComponent<AnglesText> ().startBlinking = false;
						GameObject.Find ("Line Collider " + (k-2).ToString ()).GetComponent<AnglesText> ().lineRend.material.color = Color.magenta;
						GameObject.Find ("Line Collider " + (k-2).ToString ()).GetComponent<AnglesText> ().blinkingTimer = 0f;
						break;
					} else if ((k+1)%3 == 0) {
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesText> ().startBlinking = false;
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesText> ().lineRend.material.color = Color.magenta;
						GameObject.Find ("Line Collider " + (k-1).ToString ()).GetComponent<AnglesText> ().blinkingTimer = 0f;
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesText> ().startBlinking = false;
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesText> ().lineRend.material.color = Color.magenta;
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesText> ().blinkingTimer = 0f;
						break;
					} else if ((k+2)%3 == 0) {
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesText> ().startBlinking = false;
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesText> ().lineRend.material.color = Color.magenta;
						GameObject.Find ("Line Collider " + (k+1).ToString ()).GetComponent<AnglesText> ().blinkingTimer = 0f;
						GameObject.Find ("Line Collider " + (k+2).ToString ()).GetComponent<AnglesText> ().startBlinking = false;
						GameObject.Find ("Line Collider " + (k+2).ToString ()).GetComponent<AnglesText> ().lineRend.material.color = Color.magenta;
						GameObject.Find ("Line Collider " + (k+2).ToString ()).GetComponent<AnglesText> ().blinkingTimer = 0f;
						break;
					}
				} else {
					k++;
				}
			}
		}
	}
}
