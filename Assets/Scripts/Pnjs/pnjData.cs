using UnityEngine;
using System.Collections;
using LitJson;

public class pnjData : MonoBehaviour {

	public string level;
	public string mission;
	public JsonData dataFile;
	public string pnjName;
	public int pnjNext;

	// Use this for initialization
	void Start () {
		if(pnjNext==-1)
			pnjNext = 0;
		pnjName = transform.name;
		dataFile = loadJSON.Instance.loadFile (level);
		//Debug.Log (dataFile);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
