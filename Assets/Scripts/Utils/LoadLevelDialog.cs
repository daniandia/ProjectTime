using UnityEngine;
using System.Collections;
using LitJson;

public class LoadLevelDialog : MonoBehaviour {

	public string level;
	public JsonData dataFile;
	public int next;
	public int current;

	// Use this for initialization
	void Start () {
		next = -1;
		dataFile = loadJSON.Instance.loadFile (level);
		//GameObject player = GameObject.Find ("player");
		//player.GetComponent<playerTalk> ().missionData=dataFile;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setNext(int next)
	{

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
		who=dataFile[mission][textId]["id_pnj"].ToString();
		subject = GameObject.Find (who);
		//subject.GetComponent<pnjTalk2>().setText(dataFile[mission][0]["text"].ToString());
		if (who == "player") {
			Debug.Log ("HABLA PLAYER:"+textId);
			subject.GetComponent<playerTalk> ().setText (textId);
		} else {
			Debug.Log ("HABLA PNJ");
			subject.GetComponent<pnjTalk2> ().setText (textId);
		}
	}

	public void getNextText(string mission)
	{

	}
}
