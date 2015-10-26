using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	Vector3 distToPlayer;
	float speed = 10f;
	float maxDistToPlayer = 10f;
	bool moving = false;

	// Use this for initialization
	void Start () {
		distToPlayer = transform.position - transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.JoystickButton3) ) {
			//print ("GATILLO "+Quaternion.Euler(Input.GetAxis("RightStickHoriz")));
			moving = true;
			Vector3 pos = transform.position;
			Vector3 forward  = transform.parent.TransformDirection(Vector3.forward);
			Vector3 left	 = transform.parent.TransformDirection(Vector3.right);
			float curSpeed  = speed * Input.GetAxis("RightStickVert");
			float sideSpeed = speed * Input.GetAxis("RightStickHoriz");
			pos += (forward * curSpeed + left* sideSpeed);
			Vector3 camPos = distToPlayer + transform.parent.position;
			if (Vector3.Distance(pos,camPos) < maxDistToPlayer)
				transform.position = pos;
			else{
				Vector3 wantedPos = camPos + Vector3.Normalize(pos - camPos) *maxDistToPlayer;
				transform.position = wantedPos;
			}

		}else if (moving){
			moving = false;
			LeanTween.move(gameObject,distToPlayer + transform.parent.position, .2f).setEase(LeanTweenType.easeOutElastic);
		}
	}
}
