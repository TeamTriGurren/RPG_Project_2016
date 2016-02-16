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
        string itemType = "Armor";


        public void ItemDetails()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            if (showDetails)
                tempArmor.OnGUI();
            DisplayButtons();
            GUILayout.EndVertical();
            GUILayout.EndHorizontal();
        }
        void DisplayButtons()
        {
            if (showDetails)
            {

                SaveButton();
                if (_selectedIndex > -1)
                {
                    DeleteButton();
                }
                CancelButton();

            }
            else
            {
                CreateItemButton();
            }
        }
        void CreateItemButton()
        {
            if (GUILayout.Button("Create " + itemType))
            {
                tempArmor = new ISArmor();
                showDetails = true;
            }
        }


        void SaveButton()
        {
            GUI.SetNextControlName("SaveButton");
            if (GUILayout.Button("Save"))
            {
                GUI.SetNextControlName("SaveButton");
                if (GUILayout.Button("Save"))
                {
                    if (_selectedIndex == -1)
                       Database.Add(tempArmor);
                    else
                        Database.Replace(_selectedIndex, tempArmor);

                    showDetails = false;
                    
                    _selectedIndex = -1;
                    GUI.FocusControl("SaveButton");
                    tempArmor = null;
                }
            }
        }

        void CancelButton()
        {

            if (GUILayout.Button("Cancel"))
            {
                showDetails = false;
               
                tempArmor = null;
                _selectedIndex = -1;

                GUI.FocusControl("SaveButton");
            }
        }
        void DeleteButton()
        {
            if (GUILayout.Button("Delete"))
            {

                if (EditorUtility.DisplayDialog("Delete " + Database.Get(_selectedIndex).Name +"?",
            "Do you want to Delete " + Database.Get(_selectedIndex).Name + " from the data?",
            "Delete (Yes)",
            "Cancel (no)"))
                {
                    Database.Remove(_selectedIndex);
                    showDetails = false;
                    tempArmor = null;
                    _selectedIndex = -1;
                   
                    GUI.FocusControl("SaveButton");
                }
            }
        }
    }
}
