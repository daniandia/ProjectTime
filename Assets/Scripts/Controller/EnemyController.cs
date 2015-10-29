using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	private GameObject[] enemyPool;
	private int 	   selectedEnemy = 0;
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

	public GameObject GetNextEnemy( float maxDistance, Vector3 playerPosition){
		for (int i = (selectedEnemy + 1); i < enemyPool.Length; i++){
			//print ("NEXT ENEMY : CHECKING ENEMY : "+i);
			if (enemyPool[i]!=null && Vector3.Distance(enemyPool[i].transform.position,playerPosition) <= maxDistance ){
				selectedEnemy = i;
			//	print ("ENEMY SELECTED "+i);
				return enemyPool[i];
			}
		}
		for (int i = 0; i <= selectedEnemy; i++){
			//print ("NEXT ENEMY : CHECKING ENEMY : "+i);
			if ( enemyPool[i]!=null && Vector3.Distance(enemyPool[i].transform.position,playerPosition) <= maxDistance ){
				selectedEnemy = i;
			//	print ("ENEMY SELECTED "+i);
				return enemyPool[i];
			}
		}
		return null;
	}

	public GameObject GetPrevEnemy( float maxDistance, Vector3 playerPosition){
		for (int i = (selectedEnemy-1); i >= 0; i--){
			if (enemyPool[i]!=null && Vector3.Distance(enemyPool[i].transform.position,playerPosition) <= maxDistance ){
				selectedEnemy = i;
				return enemyPool[i];
			}
		}
		for (int i = enemyPool.Length-1; i >=selectedEnemy; i--){
			if ( enemyPool[i]!=null && Vector3.Distance(enemyPool[i].transform.position,playerPosition) <= maxDistance ){
				selectedEnemy = i;
				return enemyPool[i];
			}
		}
		return null;
	}

	public GameObject GetAimedEnemy(float maxDistance, Vector3 playerPosition){
		// Reordenar el vector
		//ReorderEnemyVector(playerPosition);

		selectedEnemy = 0;
		for (int i = (selectedEnemy); i < enemyPool.Length; i++){
			if (enemyPool[i]!=null && Vector3.Distance(enemyPool[i].transform.position,playerPosition) <= maxDistance ){
				selectedEnemy = i;
				return enemyPool[i];
			}
		}
		for (int i = 0; i <= selectedEnemy; i++){
			if ( enemyPool[i]!=null && Vector3.Distance(enemyPool[i].transform.position,playerPosition) <= maxDistance ){
				selectedEnemy = i;
				return enemyPool[i];
			}
		}
		return null;
	}

	void ReorderEnemyVector(Vector3 _player){
		//GameObject[] tempEnemies = new GameObject[enemyPool.Length];

		int n = enemyPool.Length;
		for (int i=0; i<n-1; i++)
		{
			for (int j=i+1; j<n; j++)
			{
				if(enemyPool[i] != null || enemyPool[j] != null || Vector3.Distance(_player,enemyPool[i].transform.position) > Vector3.Distance(_player,enemyPool[j].transform.position))
				{
					GameObject aux = enemyPool[i];
					enemyPool[i] = enemyPool[j];
					enemyPool[j] = aux;
				}
			}
		}

	}


}
