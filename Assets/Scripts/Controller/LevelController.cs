using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {


	public GameObject map;
	public GameObject enemies;

	public Vector3 spawnPoint;

	public GameObject player;
	// Use this for initialization
	void Start () {
		LoadEnemies();
		LoadMap();
		player.transform.position = spawnPoint;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadEnemies(){
		Instantiate (enemies);
	}

	void LoadMap(){
		Instantiate (map);
	}

	public void Restart(){
		//bullets
		foreach ( GameObject obj in GameObject.FindGameObjectsWithTag("Bullet") )
			Destroy (obj);
		foreach ( GameObject obj in GameObject.FindGameObjectsWithTag("BulletEnemy") )
			Destroy (obj);
		//enemies
		Destroy (GameObject.FindGameObjectWithTag("EnemyPool"));
		LoadEnemies();
		player.transform.position = spawnPoint;
	}
}
