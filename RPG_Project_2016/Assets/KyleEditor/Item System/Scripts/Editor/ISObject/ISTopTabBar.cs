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

		void TopTabBar ()
		{
			GUILayout.BeginHorizontal ("Box", GUILayout.ExpandWidth (true));
			WeaponTab ();
			ArmorTab ();
			ItemsTab ();
			AboutTab ();
			GUILayout.EndHorizontal ();
		}

		void WeaponTab()
		{
			GUILayout.Button ("Weapons");
		}

		void ArmorTab()
		{
			GUILayout.Button ("Armor");
		}
		void ItemsTab()
		{
			GUILayout.Button ("Items");
		}
		void AboutTab()
		{
			GUILayout.Button ("About");
		}


	}
}
