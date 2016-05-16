using UnityEngine;
using System.Collections;

public class InstantiateHelperDotTut03 : MonoBehaviour {

	public GameObject origHelperDot;
	public GameObject helperDot1, helperDot2, helperDot3, helperDot4, helperDot5, helperDot6, helperDot7, helperDot8, helperDot9, helperDot10, helperDot11, helperDot12;
	public TriangleControllerTut03 triangleController;
	
	// Use this for initialization
	// Update is called once per frame
	//void Update () {
	//
	//}
	void Start () {
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut03> ();
	}
	
	public void Instantiate () {
		//If starting level made
		if (triangleController.numOfTotalGridDots == 0) {
			helperDot1 = Instantiate (origHelperDot, new Vector3 (-4f, -12f, 34.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot2 = Instantiate (origHelperDot, new Vector3 (-2f, -12f, 34.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot3 = Instantiate (origHelperDot, new Vector3 (-2f, -12f, 32.65f), origHelperDot.transform.rotation) as GameObject;
		} else if (triangleController.numOfTotalGridDots == 3) {
			helperDot4 = Instantiate (origHelperDot, new Vector3 (-4f, -12f, 26.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot5 = Instantiate (origHelperDot, new Vector3 (-4f, -12f, 24.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot6 = Instantiate (origHelperDot, new Vector3 (-2f, -12f, 24.65f), origHelperDot.transform.rotation) as GameObject;
		} else if (triangleController.numOfTotalGridDots == 6) {
			helperDot7 = Instantiate (origHelperDot, new Vector3 (4f, -12f, 26.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot8 = Instantiate (origHelperDot, new Vector3 (4f, -12f, 24.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot9 = Instantiate (origHelperDot, new Vector3 (2f, -12f, 24.65f), origHelperDot.transform.rotation) as GameObject;
		} else if (triangleController.numOfTotalGridDots == 9) {
			helperDot10 = Instantiate (origHelperDot, new Vector3 (4f, -12f, 34.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot11 = Instantiate (origHelperDot, new Vector3 (2f, -12f, 34.65f), origHelperDot.transform.rotation) as GameObject;
			helperDot12 = Instantiate (origHelperDot, new Vector3 (2f, -12f, 32.65f), origHelperDot.transform.rotation) as GameObject;
		}
	}
}
