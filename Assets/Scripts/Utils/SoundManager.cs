using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager> {
	
	protected SoundManager(){

	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	private static bool soundOn = true;


	public static string ChangeSound(){
		soundOn = !soundOn;
		if (soundOn){
			return "SOUND YES";
		}else{
			return "SOUND NO";
		}
	}

	public static void StreamSound(string name){
		if ( soundOn){
			AudioClip ac = Resources.Load("Sounds/FX/"+name) as AudioClip;
			AudioSource.PlayClipAtPoint(ac, Vector3.zero);
		}
	}
}
