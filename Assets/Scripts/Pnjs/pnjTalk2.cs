using UnityEngine;
using System.Collections;
using LitJson;

public class pnjTalk2 : MonoBehaviour {
	
	private bool printOnGUI;
	private bool printText;
	private Camera newCamera;
	private Vector3 screenPos;
	public Texture aButton;
	public JsonData pnjDatos;
	public int pnjNextText;
	public string mission;
	public GameObject MissionHelper_Aux;

	public string text;
	public int textId;
	public int nextTextId;
	
	// Use this for initialization
	void Start () {
		//pnjNextText = pnjDatos.pnjNext;
		printOnGUI = false;
		printText = false;
		newCamera = Camera.main;
		screenPos = newCamera.WorldToScreenPoint(transform.position);
		if (mission != "") {
			Debug.Log("cargo");
			MissionHelper_Aux = GameObject.Find ("MissionHelper");
			pnjDatos = MissionHelper_Aux.GetComponent<LoadLevelDialog> ().dataFile;
		}
		//if(pnjDatos)
		//	Debug.Log (pnjDatos.dataFile.ToString ());

		nextTextId = -1;
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = newCamera.WorldToScreenPoint(transform.position);
		if (printOnGUI && Input.GetButtonDown ("Fire2")) {
			if (!printText)
			{
				printText = true;
				textId=-1;
				//dame el texto
				if(nextTextId==-1)
					MissionHelper_Aux.GetComponent<LoadLevelDialog> ().getText(mission);
				else
				{
					MissionHelper_Aux.GetComponent<LoadLevelDialog> ().getText(mission,nextTextId);
				}
			}
			else
			{

			}
		}
	}
	
	void OnTriggerStay(Collider other) {
		if (other.name == "player" && !printOnGUI) {
			//print ("ENTRAR PLAYER");
			printOnGUI = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.name == "player" && printOnGUI) {
			//print ("SALIR PLAYER");
			printOnGUI = false;
			printText = false;
		}
	}

	public void setText(int newText){
		textId = newText;
		setNextText();
	}

	void setNextText()
	{
		if(int.Parse(pnjDatos[mission][textId]["triggers"]["next"].ToString())>=0)
		{
			nextTextId = int.Parse(pnjDatos[textId][pnjNextText]["triggers"]["next"].ToString());
		}
		else if(int.Parse(pnjDatos[mission][textId]["triggers"]["callback"].ToString())>=0)
		{
			Debug.Log("Callback");
		}
		else
		{
			if(int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["A"].ToString())>=0)
			{				
				nextTextId = int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["A"].ToString());
			}
			else if(int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["B"].ToString())>=0)
			{
				nextTextId = int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["B"].ToString());
			}
			else if(int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["X"].ToString())>=0)
			{
				nextTextId = int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["X"].ToString());
			}
			else if(int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["Y"].ToString())>=0)
			{
				nextTextId = int.Parse(pnjDatos[mission][textId]["triggers"]["answers"]["Y"].ToString());
			}
		}
	}
	
	void OnGUI() {
		if (printOnGUI) {
			if (!aButton) {
				Debug.LogError("Assign a Texture in the inspector.");
				return;
			}
			if(printText){
				if(textId!=-1)
				{
					GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 250, 100), pnjDatos[mission][textId]["text"].ToString());
				}
				else
					GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 100, 100), "Oye, hijodeputa");
			}
			else
				GUI.DrawTexture(new Rect(screenPos.x, Screen.height - screenPos.y - 100, 100, 100), aButton, ScaleMode.ScaleAndCrop, true, 0.0F);
			
		}
	}
}
