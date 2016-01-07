// Kyle Bull
// RPG Project 2016
// Item System

// list all of the stored qualities in the Database.
using UnityEngine;
using UnityEditor;
using System.Collections;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISQualityDatabaseEditor
	{
		
		void ListView ()
		{
			_scrollPos = EditorGUILayout.BeginScrollView (_scrollPos, GUILayout.ExpandHeight (true));
			DisplayQualities ();
			EditorGUILayout.EndScrollView ();
		}

		// Things to display, name, sprite, and a delete function
		void DisplayQualities ()
		{
			for (int i = 0; i < qualityDatabase.Count; i++) {
				GUILayout.BeginHorizontal ("Box");
				if (qualityDatabase.Get (i).Icon)
					selectedTexture = qualityDatabase.Get (i).Icon.texture;
				else
					selectedTexture = null;
				

				if (GUILayout.Button (selectedTexture, GUILayout.Width (SPRITE_BUTTON_SIZE), GUILayout.Height (SPRITE_BUTTON_SIZE))) {
					int controllerID = EditorGUIUtility.GetControlID (FocusType.Passive);
					EditorGUIUtility.ShowObjectPicker<Sprite> (null, true, null, controllerID);
					selectedIndex = i;
				}

				string commandName = Event.current.commandName;
				if (commandName == "ObjectSelectorUpdated") {
					if (selectedIndex != -1) {
						qualityDatabase.Get (selectedIndex).Icon = (Sprite)EditorGUIUtility.GetObjectPickerObject ();
						selectedIndex = -1;
						Repaint ();
					}
				}


				qualityDatabase.Get (i).Name = GUILayout.TextField (qualityDatabase.Get (i).Name);
				if (GUILayout.Button ("Delete", GUILayout.Width(60))) {
					if (EditorUtility.DisplayDialog ("Delete Quality", 
						"Do you want to Delete //" + qualityDatabase.Get (i).Name + "// from the data?", 
						"Delete (Yes)", 
						"Cancel (no)")) {
						qualityDatabase.Remove (i);
					}
						
				}
				GUILayout.EndHorizontal ();
			}
		}
	}
}