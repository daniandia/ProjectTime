using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	private static MusicManager instance ;
	bool suicide = false;
	void Awake() 
	{
		if ( suicide || (instance != null && instance != this) )
		{
			Destroy( this.gameObject );
			return;
		} 
		else 
		{
			instance = this;
		}
		
		DontDestroyOnLoad( this.gameObject );
	}
	
	// also change this to your script name
	// public static function GetInstance() : ThisIsTheScriptNameHere
	
	public static MusicManager GetInstance() 
	{
		return instance;
	}

	/// ////////////////////////// MANAGER FUNCS
	/// 
	///
	private bool musicOn = true;
	
	public string ChangeMusic(){
		musicOn = !musicOn;
		if (musicOn){
			RandomSong();
			return "MUSIC YES";
		}else{
			GetComponent<AudioSource>().Stop();
			return "MUSIC NO";
		}
	}

	void Start(){
		RandomSong();
	}

	public AudioClip[] songs;
	private int actualSong = 0;
	void Update(){
		if (!GetComponent<AudioSource>().isPlaying) {
			RandomSong();
		}
	}

	void RandomSong(){
		if (!musicOn) return;
		actualSong= Random.Range(0, songs.Length);
		Debug.Log("Playing song : "+actualSong);
		if (  songs[actualSong] )
			GetComponent<AudioSource>().clip = songs[actualSong];
		GetComponent<AudioSource>().Play();

	}
}
