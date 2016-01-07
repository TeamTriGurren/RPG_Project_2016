// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;
using UnityEditor;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISObjectEditor {
		void ItemDetails()
		{
			GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
			GUILayout.Label ("Detail Views");
			GUILayout.EndHorizontal ();
		}
	}
}
