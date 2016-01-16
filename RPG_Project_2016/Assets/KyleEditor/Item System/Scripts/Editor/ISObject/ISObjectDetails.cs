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
<<<<<<< HEAD
            GUILayout.BeginVertical();
			tempWeapon.OnGUI ();
            GUILayout.EndVertical();
=======
			GUILayout.BeginVertical ();
			tempWeapon.OnGUI ();
			GUILayout.EndVertical ();
>>>>>>> 48e102c21c0adb5ea1466fffe7acb36a297f8ea0
		}

		void DisplayButtons ()
		{
			if (!showNewWeapon) {
				if (GUILayout.Button ("Create Weapon")) {
					tempWeapon = new ISWeapon ();
					showNewWeapon = true;
				}
			} 
<<<<<<< HEAD
			else {
				if (GUILayout.Button ("Save")) {
					showNewWeapon = false;
                    //string DATABASE_NAME = @"QualityDatabase.asset";
                    //string DATABASE_PATH = @"Database";
                    //ISQualityDatabase qdb;
           
                    //qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);
                    //tempWeapon.Quality = qdb.Get(tempWeapon.SelectedQualityID);
                    database.Add(tempWeapon);
=======
			else 
			{
				if (GUILayout.Button ("Save"))
				{
					showNewWeapon = false;
					ISQualityDatabase qdb;
					string DATABASE_NAME = @"QualityDatabase.asset";
					string DATABASE_PATH = @"Database";
					qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);
					tempWeapon.Quality = qdb.Get (tempWeapon.SelectedQualityID);
					database.Add (tempWeapon);
>>>>>>> 48e102c21c0adb5ea1466fffe7acb36a297f8ea0
					tempWeapon = null;
				}

				if (GUILayout.Button ("Cancel"))
				{
					showNewWeapon = false;
					tempWeapon = null;
				}
			}
		}
	}
}


