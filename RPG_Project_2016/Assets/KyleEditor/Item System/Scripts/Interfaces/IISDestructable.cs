// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
public interface IISDestructable  {
		int Durability { get; }
		int MaxDurability { get; }
		void TakeDamage (int amount);
		void Break ();
		void Repair();
	}
}
