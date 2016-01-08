/// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
public interface IISWeapon {
		int MinDamage { get; set; }
		int Attack(); 
	}
}
