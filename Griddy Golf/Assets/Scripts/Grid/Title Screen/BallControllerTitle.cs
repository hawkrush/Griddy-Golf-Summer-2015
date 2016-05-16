using UnityEngine;
using System.Collections;

public class BallControllerTitle: MonoBehaviour {
	
	//public GridLinesTitle gridLines;
	public AudioSource releaseClip;
	public SkipIntroController skipIntro;
	//public TextControllerTitle textController;
	//public GameObject myEventSystem;
	
	public Rigidbody ball;
	
	public Rigidbody instantiatedBall;

	private bool timesUp;
	public bool releaseBall;
	public bool ballCurrentlyMoving;

	private float timer;
	public float ballSpeed = 750f;
	public float maxSpeed = 1000f;
	
	private Vector3 storedVelocity;
	// Use this for initialization
	void Start () {
		//textController = GameObject.Find ("Number of Tries").GetComponent<TextController> ();
		skipIntro = GameObject.Find ("Canvas").GetComponent<SkipIntroController> ();
		//myEventSystem = GameObject.Find ("EventSystem");

		timesUp = false;
		releaseBall = false;
		ballCurrentlyMoving = false;

		timer = 0f;

		instantiatedBall = ball.GetComponent<Rigidbody> ();
	}

	void Update () {
		if (!timesUp && !skipIntro.skipIntro) {
			timer += Time.deltaTime;
			if (timer >= 1f) {
				timesUp = true;
				if (!skipIntro.skipIntro) {
					ReleaseBall ();
				}
			}
		}
	}
	
	public void ReleaseBall () {
		instantiatedBall = Instantiate (ball, ball.transform.position, ball.transform.rotation) as Rigidbody;
		instantiatedBall.AddForce (Vector3.forward * ballSpeed);
		releaseBall = true;
		releaseClip.Play ();
		//myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject(null);
		//ballCurrentlyMoving = true;
	}
	
	public void DestroyBall () {
		ballCurrentlyMoving = false;
		releaseBall = false;
		Destroy (instantiatedBall.gameObject);
		//releaseButton.colors
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Tiles")) {
			Destroy (instantiatedBall.gameObject);
		} else if (other.CompareTag ("Triangle")) {
			Debug.Log ("Line");
		}
	}
}
