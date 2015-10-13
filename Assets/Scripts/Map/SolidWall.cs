using UnityEngine;
using System.Collections;

public class SolidWall : MonoBehaviour {



	void OnTriggerEnter(Collider other) {
		Debug.Log("COLLISION DETECTED ");
		if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "BulletEnemy" ){
			Destroy(other.gameObject);
		}
	}
}
