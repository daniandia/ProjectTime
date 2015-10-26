using UnityEngine;
using System.Collections;
using System.IO;
using LitJson;

public class loadJSON : Singleton<loadJSON> {

	public JsonData loadFile(string level)
	{
		string jsonString;

		if (level != "") {
			jsonString = File.ReadAllText (Application.dataPath + "/Resources/Levels/" + level + "/dialog.json");
			//Debug.Log (jsonString);
			return JsonMapper.ToObject(jsonString);
		}

		return null;
	}
}