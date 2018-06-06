using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunrotate : MonoBehaviour {

    //I haven't used this in the actual game because its annoying and screws with the lighting. If you want to use it create two lights that point in the opposite direction and make one bright and one dim (One is for the day and one is for night) and attach this script to both.

	public float rotspeed = 0f;
	
	void Update () {
		transform.Rotate (Vector3.forward * rotspeed * Time.deltaTime, Space.World) ;
		transform.Rotate (Vector3.up * rotspeed * Time.deltaTime, Space.World) ;
	}
}
