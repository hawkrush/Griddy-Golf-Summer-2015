using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileControllerTut01 : MonoBehaviour {

	public TriangleControllerTut01 triangleController;
	public TextControllerTut01 textController;
	public BallControllerTut01 ballController;
	public AudioSource tileSound;
	public AudioSource winSound;
	public AudioSource bgSound;
	public TutorialControllerLvl1 tutorialCtrl1;
	
	public GameObject tileDots;
	public GameObject instantiatedTileDots;

	private float loadTimer = 0f;

	void Start () {
		bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
		textController = GameObject.Find ("Number of Tries").GetComponent<TextControllerTut01> ();
		bgSound.Play ();
		bgSound.loop = true;
	}

	void Update () {
		if (textController.hasWon) {
			//bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
			//bgSound.Stop ();
			if (tutorialCtrl1.messageCurrentlyOn == 11) {
				textController.hasWon = false;
				tutorialCtrl1.inTutorialBC = false;
				tutorialCtrl1.messageCurrentlyOn += 1;
				tutorialCtrl1.startPart3 = true;
			}
		}

		/*
		if (tutorialCtrl1.messageCurrentlyOn == 24) {
			bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
			bgSound.Stop ();
		}*/
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
			//Tutorial stuff
			ballController.DestroyBall ();
			tileSound = GameObject.Find ("Square Tiles").GetComponent<AudioSource> ();
			tileSound.Play ();
			
			textController.SetText ();

			tutorialCtrl1.inTutorialBC = false;
			tutorialCtrl1.messageCurrentlyOn += 1;
			tutorialCtrl1.startPart1 = true;
			
		} else if (other.CompareTag ("Ball") && this.CompareTag ("End Point")) {
			textController.hasWon = true;
			ballController.DestroyBall ();
			winSound = GameObject.Find ("End").GetComponent<AudioSource> ();
			winSound.Play ();
			Debug.Log ("WIN");
			
			//tutorialCtrl1.startPart4 = false;
			//tutorialCtrl1.TutorialPart4 ();
		}
	}
}
