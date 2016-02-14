/// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISObjectCategory
	{

        Vector2 _scrollPos = Vector2.zero;
        int _listViewWidth = 200;
        int _selectedIndex = -1;
        ISArmor tempArmor;
        bool showDetails = false;
       


        public void ListView ()
		{
            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int i = 0; i < Database.Count; i++)
            {
                if (GUILayout.Button(Database.Get(i).Name, "box", GUILayout.Width(_listViewWidth - 10)))
                {
                    _selectedIndex = i;
                    tempArmor = new ISArmor(Database.Get(i));
                    showDetails = true;   
                }
            }
     //       DisplayButtons();
            EditorGUILayout.EndScrollView();
        }
	}
}