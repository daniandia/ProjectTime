using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {

	private static Inventory instance ;
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
	
	public static Inventory GetInstance() 
	{
		return instance;
	}

	/// ////////////////////////// INVENTORY FUNCS
	/// 

}
