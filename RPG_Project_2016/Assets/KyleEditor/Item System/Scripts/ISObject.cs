// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
	[System.Serializable]
	public class ISObject : IISObject
	{
		[SerializeField]string _name;
		[SerializeField]Sprite _icon;
		[SerializeField]int _value;
		[SerializeField]ISQuality _quality;

		public string Name {
			get {
				return _name;
			} 
			set {
				_name = value; 
			}
		}

		public int Value {
			get {
				return _value;
			} 
			set {
				_value = value;
			}
		}

		public Sprite Icon {
			get {
				return _icon;
			} 
			set {
				_icon = value;
			}
		}

		public ISQuality Quality {
			get {
				return _quality;
			} 
			set {
				_quality = value;
			}
		}
	}
}
