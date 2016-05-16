using UnityEngine;
using System.Collections;

public class DotsCollider : MonoBehaviour {

	private Renderer re;

	void Start() {
		re = GetComponent<Renderer> ();
	}
	// Use this for initialization
	void onTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("LineDrawer")) {
			re.material.color = Color.white;
		}
	}
}
