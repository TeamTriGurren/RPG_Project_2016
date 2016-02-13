/// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        string itemType = "Armor";
        public void ItemDetails()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            DisplayButtons();
            GUILayout.EndHorizontal();
        }
        void DisplayButtons()
        {
            if (showDetails)
            {
                Debug.Log("Show Item Details");
                SaveButton();
                CancelButton();
                DeleteButton();
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
                createNewArmor = true;

            }
        }


        void SaveButton()
        {
            GUI.SetNextControlName("SaveButton");
            if (GUILayout.Button("Save"))
            {
                showDetails = false;
                createNewArmor = false;
                _selectedIndex = -1;
                tempArmor = null;
            }
            }

        void CancelButton()
        {

            if (GUILayout.Button("Cancel"))
            {
                showDetails = false;
                createNewArmor = false;
                tempArmor = null;
                _selectedIndex = -1;
                
                GUI.FocusControl("SaveButton");
            }
        }
        void DeleteButton()
        {
        }
    }
}
