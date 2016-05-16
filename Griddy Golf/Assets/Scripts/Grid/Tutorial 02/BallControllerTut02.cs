using UnityEngine;
using System.Collections;

public class BallControllerTut02 : MonoBehaviour {

	public GridLinesTut02 gridLines;
	public TutorialControllerLvl2 tutorialCtrl1;
	public AudioSource releaseClip;
	public TextControllerTut02 textController;
	public GameObject myEventSystem;

	public Rigidbody ball;

	public Rigidbody instantiatedBall;

	public bool releaseBall;
	public bool ballCurrentlyMoving;

	public float ballSpeed = 750f;
	public float maxSpeed = 1000f;

	private Vector3 storedVelocity;
	// Use this for initialization
	void Start () {
		//textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut02> ();
		myEventSystem = GameObject.Find ("EventSystem");

		releaseBall = false;
		ballCurrentlyMoving = false;

		instantiatedBall = ball.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Restart") ){
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetButtonUp ("Skip") && !textController.hasWon) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		/*
		//Tutorial stuff
		if (tutorialCtrl1.inTutorialBC) {
			//Debug.Log ("Release");
			if (Input.GetButtonUp ("Fire2") && !gridLines.stopTime) {
				if (!releaseBall) {
					ReleaseBall ();
					releaseClip.Play ();
				}
			}
			
			if (ballCurrentlyMoving) {
				instantiatedBall.AddForce (Vector3.right * ballSpeed);
				instantiatedBall.velocity = Vector3.ClampMagnitude (instantiatedBall.velocity, maxSpeed);
			}
		}
		*/
	}

	public void ReleaseBall () {
		if (tutorialCtrl1.inTutorialBC && !releaseBall && !gridLines.stopTime) {
			instantiatedBall = Instantiate (ball, ball.transform.position, ball.transform.rotation) as Rigidbody;
			instantiatedBall.AddForce (Vector3.right * ballSpeed);
			releaseBall = true;
			releaseClip.Play ();
		}
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject(null);
		//ballCurrentlyMoving = true;
	}

	public void DestroyBall () {
		ballCurrentlyMoving = false;
		releaseBall = false;
		Destroy (instantiatedBall.gameObject);
		tutorialCtrl1.inTutorialBC = false;
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Tiles")) {
			Destroy (instantiatedBall.gameObject);
		} else if (other.CompareTag ("Triangle")) {
			Debug.Log ("Line");
		}
	}
}
