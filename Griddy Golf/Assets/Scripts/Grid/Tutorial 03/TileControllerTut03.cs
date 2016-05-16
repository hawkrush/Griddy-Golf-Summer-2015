using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileControllerTut03 : MonoBehaviour {

	public TriangleControllerTut03 triangleController;
	public TextControllerTut03 textController;
	public BallControllerTut03 ballController;
	public TutorialControllerLvl3 tutorialCtrl1;
	public AudioSource tileSound;
	public AudioSource winSound;
	public AudioSource bgSound;

	public GameObject tileDots;
	public GameObject instantiatedTileDots;
	
	private float loadTimer = 0f;
	
	void Start () {
		bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
		bgSound.Play ();
		bgSound.loop = true;
	}

	void Update () {
		if (textController.hasWon) {
			bgSound.Stop ();

			tutorialCtrl1.messageCurrentlyOn += 1;
			tutorialCtrl1.startPart6 = true;
			textController.hasWon = false;
		}
	}

	public void InstantiateTileDots () {
		instantiatedTileDots = Instantiate (tileDots) as GameObject;
		instantiatedTileDots.transform.parent = GameObject.Find ("Square Tiles").transform;
		//instantiatedTileDots = Instantiate (tileDots) as GameObject;
		instantiatedTileDots.transform.Rotate (90.01f, 0f, 0f);
		instantiatedTileDots.transform.localScale = new Vector3 (1f, 1f, 1f);
		instantiatedTileDots.transform.position = new Vector3 (0f, -12.8371696f, 28.966054f);
		//Debug.Log ((instantiatedTileDots.transform.position.y - instantiatedTileDots.transform.position.y).ToString ());
		//float tempY = instantiatedTileDots.transform.position.y - (3f * instantiatedTileDots.transform.position.y);
		//float tempZ = instantiatedTileDots.transform.position.z - (3f * instantiatedTileDots.transform.position.z);
		//instantiatedTileDots.transform.position = new Vector3 (instantiatedTileDots.transform.position.x,
		//2f*14.48304f,
		//2f*12.83717f);
	}

	public void DestroyTileDots () {
		Destroy (instantiatedTileDots.gameObject);
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Ball") && this.CompareTag ("Tiles")) {
			//Tutorial stuff
			ballController.DestroyBall ();
			tileSound = GameObject.Find ("Square Tiles").GetComponent<AudioSource> ();
			tileSound.Play ();
			textController.SetText ();
		} else if (other.CompareTag ("Ball") && this.CompareTag ("End Point")) {
			ballController.DestroyBall ();
			textController.hasWon = true;
			Debug.Log ("WIN");
			winSound = GameObject.Find ("End").GetComponent<AudioSource> ();
			winSound.Play ();
			//tutorialCtrl1.startPart4 = false;
			//tutorialCtrl1.TutorialPart4 ();
		}
	}
}
