using UnityEngine;
using System.Collections;

public class PlayerTalk : MonoBehaviour {

	private bool printOnGUI;
	private Camera newCamera;
	private Vector3 screenPos;

	// Use this for initialization
	void Start () {
		printOnGUI = false;
		newCamera = Camera.main;
		screenPos = newCamera.WorldToScreenPoint(transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		screenPos = newCamera.WorldToScreenPoint(transform.position);
	}

	void OnTriggerStay(Collider other) {
		if (other.name == "player" && !printOnGUI) {
			print ("ENTRAR PLAYER");
			printOnGUI = true;			 
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.name == "player" && printOnGUI) {
			print ("SALIR PLAYER");
			printOnGUI = false;
		}
	}

	void OnGUI() {
		if (printOnGUI) {
			print (screenPos);
			GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 100, 100), "Oye, hijodeputa");
		}
		
	}
}
