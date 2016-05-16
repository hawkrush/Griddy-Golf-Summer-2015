using UnityEngine;
using System.Collections;

public class SetCameraSize : MonoBehaviour {

	public Camera cam;
	public int resolutionCounter;

	void Start () {
		resolutionCounter = 0;
		Screen.SetResolution (Screen.resolutions [0].width, Screen.resolutions [0].height, false);

		cam.orthographicSize = Screen.resolutions[resolutionCounter].height/2;
		cam.transform.position = new Vector3(Screen.resolutions[resolutionCounter].width/2,Screen.resolutions[resolutionCounter].height/2,-100);
	}

	void Update () {

		if (resolutionCounter<Screen.resolutions.Length-1)
		{
			resolutionCounter++;
		}
		else
		{
			resolutionCounter=0;
		}

		Screen.SetResolution(Screen.resolutions[resolutionCounter].width, Screen.resolutions[resolutionCounter].height, false);
		Camera.main.orthographicSize = Screen.resolutions[resolutionCounter].height/2;
		Camera.main.transform.position = new Vector3(Screen.resolutions[resolutionCounter].width/2,Screen.resolutions[resolutionCounter].height/2,-100);

		Debug.Log (cam.orthographicSize.ToString ());
	}

}
