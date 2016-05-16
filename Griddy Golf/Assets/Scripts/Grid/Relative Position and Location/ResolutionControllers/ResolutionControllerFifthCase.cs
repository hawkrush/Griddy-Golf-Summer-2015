using UnityEngine;
using System.Collections;

public class ResolutionControllerFifthCase : MonoBehaviour {

	public GameObject turret;
	public GameObject turret2;

	public Resolution[] resolutions;
	public Resolution currentResolution;
	
	private bool changeLocation;
	
	// Use this for initialization
	void Start () {
		resolutions = Screen.resolutions;
		currentResolution = Screen.currentResolution;
		changeLocation = true;
	}
	
	// Update is called once per frame
	void Update () {
		//if (changeLocation && (currentResolution.width == resolutions [7].width) && (currentResolution.height == resolutions [7].height) //) {
		if (changeLocation && (currentResolution.width == 1440) && (currentResolution.height == 900)) {
			turret.transform.position = new Vector3 (turret.transform.position.x + 0.15f, turret.transform.position.y, turret.transform.position.z - 0.15f);
			turret2.transform.position = new Vector3 (turret2.transform.position.x - 0.15f, turret2.transform.position.y, turret2.transform.position.z - 0.15f);
			changeLocation = false;
		}
	}
}
