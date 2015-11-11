using UnityEngine;
using System.Collections;
using LitJson;

public class pnjTalk3 : MonoBehaviour {

	private bool printOnGUI;
	private bool printText;
	private Camera newCamera;
	private Vector3 screenPos;
	public string mission;
	public GameObject MissionHelper_Aux;
	public Texture aButton;

	public string textToPrint;

	// Use this for initialization
	void Start () {
		printOnGUI = false;
		printText = false;
		newCamera = Camera.main;
		screenPos = newCamera.WorldToScreenPoint(transform.position);
		if (mission != "") {
			Debug.Log("cargo");
			MissionHelper_Aux = GameObject.Find ("MissionHelper");			
		}
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = newCamera.WorldToScreenPoint(transform.position);
		if (printOnGUI && Input.GetButtonDown ("Fire2")) {
			if (!printText)
			{
				printText = true;
				if(MissionHelper_Aux)
				{
					/*ESTOY AQUI!!!!*/
					/*HAY QUE PASARLE MISION E ID*/
					MissionHelper_Aux.GetComponent<LoadLevelDialog> ().getNextText(mission);
				}
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.name == "player" && !printOnGUI) {
			printOnGUI = true;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.name == "player" && printOnGUI) {
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
			if(printText){
				if(textToPrint!="")
				{
					GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 250, 100), textToPrint);
				}
				else
					GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 100, 100), "Oye, hijodeputa");
			}
			else
				GUI.DrawTexture(new Rect(screenPos.x, Screen.height - screenPos.y - 100, 100, 100), aButton, ScaleMode.ScaleAndCrop, true, 0.0F);
			
		}
	}
}
