using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileController : MonoBehaviour {

	public TriangleController triangleController;
	public TextController textController;
	public BallController ballController;
	public WinLevelController winLevelController;

	public AudioSource tileSound;
	public AudioSource winSound;
	public AudioSource bgSound;

	public GameObject tileDots;
	public GameObject instantiatedTileDots;
	
	private float loadTimer = 0f;
	
	void Start () {
		bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
		textController = GameObject.Find ("Number of Tries").GetComponent<TextController> ();
		winLevelController = GameObject.Find ("Canvas").GetComponent<WinLevelController> ();
		bgSound.Play ();
		bgSound.loop = true;
	}

	public void InstantiateTileDots () {
		instantiatedTileDots = Instantiate (tileDots) as GameObject;
		instantiatedTileDots.transform.parent = GameObject.Find ("Square Tiles").transform;
		instantiatedTileDots.transform.Rotate (90.01f, 0f, 0f);
		instantiatedTileDots.transform.localScale = new Vector3 (1f, 1f, 1f);
		instantiatedTileDots.transform.position = new Vector3 (0f, -12.8371696f, 28.966054f);
	}
	
	public void DestroyTileDots () {
		Destroy (instantiatedTileDots.gameObject);
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Ball") && this.CompareTag ("Tiles")) {
			textController.numOfTimesSetText += 1;
			if (ballController.numOfBallsToWin == 1) {
				ballController.numOfBallsIn = 0;
				ballController.DestroyBall ();
				tileSound = GameObject.Find ("Square Tiles").GetComponent<AudioSource> ();
				tileSound.Play ();

				textController.SetText ();
			}
			if (ballController.numOfBallsToWin == 2) {
				ballController.numOfBallsIn = 0;
				ballController.DestroyTwoBalls ();
				tileSound = GameObject.Find ("Square Tiles").GetComponent<AudioSource> ();
				tileSound.Play ();
				
				textController.SetText ();
			}

		} else if (other.CompareTag ("Ball") && this.CompareTag ("End Point")) {
			ballController.numOfBallsIn += 1;
			if (ballController.numOfBallsIn == ballController.numOfBallsToWin) {
				bgSound.Stop ();
				textController.hasWon = true;
				if (ballController.numOfBallsToWin == 1) {
					ballController.DestroyBall ();
				} else if (ballController.numOfBallsToWin == 2) {
					ballController.DestroyTwoBalls ();
				}
				winSound = GameObject.Find ("End").GetComponent<AudioSource> ();
				winSound.Play ();

				winLevelController.AnimateEndSplat ();
			}
		}
	}
}
