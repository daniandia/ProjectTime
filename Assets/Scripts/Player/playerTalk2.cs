using UnityEngine;
using System.Collections;

public class playerTalk2 : MonoBehaviour {

	private Camera newCamera;
	private Vector3 screenPos;

	public string A;
	public string B;
	public string X;
	public string Y;

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

	void OnGUI() {
		if (printText) {
			GUI.Box (new Rect (screenPos.x, Screen.height - screenPos.y - 100, 250, 100), "soy especial");
		}
	}
}
