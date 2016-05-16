using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public AudioSource bgSound;

	void Start () {
		bgSound = GameObject.Find ("Game View").GetComponent<AudioSource> ();
	}

	public void LoadTutorial () {
		bgSound.Stop ();
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void LoadLevel01 () {
		bgSound.Stop ();
		Application.LoadLevel (Application.loadedLevel + 3);
	}

	public void LoadLevel02 () {
		bgSound.Stop ();
		Application.LoadLevel (Application.loadedLevel + 7); //9
	}

	public void LoadLevel03 () {
		bgSound.Stop ();
		Application.LoadLevel (Application.loadedLevel + 11); //15
	}

	public void QuitGame () {
		Application.Quit ();
	}
}
