using UnityEngine;
using System.Collections;
using LitJson;

public class pnjData : MonoBehaviour {

	public string level;
	public string mission;
	public JsonData dataFile;

	// Use this for initialization
	void Start () {
		dataFile = loadJSON.Instance.loadFile (level);
		//Debug.Log (dataFile);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
