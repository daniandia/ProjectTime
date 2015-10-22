using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString("MAPNAME", "Test_1");
		PlayerPrefs.SetString("SPNAME", "1");
		Invoke("StartPlaying",.5f);
	}

	void StartPlaying(){
		
		Application.LoadLevel("pruebas");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
