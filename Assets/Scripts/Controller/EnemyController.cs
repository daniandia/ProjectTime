using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameObject[] enemyPool;
	private int 	   selectedEnemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitEnemyPool(){
		enemyPool = GameObject.FindGameObjectsWithTag("Enemy");
		//foreach (GameObject _obj in GameObject.FindGameObjectsWithTag("Enemy")) {}
	}
}
