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
		// Future class
		//

		int qualitySelectedIndex = 0;
		string [] options; 
		ISQualityDatabase qdb;

	
		virtual public void  OnGUI ()
		{
			GUILayout.BeginVertical ();
			_name = EditorGUILayout.TextField ("Name: ", _name);
			DisplayQuality ();
			DisplayIcon ();
			_value = System.Convert.ToInt32(EditorGUILayout.TextField ("Value: ", _value.ToString()));
			GUILayout.EndVertical ();

		}
		public int SelectedQualityID {
			get {
				return qualitySelectedIndex;
			}
		}

		public ISObject()
		{
			 string DATABASE_NAME = @"QualityDatabase.asset";
			 string DATABASE_PATH = @"Database";
			qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);

			options = new string[qdb.Count];
			for (int i = 0; i < qdb.Count; i++) {
				options [i] = qdb.Get (i).Name;
			}
		}


		public void DisplayIcon(){
			GUILayout.Label("Icon: To do");
		}

		public void DisplayQuality()
		{
			qualitySelectedIndex = EditorGUILayout.Popup ("Quality", qualitySelectedIndex, options);
			_quality = qdb.Get (SelectedQualityID);
		}
	}
}
