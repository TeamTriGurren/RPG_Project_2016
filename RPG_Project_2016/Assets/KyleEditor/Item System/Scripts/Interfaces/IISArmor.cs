/// Kyle Bull
// RPG Project 2016
// Item System
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
    public interface IISArmor 
    {
        Vector2 Armor { get; set; } 
    }
}
