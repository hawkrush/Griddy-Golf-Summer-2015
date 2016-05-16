using UnityEngine;
using System.Collections;

public class BallControllerTut03 : MonoBehaviour {

	public GridLinesTut03 gridLines;
	public TutorialControllerLvl3 tutorialCtrl1;
	public AudioSource releaseClip;
	public TextControllerTut03 textController;
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
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut03> ();
		myEventSystem = GameObject.Find ("EventSystem");

		releaseBall = false;
		ballCurrentlyMoving = false;

		instantiatedBall = ball.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Restart") && !textController.hasWon) {
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetButtonUp ("Skip") && !textController.hasWon) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		//Tutorial stuff
		/*
		if (tutorialCtrl1.inTutorialBC) {
			//Debug.Log ("Release");
			if (Input.GetButtonUp ("Fire2") && !gridLines.stopTime && !textController.hasWon) {
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
		if (tutorialCtrl1.inTutorialBC && !gridLines.stopTime && !releaseBall && !textController.hasWon) {
			instantiatedBall = Instantiate (ball, ball.transform.position, ball.transform.rotation) as Rigidbody;
			instantiatedBall.AddForce (Vector3.right * ballSpeed);
			releaseBall = true;

			ReleaseBall ();
			releaseClip.Play ();
			//ballCurrentlyMoving = true;
		}
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject(null);
	}

	public void DestroyBall () {
		ballCurrentlyMoving = false;
		releaseBall = false;
		Destroy (instantiatedBall.gameObject);

	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Tiles")) {
			Destroy (instantiatedBall.gameObject);
		} else if (other.CompareTag ("Triangle")) {
			Debug.Log ("Line");
		}
	}
}
