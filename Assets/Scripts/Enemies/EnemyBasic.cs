using UnityEngine;
using System.Collections;

public class EnemyBasic : MonoBehaviour {

	private Transform player;
	private bool playerSeen = false;
	public  float sightDistance  = 100f;
	private int layerMask = 1 << 8;

	// Use this for initialization

	private PlayerChaser chaser;

	void Start () {
		player = GameObject.Find("player").transform;
		playerSeen = false;

		chaser = gameObject.GetComponent<PlayerChaser>();
	}
	
	// Update is called once per frame
	void Update () {
		if ( playerSeen ){
			transform.LookAt(player.position);
			return;
		}
		if ( PlayerInSight() ) {
			InvokeRepeating("Shot",0f,1/shotsPerSecond);
			playerSeen = true;

		}
		// esto lo guardo para mirar si esta cerca ( sonido )
		//if (Physics.Raycast(transform.position, player.position - transform.position, sightDistance, layerMask))
		//	playerSeen=true;

	}

	bool PlayerInSight(){
		RaycastHit hit;
		if (Physics.Raycast(transform.position, player.position - transform.position, out hit, sightDistance)){
			if ( hit.collider.gameObject.tag == "Player" ){
				if ( chaser ) chaser.PlayerSeen(hit.collider.gameObject.transform.position);
				return  true;
			}
		}
		return false;
	}

	public GameObject bulletType;
	public float shotsPerSecond = 1f;
	// shots a bullet
	void Shot(){
		Instantiate(bulletType, transform.position, transform.rotation );
		if (!PlayerInSight()) {
			CancelInvoke("Shot");
			playerSeen = false;
		}
	}

	// Recibo disparos
	void OnTriggerEnter(Collider other) {
		//Debug.Log("COLLISION DETECTED ");
		if (other.gameObject.tag == "Bullet" ){
			Destroy(gameObject);
		}
	}
}
