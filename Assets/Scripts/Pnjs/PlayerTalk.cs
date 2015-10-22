using UnityEngine;
using System.Collections;

public class PlayerTalk : MonoBehaviour {

	private bool printOnGUI;
	private bool printText;
	private Camera newCamera;
	private Vector3 screenPos;
	public Texture aButton;

	// Use this for initialization
	void Start () {
		printOnGUI = false;
		printText = false;
		newCamera = Camera.main;
		screenPos = newCamera.WorldToScreenPoint(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = newCamera.WorldToScreenPoint(transform.position);
		if(printOnGUI && !printText && Input.GetButtonDown("Fire2"))
		   printText=true;
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
				GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 100, 100), "Oye, hijodeputa");
			else
				GUI.DrawTexture(new Rect(screenPos.x, Screen.height - screenPos.y - 100, 100, 100), aButton, ScaleMode.ScaleAndCrop, true, 0.0F);

		}
		
	}
}
