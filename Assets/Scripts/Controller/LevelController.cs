using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {


	public GameObject map;
	public GameObject enemies;
	public GameObject pnjs;

	public Vector3 spawnPoint;

	public GameObject player;
	// Use this for initialization
	void Start () {
		//////////////////////
		//PlayerPrefs.SetString("MAPNAME", "Test_1");
		//PlayerPrefs.SetString("SPNAME", "1");
		//////////////////////
		if( map != null){
			CameraFade fader = Camera.main.gameObject.GetComponent<CameraFade>() as CameraFade;
			LoadEnemies();
			LoadMap();
			LoadPnjs();
			player.transform.position = spawnPoint;
			//fader.FadeIn(1f);
		}else{
			StartCoroutine("LoadLevel");
		}
	}


	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator LoadLevel( ){
		CameraFade fader = Camera.main.gameObject.GetComponent<CameraFade>() as CameraFade;
		string _levelName  = PlayerPrefs.GetString("MAPNAME");
		string _spawnPoint = PlayerPrefs.GetString("SPNAME" );
		//yield return new WaitForSeconds(.2f);
		map 	= Resources.Load("Levels/"+_levelName+"/MapMesh") as GameObject;
		enemies = Resources.Load("Levels/"+_levelName+"/Enemies") as GameObject;
		pnjs 	= Resources.Load("Levels/"+_levelName+"/PNJ") as GameObject;
		print ("OBJS LOADED");
		yield return new WaitForSeconds(.2f);
		LoadMap();
		LoadEnemies();
		LoadPnjs();
		player.transform.position = GameObject.Find("SP_"+_spawnPoint).transform.position;
		yield return new WaitForSeconds(.2f);
		print ("FADEING IN");
		fader.FadeIn(1f);
		
		//PlayerPrefs.SetString("MAPNAME","");
		//PlayerPrefs.SetString("SPNAME" ,"");
	}

	void LoadEnemies(){
		if(enemies)
		Instantiate (enemies);
	}

	void LoadPnjs(){
		if(pnjs)
		Instantiate (pnjs);
	}

	void LoadMap(){
		if(map)
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
		string _spawnPoint = PlayerPrefs.GetString("SPNAME" );
		player.transform.position = GameObject.Find("SP_"+_spawnPoint).transform.position;
	}
}
