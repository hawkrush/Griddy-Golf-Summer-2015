using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class BounceSoundTut01: MonoBehaviour {

	public TriangleControllerTut01 triangleController;
	//public AudioSource bounceSound;
	//public AudioClip bounceClip;
	
	// Update is called once per frame
	public void SetInfo () {
		triangleController = GetComponent<TriangleControllerTut01> ();
		//bounceSound = GameObject.Find ("CreateDots").GetComponent<AudioSource> ();
		//bounceSound.loop = false;
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("Ball")) {
			triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut01> ();
			triangleController.playBounceSound ();
		}
	}
}
