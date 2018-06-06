using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour {

    //This script is not relevent to the fpstest unity game. It was for a different game which I have since deleted. Wanted to keep the script somewhere so chucked it in here. Has A LOT commented out.
    //READ THIS!!!! ^^^^^^^^^^^^

    public float speed = 10f;
	public Text counttext;
	public Text wintext;

	public float time = 0f;
	public Text timetext;
	public Text check1;
	public Text check2;
	public GameObject[] count;
	public GameObject[] count2;

	//private Transform curpos;


	void start (){
		 //Scene scene = SceneManager.GetActiveScene ();
	}
	// Update is called once per frame
	void Update () {
		//curpos = GetComponent<Transform> ();
		count = GameObject.FindGameObjectsWithTag("Coin");
		count2 = GameObject.FindGameObjectsWithTag("Coin2");
		Movement ();
		timerthing ();
		countthing ();
		//restart ();
		fps();
	}

	void Movement(){
		if (Input.GetKey ("a")) {
			transform.position += new Vector3 (-speed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey ("d")) {
			transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
		}
		if (Input.GetKey ("w")) {
			transform.position += new Vector3 (0f, 0f, speed * Time.deltaTime);
		}
		if (Input.GetKey ("s")) {
			transform.position += new Vector3 (0f, 0f, -speed * Time.deltaTime);
		}

	}
	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Car") {
			print ("hit");
			SceneManager.LoadScene ("scene");
		}
		if (col.gameObject.tag == "Coin") {
			print (count.Length);
			Destroy (col.gameObject);
			counttext.text = "Coins Left: " + count.Length.ToString ();
			StartCoroutine (wall ());
			if (count.Length == 1) {
				check1.text = "Checkpoint One: " + time.ToString ("F2");
			}
		}
		if (col.gameObject.tag == "Coin2") {
			print (count2.Length);
			Destroy (col.gameObject);
			counttext.text = "Coins Left: " + count2.Length.ToString ();
			StartCoroutine (wall ());
			if (count2.Length == 0) {
				check2.text = "Checkpoint One: " + time.ToString ("F2");
			}
		}

	}
			
		
	//void  restart (){
		//if (count.Length == 0){
			//timetext.text = "Your Time Was: " + time.ToString  ("F2");


			//if (Input.GetKeyDown(KeyCode.Space)){
				//Application.LoadLevel ("scene");
			//}
			
		//}
	
	//}
	void timerthing(){
		//if (count.Length >= 1) {
			time += 1f * Time.deltaTime;
			timetext.text = "Time: " + time.ToString("F2");
		//}


	}
	IEnumerator wall(){
		if (count.Length == 1){
			print ("working");
			wintext.text = "Level Complete! Unlocking New Area...                 " +ToString ();
			yield return new WaitForSeconds (5);
			GameObject.Find ("gate").SetActive (false);
			counttext.text = "Coins Left: " + count2.Length.ToString ();
			wintext.text = "";
		}
		if (count2.Length == 1){
			print ("working");
			wintext.text = "Level Complete! Unlocking New Area...                 " +ToString ();
			yield return new WaitForSeconds (5);
			GameObject.Find ("gate2").SetActive (false);
			wintext.text = "";
		}

	}
	void countthing(){
		if (GameObject.Find ("gate") != null) {
			print ("Printing");
			counttext.text = "Coins Left: " + count.Length.ToString ();
		}
	}
	void fps(){
		if (Input.GetKeyUp (KeyCode.Space)) {
			GameObject.Find ("Camera").SetActive (true);
		}
	}
}