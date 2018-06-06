using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class mover : MonoBehaviour {

    //This script is not relevent to the fpstest unity game. It was for a different game which I have since deleted. Wanted to keep the script somewhere so chucked it in here.
    //READ THIS!!!! ^^^^^^^^^^^^

    public float speed = 1f;
	private float rand=1f;
	private float startxpos= 0f;
	private float startypos = 0f;
	private float startzpos = 0f;
	private Transform thisTransform = null;
	//private Scene scene;

	// Use this for initialization
	void Start () {
		thisTransform = GetComponent<Transform> ();
		startxpos = thisTransform.position.x;
		startypos = thisTransform.position.y;
		startzpos = thisTransform.position.z;
		//scene = SceneManager.GetActiveScene ();
	}
		
	// Update is called once per frame
	void Update () {
		thisTransform.position += new Vector3 (rand * speed * Time.deltaTime, 0f, 0f);
		//thisTransform.transform = transform.Translate (Vector3.forward * Time.deltaTime * speed * rand);

		//car moving right
		if (thisTransform.position.x >= 110f) {
			thisTransform.position = new Vector3 (startxpos, startypos, startzpos);
			rand = Random.Range (1f, 2f);
		}

		//car moving left
		if (thisTransform.position.x <= -110f) {
			thisTransform.position = new Vector3 (startxpos, startypos, startzpos);
			rand = Random.Range (1f, 2f);
		}
	}

		
	}

