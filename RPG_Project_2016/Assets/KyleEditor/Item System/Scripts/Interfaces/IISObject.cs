// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
	public interface IISObject
	{
		//Stuff we need for items
		//Name
		//Value - Gold/Currency
		//Sprite - Icon
		//Equipable
		//Quality
		//QuestItems - Key Items


		string ISName{ get; set; }

		int ISValue{ get; set; }

		Sprite ISIcon{ get; set; }
	}
}