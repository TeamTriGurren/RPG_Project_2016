// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace KyleBull.ItemSystem.Editor
{
	public class ISQualityDatabaseEditor : EditorWindow
	{
		ISQualityDatabase db;
		const string DATABASE_FILE_NAME = @"QualityDatabase.asset";
		const string DATABASE_FOLDER_NAME = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/"+ DATABASE_FOLDER_NAME +"/"+ DATABASE_FILE_NAME;

		[MenuItem ("Editor/Database/Quality Editor %#Q")]
		public static void Init ()
		{
			ISQualityDatabaseEditor window = EditorWindow.GetWindow<ISQualityDatabaseEditor> ();
			window.minSize = new Vector2 (500, 300);
			GUIContent titleContent = new GUIContent ("Qty Level");
			window.titleContent = titleContent;
			window.Show ();
		}

		void OnEnable ()
		{
			db = AssetDatabase.LoadAssetAtPath (DATABASE_FULL_PATH, typeof(ISQualityDatabase)) as ISQualityDatabase;
			if (db == null) {
				if (!AssetDatabase.IsValidFolder ("Assets/" + DATABASE_FOLDER_NAME)) 
					AssetDatabase.CreateFolder ("Assets", DATABASE_FOLDER_NAME);

					db = ScriptableObject.CreateInstance<ISQualityDatabase> ();
					AssetDatabase.CreateAsset (db, DATABASE_FULL_PATH);
					AssetDatabase.SaveAssets ();
					AssetDatabase.Refresh ();
				
			}
		}
	}
}