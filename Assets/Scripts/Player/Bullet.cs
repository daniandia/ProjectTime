using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 5;
	private float maxLife = 5f;
	// Use this for initialization
	void Start () {
		Debug.Log( "NEW BULLET WITH ROT : " + transform.rotation.eulerAngles );
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine(transform.position, transform.position + transform.forward * speed );
		maxLife-=Time.deltaTime;
		if (maxLife <= 0f) Destroy(gameObject);
		//transform.Translate( transform.forward * speed );
		Vector3 pos = transform.position ;
		pos += transform.forward * speed ;
		transform.position = pos;
	}



}
