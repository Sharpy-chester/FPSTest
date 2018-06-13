using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour {

    public GameObject PlayerObj;
    private Transform PlayerTransform;

	void Start () {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        PlayerTransform = PlayerObj.transform;
        this.transform.LookAt(PlayerTransform);
	}
}
