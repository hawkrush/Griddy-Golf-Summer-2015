using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class BounceSound : MonoBehaviour {

	public TriangleController triangleController;
	//public AudioSource bounceSound;
	//public AudioClip bounceClip;
	
	// Update is called once per frame
	public void SetInfo () {
		triangleController = GetComponent<TriangleController> ();
		//bounceSound = GameObject.Find ("CreateDots").GetComponent<AudioSource> ();
		//bounceSound.loop = false;
	}

	void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("Ball")) {
			triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleController> ();
			triangleController.playBounceSound ();
		}
	}
	
}
