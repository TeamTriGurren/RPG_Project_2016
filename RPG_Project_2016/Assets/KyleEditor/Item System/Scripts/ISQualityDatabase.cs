// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq; // needed for Element

namespace KyleBull.ItemSystem
{
	public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
	{
        public int GetIndex(string name)
        {
            return database.FindIndex(a => a.Name == name);
        }
	}

}
