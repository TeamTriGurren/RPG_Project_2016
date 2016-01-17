/// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISObjectEditor {
		
		Vector2 _scrollPos = Vector2.zero;
		int _listViewWidth = 200;

        int _selectedIndex = -1;

		void ListView ()
		{
            if (State != DisplyState.NONE)
                return;

			_scrollPos = GUILayout.BeginScrollView (_scrollPos, "Box", GUILayout.ExpandHeight (true), GUILayout.Width(_listViewWidth));

            for (int i =0; i < database.Count; i ++)
            {
                if(GUILayout.Button(database.Get(i).Name, "box", GUILayout.Width(_listViewWidth-10)))
                {
                    _selectedIndex = i;
                    tempWeapon = new ISWeapon(database.Get(i));
                    showNewWeapon = true;
                    State = DisplyState.WEAPONDETAILS;
                }
            }

            EditorGUILayout.EndScrollView ();
		}
	}
}
