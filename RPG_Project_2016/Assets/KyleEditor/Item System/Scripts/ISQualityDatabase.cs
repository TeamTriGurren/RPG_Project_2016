// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace KyleBull.ItemSystem
{
	public class ISQualityDatabase : ScriptableObject
	{
		//[SerializeField]
		List<ISQuality> db = new List<ISQuality> ();

		public void Add(ISQuality item)
		{
			db.Add (item);
		}
	}
}
