// Kyle Bull
// RPG Project 2016
// Item System


using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
	public interface IISStackable
	{
		int Stack (int amount);
		int MaxStack{get;}
			

	}
}
