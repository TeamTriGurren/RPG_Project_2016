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


		void ListView ()
		{
			_scrollPos = GUILayout.BeginScrollView (_scrollPos, "Box", GUILayout.ExpandHeight (true), GUILayout.Width(_listViewWidth));
			EditorGUILayout.EndScrollView ();
		}
	}
}
