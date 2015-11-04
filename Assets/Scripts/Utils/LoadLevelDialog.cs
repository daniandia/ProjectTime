using UnityEngine;
using System.Collections;
using LitJson;

public class LoadLevelDialog : MonoBehaviour {

	public string level;
	public JsonData dataFile;
	public int next;

	// Use this for initialization
	void Start () {
		next = -1;
		dataFile = loadJSON.Instance.loadFile (level);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void getText(string mission){
		GameObject subject;
		string who;
		who=dataFile[mission][0]["id_pnj"].ToString();
		subject = GameObject.Find (who);
		//subject.GetComponent<pnjTalk2>().setText(dataFile[mission][0]["text"].ToString());
		subject.GetComponent<pnjTalk2>().setText(0);
	} 

	public void getText(string mission, int textId){
		GameObject subject;
		string who;
		who=dataFile[mission][0]["id_pnj"].ToString();
		subject = GameObject.Find (who);
		//subject.GetComponent<pnjTalk2>().setText(dataFile[mission][0]["text"].ToString());
		subject.GetComponent<pnjTalk2>().setText(textId);
	} 
}
