using UnityEngine;
using System.Collections;

public class InstantiateHelperDotTut02 : MonoBehaviour {

	public GameObject origHelperDot;
	public GameObject helperDot1, helperDot2, helperDot3, helperDot4, helperDot5;
	public TriangleControllerTut02 triangleController;

	public int numOfAdjustments;
	// Use this for initialization
	// Update is called once per frame
	//void Update () {
	//
	//}
	void Start () {
		triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut02> ();
		numOfAdjustments = 1;
	}
	
	public void Instantiate () {
		//If starting level made
		helperDot1 = Instantiate (origHelperDot, new Vector3 (6.0f, -12f, 28.2f), origHelperDot.transform.rotation) as GameObject;
		helperDot2 = Instantiate (origHelperDot, new Vector3 (6.0f, -12f, 26.7f), origHelperDot.transform.rotation) as GameObject;
		helperDot3 = Instantiate (origHelperDot, new Vector3 (2.5f, -12f, 26.7f), origHelperDot.transform.rotation) as GameObject;
	}

	public void InstantiateAdjustments () {
		if (numOfAdjustments == 0) {
			helperDot4 = Instantiate (origHelperDot, new Vector3 (6.0f, -12f, 27.7f), origHelperDot.transform.rotation) as GameObject;
			numOfAdjustments += 1;
			helperDot4.name = "Adjust Helper Dot 2.1";
			//helperDot4.GetComponent<SphereCollider> ().isTrigger = true;
			//helperDot4.GetComponent<SphereCollider> ().isTrigger = true;
			//helperDot4.GetComponent<SphereCollider> ().radius = 0.4f;
		} else if (numOfAdjustments == 1) {
			Debug.Log ("first");
			helperDot5 = Instantiate (origHelperDot, new Vector3 (1.0f, -12f, 26.7f), origHelperDot.transform.rotation) as GameObject;
			//numOfAdjustments += 1;
			helperDot5.name = "Adjust Helper Dot 2.2";
			//helperDot5.GetComponent<SphereCollider> ().isTrigger = true;
			//helperDot5.GetComponent<SphereCollider> ().isTrigger = true;
			//helperDot5.GetComponent<SphereCollider> ().radius = 0.4f;
		}
	}	
}
