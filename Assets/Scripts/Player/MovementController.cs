using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
	
	public float speed = 3.0F;
	public float rotateSpeed = 3.0F;

	public GameObject bulletType;

	private EnemyController enemyController;
	private GameObject 		aimedEnemy;
	public bool 			nextEnemySelected = false;

	public float seeDistance = 500f;

	public enum CameraMode{
		free,
		move,
		aim,
	}

	public CameraMode cameraMode;

	void Update() {
		SetMovement();
		SetCamera();
		if ( Input.GetButtonDown("Fire1") ) Shot();
	}

	// Camera setting
	void SetCamera(){
		if(Input.GetKey(KeyCode.JoystickButton3) ) {
			cameraMode = CameraMode.move;
		}
		if(Input.GetKeyUp(KeyCode.JoystickButton3)){
			cameraMode = CameraMode.free;
		}
		if(Input.GetKeyDown(KeyCode.JoystickButton5)){
			if(enemyController == null ) enemyController = GameObject.Find("EnemyController").GetComponent<EnemyController>();
			aimedEnemy = enemyController.GetAimedEnemy(seeDistance,transform.position);
			if(aimedEnemy != null)
				 cameraMode = CameraMode.aim;
			else cameraMode = CameraMode.free;
			nextEnemySelected = false;
		}
		if(Input.GetKeyUp(KeyCode.JoystickButton5)){
			cameraMode = CameraMode.free;
		}
		switch (cameraMode) {
			case CameraMode.free: 	transform.Rotate(0, Input.GetAxis("RightStickHoriz") * rotateSpeed, 0); break;
			case CameraMode.aim: 
			if (!nextEnemySelected & Input.GetAxis("RightStickHoriz") >.5f) 		{Invoke("ResetEnemySelection",.5f) ;nextEnemySelected = true; aimedEnemy = enemyController.GetNextEnemy(seeDistance,transform.position);}
			if (!nextEnemySelected & Input.GetAxis("RightStickHoriz") < (-0.5f)) 	{Invoke("ResetEnemySelection",.5f) ;nextEnemySelected = true; aimedEnemy = enemyController.GetPrevEnemy(seeDistance,transform.position);}
				if (aimedEnemy==null) { cameraMode=CameraMode.free; break; } 
				transform.LookAt(aimedEnemy.transform);	 break;
		}
	}

	void ResetEnemySelection(){
		nextEnemySelected = false;
	}

	// Gets the pad and moves the player
	void SetMovement(){

		CharacterController controller = GetComponent<CharacterController>();
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
