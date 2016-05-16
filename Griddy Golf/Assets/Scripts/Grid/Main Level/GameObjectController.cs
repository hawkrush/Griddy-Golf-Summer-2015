using UnityEngine;
using System.Collections;

public class GameObjectController : MonoBehaviour {

	public GameObject tileDots;
	public GameObject instantiatedTileDots;
	public TileDotsController tileDotsCtrl;

	public bool tileDotsActive;
	// Use this for initialization
	void Start () {
		tileDots = GameObject.Find ("Tiles Dots");
		tileDotsActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!tileDotsActive) {
			tileDots = GameObject.Find ("Tile Dots");
			tileDots.SetActive (false);
		} else if (tileDotsActive) {
			tileDots = GameObject.Find ("Tile Dots");
			tileDots.SetActive (true);
		}
	}
}
