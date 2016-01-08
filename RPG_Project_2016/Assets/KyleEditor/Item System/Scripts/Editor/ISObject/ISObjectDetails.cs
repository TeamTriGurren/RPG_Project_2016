// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		ISWeapon tempWeapon = new ISWeapon ();
		bool showNewWeapon = false;

		void ItemDetails ()
		{
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true), GUILayout.ExpandHeight (true));
			if (showNewWeapon)
				DisplayNewWeapon ();
			GUILayout.EndHorizontal ();
		}

		void DisplayNewWeapon ()
		{
			tempWeapon.OnGUI ();
		}

		void DisplayButtons ()
		{
			if (!showNewWeapon) {
				if (GUILayout.Button ("Create Weapon")) {
					tempWeapon = new ISWeapon ();
					showNewWeapon = true;
				}
			} 
			if (showNewWeapon) {
				if (GUILayout.Button ("Save")) {
					showNewWeapon = false;
					tempWeapon = null;
				}

				if (GUILayout.Button ("Cancel")) {
					showNewWeapon = false;
					tempWeapon = null;
				}
			}
		}
	}

}
