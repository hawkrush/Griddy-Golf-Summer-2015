using UnityEngine;
using System.Collections;

public class BounceSoundTitle : MonoBehaviour {

	public TriangleControllerTitle triangleController;
	//public AudioSource bounceSound;
	//public AudioClip bounceClip;
	
	// Update is called once per frame
	public void SetInfo () {
		triangleController = GetComponent<TriangleControllerTitle> ();
		//bounceSound = GameObject.Find ("CreateDots").GetComponent<AudioSource> ();
		//bounceSound.loop = false;
	}
	
	void OnCollisionEnter (Collision other) {
		if (other.gameObject.CompareTag ("Ball")) {
			triangleController = GameObject.Find ("CreateDots").GetComponent<TriangleControllerTitle> ();
			triangleController.playBounceSound ();
		}
	}
}
