using UnityEngine;
using System.Collections;
using LitJson;

public class playerTalk : MonoBehaviour {

	private Camera newCamera;
	private Vector3 screenPos;

	public JsonData missionData;
	public int A;
	public int B;
	public int X;
	public int Y;
	public string mission;
	public int textId;
	bool printText;

	// Use this for initialization
	void Start () {
		printText = false;
		newCamera = Camera.main;
		screenPos = newCamera.WorldToScreenPoint(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = newCamera.WorldToScreenPoint(transform.position);
	}

	public void setText(int playerNextText){

		printText = true;

		if(int.Parse(missionData[mission][playerNextText]["triggers"]["next"].ToString())>=0)
		{
			Debug.Log (int.Parse(missionData[mission][playerNextText]["triggers"]["next"].ToString()));
			A = int.Parse(missionData[textId][playerNextText]["triggers"]["next"].ToString());
		}
		else if(int.Parse(missionData[mission][textId]["triggers"]["callback"].ToString())>=0)
		{
			Debug.Log("Callback");
		}
		else
		{
			if(int.Parse(missionData[mission][textId]["triggers"]["answers"]["A"].ToString())>=0)
			{				
				A = int.Parse(missionData[mission][textId]["triggers"]["answers"]["A"].ToString());
			}
			else if(int.Parse(missionData[mission][textId]["triggers"]["answers"]["B"].ToString())>=0)
			{
				B = int.Parse(missionData[mission][textId]["triggers"]["answers"]["B"].ToString());
			}
			else if(int.Parse(missionData[mission][textId]["triggers"]["answers"]["X"].ToString())>=0)
			{
				X = int.Parse(missionData[mission][textId]["triggers"]["answers"]["X"].ToString());
			}
			else if(int.Parse(missionData[mission][textId]["triggers"]["answers"]["Y"].ToString())>=0)
			{
				Y = int.Parse(missionData[mission][textId]["triggers"]["answers"]["Y"].ToString());
			}
		}
	}

	void OnGUI() {
		if (printText) {
			GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 250, 100), missionData[mission][A]["text"].ToString ());
			Debug.Log("AQUI");
			GameObject MissionHelper_Aux = GameObject.Find ("MissionHelper");
			MissionHelper_Aux.GetComponent<LoadLevelDialog> ().getText(mission,int.Parse(missionData[mission][A]["triggers"]["answers"]["A"].ToString()));
			Debug.Log("AHORA");
		}
	}
		
}
