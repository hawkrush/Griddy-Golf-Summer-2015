using UnityEngine;
using System.Collections;

public class BallControllerTut01 : MonoBehaviour {

	public GridLinesTut01 gridLines;
	public TutorialControllerLvl1 tutorialCtrl1;
	public AudioSource releaseClip;
	public TextControllerTut01 textController;
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
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut01> ();
		myEventSystem = GameObject.Find ("EventSystem");
		
		releaseBall = false;
		ballCurrentlyMoving = false;
		
		instantiatedBall = ball.GetComponent<Rigidbody> ();
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
		if (tutorialCtrl1.inTutorialBC && !gridLines.stopTime && !textController.hasWon && !releaseBall) {
			instantiatedBall = Instantiate (ball, ball.transform.position, ball.transform.rotation) as Rigidbody;
			instantiatedBall.AddForce (Vector3.right * ballSpeed);
			releaseBall = true;
			releaseClip.Play ();
		}
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject(null);
	}
	
	public void DestroyBall () {
		ballCurrentlyMoving = false;
		releaseBall = false;
		Destroy (instantiatedBall.gameObject);

		if (tutorialCtrl1.messageCurrentlyOn == 21) {
			tutorialCtrl1.inTutorialAT = false;
			tutorialCtrl1.inTutorialMV = false;
			tutorialCtrl1.inTutorialGL = false;
			tutorialCtrl1.inTutorialBC = false;
			tutorialCtrl1.messageCurrentlyOn += 1;
			tutorialCtrl1.startPart4 = true;
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Tiles")) {
			Destroy (instantiatedBall.gameObject);
		} else if (other.CompareTag ("Triangle")) {
			Debug.Log ("Line");
		}
	}
}
