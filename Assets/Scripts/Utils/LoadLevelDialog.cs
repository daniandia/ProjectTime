using UnityEngine;
using System.Collections;
using LitJson;

public class LoadLevelDialog : MonoBehaviour {

	public string level;
	public JsonData dataFile;

	// Use this for initialization
	void Start () {
		dataFile = loadJSON.Instance.loadFile (level);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
