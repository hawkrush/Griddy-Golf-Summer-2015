using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileControllerTut02 : MonoBehaviour {

	public TriangleControllerTut02 triangleController;
	public TextControllerTut02 textController;
	public BallControllerTut01 ballController;
	public TutorialControllerLvl2 tutorialCtrl1;
	public AudioSource tileSound;
	public AudioSource winSound;
	public AudioSource bgSound;

	public GameObject tileDots;
	public GameObject instantiatedTileDots;

	private float loadTimer = 0f;
	private bool winWin;

	void Start () {
		bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
		bgSound.Play ();
		bgSound.loop = true;

		ballController = GameObject.Find ("Release Ball").GetComponent<BallControllerTut01> ();

		winWin = false;
	}

	/*
	void Update () {
		if (winWin) {
			bgSound.Stop ();
			//tutorialCtrl1.messageCurrentlyOn += 1;
			tutorialCtrl1.startPart3 = false;
			tutorialCtrl1.startPart4 = true;
			//loadTimer += Time.deltaTime;
			//if (loadTimer >= 2f) {
			//	Application.LoadLevel (Application.loadedLevel + 1);
			//}
			winWin = false;
		}
	}
	*/

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

			//textController.SetText ();
			tutorialCtrl1.messageCurrentlyOn += 2;
			Debug.Log (tutorialCtrl1.messageCurrentlyOn.ToString ());
			Debug.Log ("Why twice");
			tutorialCtrl1.startPart2 = true;
		} else if (other.CompareTag ("Ball") && this.CompareTag ("End Point")) {
			ballController.DestroyBall ();
			winWin = true;

			winSound = GameObject.Find ("End").GetComponent<AudioSource> ();
			winSound.Play ();

			//Debug.Log ("WIN");
			//tutorialCtrl1.startPart4 = false;
			//tutorialCtrl1.TutorialPart4 ();
		}
	}
}
