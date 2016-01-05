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
		public List<ISQuality> database = new List<ISQuality> ();

		public void Add(ISQuality item)
		{
			database.Add (item);
		}
	}
}
