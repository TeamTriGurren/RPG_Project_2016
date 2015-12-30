// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
	public interface IISQuality
	{
		string Name { get; set; }

		Sprite Icon{ get; set; }
	}
}