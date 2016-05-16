using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class BounceSoundTut03 : MonoBehaviour {

	public TriangleControllerTut03 triangleController;
	//public AudioSource bounceSound;
	//public AudioClip bounceClip;
	
	// Update is called once per frame
	public void SetInfo () {
		triangleController = GetComponent<TriangleControllerTut03> ();
		//bounceSound = GameObject.Find ("CreateDots").GetComponent<AudioSource> ();
		//bounceSound.loop = false;
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("Ball")) {
			triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTut03> ();
			triangleController.playBounceSound ();
		}
	}
}
