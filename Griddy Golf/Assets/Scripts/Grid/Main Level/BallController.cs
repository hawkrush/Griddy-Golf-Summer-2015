using UnityEngine;
using System.Collections;

public class BallController: MonoBehaviour {

	public GridLines gridLines;
	public AudioSource releaseClip;
	public TextController textController;
	public GameObject myEventSystem;

	public Rigidbody ball, ball2;

	public Rigidbody instantiatedBall, instantiatedBall2;

	public bool releaseBall;
	public bool ballCurrentlyMoving;

	public int numOfBallsIn;
	public int numOfBallsToWin;

	public float ballSpeed = 750f;
	public float maxSpeed = 1000f;

	private Vector3 storedVelocity;
	// Use this for initialization
	void Start () {
		textController = GameObject.Find ("Number of Tries").GetComponent<TextController> ();
		myEventSystem = GameObject.Find ("EventSystem");

		releaseBall = false;
		ballCurrentlyMoving = false;

		numOfBallsIn = 0;

		instantiatedBall = ball.GetComponent<Rigidbody> ();
		instantiatedBall2 = ball2.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetButtonUp ("Restart") && !textController.hasWon) {
			Application.LoadLevel (Application.loadedLevel);
		}

		if (Input.GetButtonUp ("Skip") && !textController.hasWon) {
			Application.LoadLevel (Application.loadedLevel + 1);
		}
		*/
	}

	public void ReleaseBall () {
		if (!gridLines.stopTime && !textController.hasWon && !releaseBall) {
			textController.numOfTimesSetText = 0;
			instantiatedBall = Instantiate (ball, ball.transform.position, ball.transform.rotation) as Rigidbody;
			if (Application.loadedLevelName.Equals ("Mini Golf Editor Title Screen")) {
				instantiatedBall.AddForce (Vector3.forward * ballSpeed);
			}
			else if (Application.loadedLevelName.Equals ("Mini Golf Editor 01.03")) {
				instantiatedBall.AddForce ((-Vector3.right) * ballSpeed);
			}
			else if (Application.loadedLevelName.Equals ("Mini Golf Editor 01.04")) {
				instantiatedBall.AddForce ((Vector3.right + Vector3.forward).normalized * ballSpeed);
			}
			else if (Application.loadedLevelName.Equals ("Mini Golf Editor 02.03")) {
				instantiatedBall.AddForce ((-Vector3.right + -Vector3.forward).normalized * ballSpeed);
			}
			else {
				instantiatedBall.AddForce (Vector3.right * ballSpeed);
			}
			releaseBall = true;
			releaseClip.Play ();
		}
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject(null);
		//ballCurrentlyMoving = true;
	}

	public void ReleaseTwoBalls () {
		if (!gridLines.stopTime && !textController.hasWon && !releaseBall && (numOfBallsIn == 0)) {
			textController.numOfTimesSetText = 0;
			instantiatedBall = Instantiate (ball, ball.transform.position, ball.transform.rotation) as Rigidbody;
			instantiatedBall2 = Instantiate (ball2, ball2.transform.position, ball2.transform.rotation) as Rigidbody;

			if (Application.loadedLevelName.Equals ("Mini Golf Editor 03.02")) {
				instantiatedBall.AddForce (Vector3.right * ballSpeed);
				instantiatedBall2.AddForce (Vector3.right * ballSpeed);
			}
			else if (Application.loadedLevelName.Equals ("Mini Golf Editor 03.03")) {
				instantiatedBall.AddForce ((Vector3.right + -Vector3.forward).normalized * ballSpeed);
				instantiatedBall2.AddForce ((-Vector3.right + -Vector3.forward).normalized * ballSpeed);
			}
			else if (Application.loadedLevelName.Equals ("Mini Golf Editor 04.02")) {
				instantiatedBall.AddForce (Vector3.right * ballSpeed);
				instantiatedBall2.AddForce (Vector3.right * ballSpeed);
			}
			else {
				instantiatedBall.AddForce (Vector3.right * ballSpeed);
				instantiatedBall2.AddForce ((-Vector3.right) * ballSpeed);
			}

			releaseBall = true;
			releaseClip.Play ();
		}
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (null);
	}

	public void DestroyBall () {
		ballCurrentlyMoving = false;
		releaseBall = false;
		Destroy (instantiatedBall.gameObject);
	}

	public void DestroyTwoBalls () {
		ballCurrentlyMoving = false;
		releaseBall = false;
		Destroy (instantiatedBall.gameObject);
		Destroy (instantiatedBall2.gameObject);
	}
}
