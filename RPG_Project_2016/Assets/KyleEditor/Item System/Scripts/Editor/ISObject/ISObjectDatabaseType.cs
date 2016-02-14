using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

// D item T type
namespace KyleBull.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
    {
        [SerializeField]private D Database;
        [SerializeField]string DatabaseName;
        [SerializeField]string DatabasePath = @"Database";

        public ISObjectDatabaseType(string n)
        {
            DatabaseName = n;

        }

        public void OnEnable()
        {
            if (Database == null)
            {
                LoadDatabase();
            }
        }

        public void OnGUI()
        {

        }
    }
}
