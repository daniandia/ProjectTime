using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public string mapName;
	public string spawnPointId;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TeleportTo(){
		CameraFade fader =Camera.main.gameObject.GetComponent<CameraFade>() as CameraFade;
		fader.FadeOut(1f);
		PlayerPrefs.SetString("MAPNAME",mapName);
		PlayerPrefs.SetString("SPNAME" ,spawnPointId);
		Application.LoadLevel(Application.loadedLevel);
	}
}
