﻿using UnityEngine;
using System.Collections;
using LitJson;

public class pnjTalk : MonoBehaviour {

	private bool printOnGUI;
	private bool printText;
	private Camera newCamera;
	private Vector3 screenPos;
	public Texture aButton;
	public JsonData pnjDatos;
	public int pnjNextText;
	public string mission;
	public GameObject MissionHelper_Aux;

	public string texto;

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
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = newCamera.WorldToScreenPoint(transform.position);
		if (printOnGUI && Input.GetButtonDown ("Fire2")) {
			if (!printText)
			{
				printText = true;

				//dame el texto
			}
			else
			{
				if(int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["next"].ToString())>=0)
				{
					pnjNextText = int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["next"].ToString());
					//pnjDatos.pnjNext=pnjNextText;
				}
				else if(int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["callback"].ToString())>=0)
				{
					Debug.Log("Callback");
				}
				else
				{
					if(int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["A"].ToString())>=0)
					{				
						pnjNextText = int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["A"].ToString());
						//pnjDatos.pnjNext=pnjNextText;
					}
					else if(int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["B"].ToString())>=0)
					{
						pnjNextText = int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["B"].ToString());
						//pnjDatos.pnjNext=pnjNextText;
					}
					else if(int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["X"].ToString())>=0)
					{
						pnjNextText = int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["X"].ToString());
						//pnjDatos.pnjNext=pnjNextText;
					}
					else if(int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["Y"].ToString())>=0)
					{
						pnjNextText = int.Parse(pnjDatos[mission][pnjNextText]["triggers"]["answers"]["Y"].ToString());
						//pnjDatos.pnjNext=pnjNextText;
					}
				}
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

	void OnGUI() {
		if (printOnGUI) {
			if (!aButton) {
				Debug.LogError("Assign a Texture in the inspector.");
				return;
			}
			if(printText)
				if(pnjDatos!=null)
				{
					GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 250, 100), pnjDatos[mission][pnjNextText]["text"].ToString());
				}
				else
					GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 100, 100), "Oye, hijodeputa");
			else
				GUI.DrawTexture(new Rect(screenPos.x, Screen.height - screenPos.y - 100, 100, 100), aButton, ScaleMode.ScaleAndCrop, true, 0.0F);

		}
	}
}
