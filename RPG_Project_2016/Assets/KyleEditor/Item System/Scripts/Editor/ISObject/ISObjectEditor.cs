// Kyle Bull
// RPG Project 2016
// Item System

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISObjectEditor : EditorWindow
	{

		// MenuItem code lets you assign a keyboard function, CTRL SHIFT Q in this case
		[MenuItem ("Editor/Database/Item Editor %#i")]
		// Controls the size of your Item  box.
		public static void Init ()
		{
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor> ();
			window.minSize = new Vector2 (800, 600);
			GUIContent titleContent = new GUIContent ("Item Maker");
			window.titleContent = titleContent;
			window.Show ();
		}

		void OnEnable ()
		{
		}

		void OnGUI ()
		{

			TopTabBar ();
			GUILayout.BeginHorizontal ();
			ListView ();
			ItemDetails ();
			GUILayout.EndHorizontal ();

			BottomStatusBar ();
		}
	}
}

