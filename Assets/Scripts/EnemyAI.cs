using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour {

    //This is the main enemy AI. It needs to be much more complex but this isn't a priority at the moment. DamagePlayer() doesn't do anything at the moment.

	public GameObject player;
	private Vector3 playerTransform;
	public NavMeshAgent agent;
	public float health;
	private float maxHealth;
	public Image healthBar;
	public Image healthBack;
	public GameObject deathPart;
	public GameObject holder;
	public float damage;
	public float maxDamage;

	void Start(){
		agent = GetComponent<NavMeshAgent>();
		maxHealth = Random.Range (50f, 150f);
		maxDamage = Random.Range (1f, 5f);
		health = maxHealth;
		damage = maxDamage;
	}
	void Update () {
		RaycastThing ();
		HealthBar ();
	}
	void RaycastThing(){
		Vector3 direction = player.transform.position - this.transform.position;
		RaycastHit hit;

		if (Physics.Raycast(transform.position, direction, out hit, 100f)){
			if (hit.collider.tag != "wall"){ //This If statement probably isn't needed. Could use it later if I want to use an Else
				if (hit.collider.tag == "Player") {
					agent.SetDestination (playerTransform);
					playerTransform = player.transform.position;
				}
			}
		}
	}
	public void Damage(float damageTaken){
		health -= damageTaken;
		if (health <= 0f) {
			HealthBar ();
			Quaternion rot = Quaternion.identity;
			rot.eulerAngles = new Vector3 (-90, 0, 0);
			Instantiate (deathPart, transform.position - new Vector3 (0, 0, 0), rot);
			Destroy (gameObject);
		}
	}

	public void DamagePlayer (float damagePlayer){
		damagePlayer = damage;
	}

	void HealthBar(){
		float hpBar = health / maxHealth;
		//float healththing = (hpBar * 100);
		healthBar.rectTransform.localScale = new Vector3 (hpBar, 1, 1);
	}
}
