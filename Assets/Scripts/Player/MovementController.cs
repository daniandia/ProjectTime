using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;

	public GameObject bulletType;


	void Update() {
		SetMovement();
		if ( Input.GetButtonDown("Fire1") ) Shot();
	}

	// Gets the pad and moves the player
	void SetMovement(){

		CharacterController controller = GetComponent<CharacterController>();
		if(!Input.GetKey(KeyCode.JoystickButton3) ) transform.Rotate(0, Input.GetAxis("RightStickHoriz") * rotateSpeed, 0);
		//mouse rotation
		transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
		Vector3 forward  = transform.TransformDirection(Vector3.forward);
		Vector3 left	 = transform.TransformDirection(Vector3.right);
		float curSpeed  = speed * Input.GetAxis("Vertical");
		float sideSpeed = speed * Input.GetAxis("Horizontal");
		controller.SimpleMove(forward * curSpeed + left* sideSpeed);
	}

	// shots a bullet
	void Shot(){
		Instantiate(bulletType, transform.position, transform.rotation );
	}

	// Entro e triggers

	void OnTriggerEnter(Collider other) {
		//Debug.Log("COLLISION DETECTED ");
		if (other.gameObject.tag == "BulletEnemy" ){
			GameObject.FindGameObjectWithTag ("LevelController").GetComponent<LevelController>().Restart();
		}
		else if(other.gameObject.tag == "SliderDoor"){
			other.GetComponent<SliderDoor>().PlayerEntered();
		}
		else if(other.gameObject.tag == "Teleport"){
			other.GetComponent<Teleport>().TeleportTo();
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "SliderDoor"){
			other.GetComponent<SliderDoor>().PlayerExit();
		}
	}
}
