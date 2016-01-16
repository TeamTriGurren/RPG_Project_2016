// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISQualityDatabaseEditor : EditorWindow
	{
		ISQualityDatabase qualityDatabase;
		//		ISQuality selectedItem;
		Texture2D selectedTexture;
		int selectedIndex = -1;
		Vector2 _scrollPos;
		//List View class

		const int SPRITE_BUTTON_SIZE = 46;
		const string DATABASE_NAME = @"QualityDatabase.asset";
		const string DATABASE_PATH = @"Database";
		//const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;

		// MenuItem code lets you assign a keyboard function, CTRL SHIFT Q in this case
		[MenuItem ("Editor/Database/Quality Editor %Q")]
		// Controls the size of your Quality box.
		public static void Init ()
		{
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor> ();
			window.minSize = new Vector2 (500, 300);
			GUIContent titleContent = new GUIContent ("Qty Level");
			window.titleContent = titleContent;
			window.Show ();
		}

		// This part of the code makes sure a folder is created. If it isnt it makes one.
		void OnEnable ()
		{
			if (qualityDatabase ==null)
			qualityDatabase = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);
		}

		void OnGUI ()
		{
			if (qualityDatabase == null) {
				Debug.LogWarning ("Could not load Quality DB");
				return;
			}
			//The interface for Quality. Calling other functions
			ListView ();
			//AddQualityToDatabase ();
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));
			BottomBar ();
			GUILayout.EndHorizontal ();
		}

		void BottomBar ()
		{
			GUILayout.Label ("Qualities: " + qualityDatabase.Count);
			if (GUILayout.Button ("Add new")) {
				qualityDatabase.Add (new ISQuality ());
			}
		}
	}
}