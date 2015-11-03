using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public enum weaponType{
		gun,
		machinegun,
	}

	public string	  name;

	public GameObject bulletType	;
	public float 	  coolTime		= 0.5f;
	private bool	  cooling 		= false;

	public void Shot(Transform playerPos){
		if (cooling) return;
		cooling = true;
		Instantiate(bulletType, playerPos.position, playerPos.rotation );
		Invoke("Restore",coolTime);
	}

	public void Restore(){
		cooling = false;
	}
}
