using UnityEngine;
using System.Collections;

public class Raycasst : MonoBehaviour {

    //This script is not relevent to the fpstest unity game. It was for a different game which I have since deleted. Wanted to keep the script somewhere so chucked it in here.
    //READ THIS!!!! ^^^^^^^^^^^^

    private Transform thisTransform = null;
	private RaycastHit hit;
	public float carpos;

	void Start () {
		thisTransform = GetComponent<Transform> ();
    } 

	void Update () {
		
		var forward = thisTransform.TransformDirection (Vector3.left); //private variable that holds the transform direction that the raycast needs
		Debug.DrawRay (thisTransform.position, -forward * 10, Color.green); //draws the ray so you can see it
		RaycastHit hit;
		if (Physics.Raycast (thisTransform.position, -forward, out hit, 10)) {
			Debug.Log ("hit");

			if (hit.collider.tag == "carleft") { /*if the raycast hits a car that has this tag on, then the position of the car will equil 
			the position of the car it hit + a certain number. The way i did it was make 2 tags. 1 for the cars going left and one for the 
			cars going right*/
				Debug.Log ("working");
				Vector3 position = hit.transform.position; //private vector 3 that holds the transform position so that it can be changed by using a float
				position.x = position.x + carpos; //there will be a better, more efficiant way of doing this (replacing carpos with something else) but i will hopefully do that later
				transform.position = position;
			}
			if (hit.collider.tag == "carright") {  // the same if statement as above but for the cars that are going right
				Debug.Log ("working");
				Vector3 position = hit.transform.position;
				position.x = position.x - carpos;
				transform.position = position;
			}
				

		}
		
		
	}
}
