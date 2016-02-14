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


        enum DisplyState
        {
            NONE,
            WEAPONDETAILS

        };
        ISWeapon tempWeapon = new ISWeapon();
        bool showNewWeapon = false;
        DisplyState State = DisplyState.NONE;
       
		void ItemDetails()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            switch (State)
            {
                case DisplyState.NONE:
                    break;
                default:
                    break;
            }

            if (showNewWeapon)
                DisplayNewWeapon();
            GUILayout.EndHorizontal();
        }

        void DisplayNewWeapon()
        {
            GUILayout.BeginVertical();
            tempWeapon.OnGUI();
            GUILayout.EndVertical();
        }

        void DisplayButtons()
        {
            if (!showNewWeapon)
            {
                if (GUILayout.Button("Create Weapon"))
                {
                    tempWeapon = new ISWeapon();
                    showNewWeapon = true;
                    State = DisplyState.WEAPONDETAILS;
                }
            }
            else
            {
                GUI.SetNextControlName("SaveButton");
                if (GUILayout.Button("Save"))
                {
                    if (_selectedIndex == -1)
                        database.Add(tempWeapon);
                    else
                        database.Replace(_selectedIndex, tempWeapon);
                    showNewWeapon = false;
                 //   database.Add(tempWeapon);
                    tempWeapon = null;
                    _selectedIndex = -1;
                    State = DisplyState.NONE;
                    GUI.FocusControl("SaveButton");
                }
                if (_selectedIndex != -1)
                {
                    if (GUILayout.Button("Delete"))
                    {
                        if (EditorUtility.DisplayDialog("Delete" + database.Get(_selectedIndex).Name + "?",
                    "Do you want to Delete " + database.Get(_selectedIndex).Name + " from the data?",
                    "Delete (Yes)",
                    "Cancel (no)"))
                        {
                            database.Remove(_selectedIndex);
                            showNewWeapon = false;
                            tempWeapon = null;
                            _selectedIndex = -1;
                            State = DisplyState.NONE;
                            GUI.FocusControl("SaveButton");
                        }

                   
                    }
                }

                if (GUILayout.Button("Cancel"))
                {
                    showNewWeapon = false;
                    tempWeapon = null;
                    _selectedIndex = -1;
                    State = DisplyState.NONE;
                    GUI.FocusControl("SaveButton");
                }
            }
        }
    }
}


