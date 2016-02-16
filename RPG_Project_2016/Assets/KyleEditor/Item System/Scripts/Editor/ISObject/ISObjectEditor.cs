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
		ISWeaponDatabase database;
		ISObjectCategory armorDatabase = new ISObjectCategory();
        ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weaponDB = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>("weaponTest.asset");
        ISObjectDatabaseType<ISArmorDatabase, ISArmor> armorDB = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>("armorTest.asset");

        const string DATABASE_NAME = @"WeaponsDatabase.asset";
		const string DATABASE_PATH = @"Database";
		const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;

        



		// MenuItem code lets you assign a keyboard function, CTRL SHIFT Q in this case
		[MenuItem("Editor/Database/Item Editor %i")]
		// Controls the size of your Item  box.
		public static void Init ()
		{
			ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor> ();
			window.minSize = new Vector2 (800, 600);
			GUIContent titleContent = new GUIContent ("Item Maker");
			window.titleContent = titleContent;
			//window.titleContent = new GUIContent can have image
			window.Show ();
		}

		void OnEnable ()
		{
            if (database == null)
                database = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_PATH, DATABASE_NAME);
            armorDatabase.OnEnable();
            weaponDB.OnEnable();
            armorDB.OnEnable();
			
			tabState = TabState.ABOUT;
        }

		void OnGUI ()
		{

			TopTabBar ();
			GUILayout.BeginHorizontal ();
            switch (tabState)
            {
                case TabState.WEAPON:
                   // weaponDB.OnGUI();
                    DisplayButtons();
                    ListView();
                    ItemDetails();
                    break;
                case TabState.ARMOR:
         //           armorDB.OnGUI();
                    armorDatabase.OnGUI();
                    break;
                case TabState.CONSUMABLE:

                    break;
                default:
                    break;
            }
			
			GUILayout.EndHorizontal ();
			BottomStatusBar();
		}
	}
}

