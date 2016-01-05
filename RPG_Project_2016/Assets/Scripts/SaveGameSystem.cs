using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameSystem
{
	public static bool SaveGame (SaveGame saveGame, string name)
	{
		BinaryFormatter formatter = new BinaryFormatter ();

		using (FileStream stream = new FileStream (GetSavePath (name), FileMode.Create)) {
			try {
				formatter.Serialize (stream, saveGame);
			} catch (Exception) {
				return false;
			}
		}
		return true;
	}

	public static SaveGame LoadGame (string name)
	{
		if (!DoesSaveGameExist (name)) {
			return null;
		}

		BinaryFormatter formatter = new BinaryFormatter ();

		using (FileStream stream = new FileStream (GetSavePath (name), FileMode.Open)) {
			try {
				return formatter.Deserialize (stream) as SaveGame;
			} catch (Exception) {
				return null;
			}
		}
	}

	public static bool DeleteSaveGame (string name)
	{
		try {
			File.Delete (GetSavePath (name));
		} catch (Exception) {
			return false;
		}

		return true;
	}

	public static bool DoesSaveGameExist (string name)
	{
		return File.Exists (GetSavePath (name));
	}

	private static string GetSavePath (string name)
	{
		// This is where is saved the file to. 
		// C:\Users\[username]\AppData\LocalLow\[companyname]\[projectname]  is the default. 
		return Path.Combine (Application.persistentDataPath, name + ".sav");
	}
}


//using System;

//[Serializable]
//public class MySaveGame : SaveGame
//{
//MySaveGame mySaveGame1 = new MySaveGame();
//mySaveGame1.playerName = "CloudStrife";
//mySaveGame1.HighScore Pie;
//mySaveGame1.secret = Random.Range(0, 1000).ToString();
//SaveGameSystem.SaveGame(mySaveGame1, "MySaveGame"); // Saves as MySaveGame.sav
//}

//Loading will be sort of simple and the same way
// Loading a saved game.
//MySaveGame mySaveGame2 = SaveGameSystem.LoadGame("MySaveGame") as MySaveGame;
//Debug.Log(mySaveGame2.playerName); // Will log Ryan
//Debug.Log(mySaveGame2.HighScore);  // Will log 1000000
//Debug.Log(mySaveGame2.secret);     // Will log null since this field was marked [NonSerialized]

// Deleting a saved game.
//SaveGameSystem.DeleteSaveGame("MySaveGame");