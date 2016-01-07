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
		Vector2 _scrollPos; //List View class

		const int SPRITE_BUTTON_SIZE = 46;
		const string DATABASE_FILE_NAME = @"QualityDatabase.asset";
		const string DATABASE_FOLDER_NAME = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_FOLDER_NAME + "/" + DATABASE_FILE_NAME;

		// MenuItem code lets you assign a keyboard function, CTRL SHIFT Q in this case
		[MenuItem ("Editor/Database/Quality Editor %#Q")]
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
			qualityDatabase = AssetDatabase.LoadAssetAtPath (DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;
			if (qualityDatabase == null) {
				if (!AssetDatabase.IsValidFolder ("Assets/" + DATABASE_FOLDER_NAME))
					AssetDatabase.CreateFolder ("Assets", DATABASE_FOLDER_NAME);

				qualityDatabase = ScriptableObject.CreateInstance<ISQualityDatabase> ();
				AssetDatabase.CreateAsset (qualityDatabase, DATABASE_FULL_PATH);
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh ();
				
			}
//			selectedItem = new ISQuality ();
		}

		void OnGUI ()
		{
			//The interface for Quality. Calling other functions
			ListView();
			//AddQualityToDatabase ();
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
			BottomBar();
			GUILayout.EndHorizontal ();
		}

		void BottomBar(){
			GUILayout.Label("Qualities: " + qualityDatabase.Count);
			if(GUILayout.Button("Add new"))
			{
				qualityDatabase.Add (new ISQuality ());
		}
		}


//		void AddQualityToDatabase ()
//		{
//			// This Function fills in the interface for Quality
//			//Name
//			//Sprite
//			selectedItem.Name = EditorGUILayout.TextField ("Name: ", selectedItem.Name);
//			if (selectedItem.Icon)
//				selectedTexture = selectedItem.Icon.texture;
//			else
//				selectedTexture = null;
//			//Button to bring up a second menu to select icon.
//			if (GUILayout.Button (selectedTexture, GUILayout.Width (SPRITE_BUTTON_SIZE), GUILayout.Height (SPRITE_BUTTON_SIZE))) {
//				int controllerID = EditorGUIUtility.GetControlID (FocusType.Passive);
//				EditorGUIUtility.ShowObjectPicker<Sprite> (null, true, null, controllerID);
//			}
//
//			string commandName = Event.current.commandName;
//			if (commandName == "ObjectSelectorUpdated") {
//				selectedItem.Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject ();
//				Repaint ();
//			}
//
//			if (GUILayout.Button ("Save Quality")) {
//				if (selectedItem == null)
//					return;
//
//				if (selectedItem.Name == "")
//					return;
//
//				qualityDatabase.Add (selectedItem);
//				selectedItem = new ISQuality();
//			}
//		}
	}
}