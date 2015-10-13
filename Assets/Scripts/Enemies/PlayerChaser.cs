using UnityEngine;
using System.Collections;

public class PlayerChaser : MonoBehaviour {


	private Vector3 lastSeenPosition;
	private bool isFollowing;

	public float speed;
	//public float timeToForget;



	// Use this for initialization
	void Start () {
		isFollowing = false;
	}
	
	// Update is called once per frame
	void Update () {
		if ( isFollowing ) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, lastSeenPosition, step);
		}
	}

	public void PlayerSeen( Vector3 where ){
		isFollowing = true;
		lastSeenPosition = where;
	}
}
