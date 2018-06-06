using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    //This isn't being used at the moment but could be placed on a button and when clicked would load a scene

	public Button button;

	void Start () {
		Button start = button.GetComponent<Button> ();
		start.onClick.AddListener (TaskOnClick);

	}

	void TaskOnClick(){
		print ("pressed");
		SceneManager.LoadScene ("scene");
	}
}
