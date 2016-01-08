// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISObjectEditor
	{
		void BottomStatusBar(){
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));
			GUILayout.Label ("Bottom Status Bar");

			DisplayButtons();
			GUILayout.EndHorizontal ();
		}

	}
}