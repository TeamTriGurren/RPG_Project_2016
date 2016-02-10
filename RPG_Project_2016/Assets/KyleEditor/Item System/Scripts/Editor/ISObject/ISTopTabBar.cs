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

        private enum TabState
        {
            WEAPON, 
            ARMOR,
            CONSUMABLE,
            ABOUT
        }

        TabState tabState;

		void TopTabBar ()
		{
			GUILayout.BeginHorizontal ( GUILayout.ExpandWidth (true));
			WeaponTab ();
			ArmorTab ();
			ConsumableTab ();
			AboutTab ();
			GUILayout.EndHorizontal ();
		}

		void WeaponTab()
		{
            if (GUILayout.Button("Weapons"))
                tabState = TabState.WEAPON;
		}

		void ArmorTab()
		{
            if (GUILayout.Button("Armor"))
                tabState = TabState.ARMOR;
		}
		void ConsumableTab()
		{
            if (GUILayout.Button("Consumables"))
                tabState = TabState.CONSUMABLE;
		}
		void AboutTab()
		{
            if (GUILayout.Button("About"))
                tabState = TabState.ABOUT;
		}


	}
}
