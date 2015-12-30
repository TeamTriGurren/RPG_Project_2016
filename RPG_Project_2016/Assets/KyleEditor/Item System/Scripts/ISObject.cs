// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem
{
	public class ISObject : IISObject
	{
		[SerializeField]string _name;
		[SerializeField]Sprite _icon;
		[SerializeField]int _value;
		[SerializeField]ISQuality _quality;

		public string ISName {
			get {
				return _name;
			} 
			set {
				_name = value; 
			}
		}

		public int ISValue {
			get {
				return _value;
			} 
			set {
				_value = value;
			}
		}

		public Sprite ISIcon {
			get {
				return _icon;
			} 
			set {
				_icon = value;
			}
		}

		public ISQuality ISQuality {
			get {
				return _quality;
			} 
			set {
				_quality = value;
			}
		}
	}
}
