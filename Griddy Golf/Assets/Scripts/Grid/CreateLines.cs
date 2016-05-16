using UnityEngine;
using System.Collections;

public class CreateLines : MonoBehaviour {

	//public GameObject gameObject1, gameObject2;
	public LineRenderer lineRenderer; //The line renderer object you're going to use

	public GameObject gameObject1, gameObject2; //The two objects that you'll draw the line between
	public LineRenderer lr1; //lr2, lr3, etc. depending on how many lines you need
	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {

		/*This creates the line with no animation
		lr1 = Instantiate (lineRenderer) as LineRenderer; //Instantiate line renderer
		lr1.SetPosition (0, gameObject1.transform.position); //Basically set the starting point of the line as the first object
		lr1.SetPosition (1, gameObject2.transform.position); //Basically set the ending point of the line as the second object

		lr1.SetWidth (0.15f, 0.15f); //The width of the line when it starts and the width of the line when it ends
		lr1.material.color = Color.white; //Or whatever color you want it to be
		*/

		/*This creates the line with animation
		lr1 = Instantiate (lineRenderer) as LineRenderer;

		lr1.SetPosition (0, gameObject1.transform.position);
		lr1.SetWidth (0.15f, 0.15f);
		lr1.material.color = Color.white;

		float dist = Vector3.Distance (gameObject1.transform.position, gameObject2.transform.position); //Calculate Vector3 distance 
																										//between first object and
																										//second object
		float counter = 0;
		float lineSpeed = 4f;

		//The while loop below is used to animate the line
		while (counter <= dist) {
			Debug.Log ("w");
			counter += 0.1f / lineSpeed; //Changes speed of animation

			float x = Mathf.Lerp (0, dist, counter); //Core of actual animation

			Vector3 pointA = gameObject1.transform.position;
			Vector3 pointB = gameObject2.transform.position;

			//The bottom line of code works depending on, if I remember correctly,
			//which point is higher on the y-axis. Change '(pointB - pointA) + pointA'
			//to '(pointA - pointB) + pointB' if things don't work
			Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA; //Calculated point on lr1 line the current iteration
																					  //is on
			lr1.SetPosition (1, pointAlongLine); //Set the end point to that current point on the line
		}
		//After while loop ends, the line will be created between the two points
		*/
	}
}
