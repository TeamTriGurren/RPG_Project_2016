// Kyle Bull
// RPG Project 2016
// Item System
#if UNITY_EDITOR
using UnityEditor;
#endif
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

    
        public ISObject()
        {

        }
        public ISObject(ISObject item)
        {
            Clone(item);
        }
        public void Clone(ISObject item)
        {
            _name = item.Name;
            _icon = item.Icon;
            _value = item.Value;
            _quality = item.Quality;
        }

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
#if UNITY_EDITOR
        int qualitySelectedIndex = 0;
		string [] options; 
		ISQualityDatabase qdb;
        bool qualityDatabaseLoade = false;

	
		virtual public void  OnGUI ()
		{
			GUILayout.BeginVertical ();
            GUILayout.BeginHorizontal();
            GUILayout.BeginVertical();
            _name = EditorGUILayout.TextField ("Name: ", _name);
            
			DisplayQuality ();
            _value = EditorGUILayout.IntField("Value", _value);
            GUILayout.EndVertical();
            DisplayIcon ();
            GUILayout.EndHorizontal();
			
			GUILayout.EndVertical ();

		}
		public int SelectedQualityID {
			get {
				return qualitySelectedIndex;
			}
		}

		public void LoadQualityDatabase()
		{
			 string DATABASE_NAME = @"QualityDatabase.asset";
			 string DATABASE_PATH = @"Database";
			qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase> (DATABASE_PATH, DATABASE_NAME);

			options = new string[qdb.Count];
			for (int i = 0; i < qdb.Count; i++) {
				options [i] = qdb.Get (i).Name;
			}
            qualityDatabaseLoade = true;
		}


		public void DisplayIcon(){
            _icon = EditorGUILayout.ObjectField("Icon: ", _icon, typeof(Sprite), false, GUILayout.Height(50)) as Sprite;
		}

		public void DisplayQuality()
		{
            if(!qualityDatabaseLoade)
            {
                LoadQualityDatabase();
                return;
            }
            int itemIndex = 0;

            if (_quality != null)
                itemIndex = qdb.GetIndex(_quality.Name);

            if (itemIndex == -1)
                itemIndex = 0;
			qualitySelectedIndex = EditorGUILayout.Popup ("Quality: ", qualitySelectedIndex, options);
	    	_quality = qdb.Get (SelectedQualityID);
		}

#endif
    }
}
