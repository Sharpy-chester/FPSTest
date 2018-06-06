using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gunscript : MonoBehaviour {

    //This is the script that manages the shooting. It also has unfinished functions like Health() and Use() which need to be finished. I also need to fix DamageTaken() as currently it doesn't work. Will work on them soon.

	[SerializeField] private AudioClip gunsound;
	private AudioSource audioSource;
	private float cooldown;
	public float cooldowntime = 1f;
	private AudioClip gunsound1;
	private AudioSource audiosource;
	//private Transform thisTransform = null;
	private RaycastHit hit;
	public GameObject bullet;
	public float damage;
	public float thing;
	public GameObject deathPart;
	public float maxPlayerHealth;
	public float playerHealth;
	public float maxPlayerArmour;
	public float playerArmour;
	public Image healthBar;
	public Image armourBar;
	public Scene scene;


	void Start () {
		audiosource = GetComponent<AudioSource>();
		//thisTransform = GetComponent<Transform> ();
		damage = Random.Range (15f, 40f);
		maxPlayerHealth = Random.Range (80f, 120f);
		playerHealth = maxPlayerHealth;	
		maxPlayerArmour = Random.Range	(80f, 120f);
		playerArmour = maxPlayerArmour;
		scene = SceneManager.GetActiveScene();
	}
	void Update () {
		pew ();
		Health ();
	}
	void pew (){
		if (Input.GetKeyDown (KeyCode.Mouse0) && Time.time > cooldown) {
			audiosource.Play();
			cooldown = cooldowntime + Time.time;
			shoot ();			
		}
	}
	void shoot (){
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 1000000;
		if (Physics.Raycast (transform.position, forward, out hit, Mathf.Infinity)){
			if (hit.collider.tag != "Player") {
				GameObject bulletSpawn = Instantiate (bullet, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
				bulletSpawn.transform.SetParent (hit.transform);
			}
			if (hit.collider.tag == "Enemy") {
				hit.collider.GetComponent<EnemyAI> ().Damage (damage);
				Quaternion rot = Quaternion.identity;
				Instantiate (deathPart, hit.transform.position, rot);
			}
		}
	}
	void DamageTaken (Collision col){
		if (col.transform.tag == "Enemy") {
			col.gameObject.GetComponent<EnemyAI> ().DamagePlayer (thing);
			playerHealth =- thing;
		}
	}
	void Health(){
		float hpBar = (playerHealth / maxPlayerHealth);
		float x = healthBar.rectTransform.localScale.x;
		float y = healthBar.rectTransform.localScale.y;
		float z = healthBar.rectTransform.localScale.z;
		healthBar.rectTransform.localScale = new Vector3 (x*hpBar, y, z);
		float arBar = playerArmour / maxPlayerArmour;
		float x1 = healthBar.rectTransform.localScale.x;
		float y1 = healthBar.rectTransform.localScale.y;
		float z1 = healthBar.rectTransform.localScale.z;
		armourBar.rectTransform.localScale = new Vector3 (x1*arBar, y1, z1);
	}
	void Use (){
		if (Input.GetKeyUp (KeyCode.E)) {
			RaycastHit hit;
			if (Physics.Raycast (transform.position, Vector3.forward, out hit, 10f)) {
				if (hit.collider.tag == "Exit") {
					SceneManager.LoadScene ("fpstest");
					
				}
			}
		}
	}

}
