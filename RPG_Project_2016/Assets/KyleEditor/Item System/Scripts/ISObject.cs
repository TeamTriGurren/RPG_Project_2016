// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using UnityEditor;
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


       //  This is what will display under weapon. Class later
        ISQualityDatabase qdb;
        int qualitySelectedIndex = 0;
        string[] options;
        
        public virtual void OnGUI()
        {
            GUILayout.BeginVertical();
            _name = EditorGUILayout.TextField("Name", _name);
            DisplayIcon();
            DisplayQuality();
            _value = EditorGUILayout.IntField("Value", _value);
            GUILayout.EndVertical();

        }
        public void DisplayIcon()
        {
            GUILayout.Label("Icon: ");
        }

        public int SelectedQualityID
        {
            get {
                return qualitySelectedIndex;
            }
        }

        public ISObject ()
        {
            string DATABASE_NAME = @"QualityDatabase.asset";
             string DATABASE_PATH = @"Database";
             qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);

             options = new string[qdb.Count];
            for(int i = 0; i <qdb.Count; i++)
            {
                options[i] = qdb.Get(i).Name;
            }
        }

       
        public void DisplayQuality()
        {
           qualitySelectedIndex = EditorGUILayout.Popup("Quality", qualitySelectedIndex, options);
           _quality = qdb.Get(SelectedQualityID);
        }
	}
}
