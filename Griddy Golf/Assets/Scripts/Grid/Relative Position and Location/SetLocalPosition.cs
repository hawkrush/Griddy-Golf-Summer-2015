using UnityEngine;
using System.Collections;

public class SetLocalPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log (transform.position.ToString ());

		float x = transform.position.x / 2;
		float y = transform.position.y / 2;

		Debug.Log (y.ToString ());
		transform.position = new Vector3 (x, y, transform.position.z);
		Debug.Log (transform.position.ToString ());
	
	}
}
