using UnityEngine;
using System.Collections;

public class GridControllerTut01 : MonoBehaviour {
	
	void OnCollisionEnter (Collision intersection) {
		Debug.Log ("yo");
		//if (intersection.CompareTag ("Grid Line")) {
		//	Debug.Log ("ddd");
		//}
	}

}
