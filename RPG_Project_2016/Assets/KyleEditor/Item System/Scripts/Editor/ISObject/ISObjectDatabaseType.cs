using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

// D item T type
namespace KyleBull.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
    {
        [SerializeField]private D database;
        [SerializeField]string databaseName;
        [SerializeField]string databasePath = @"Database";

        public ISObjectDatabaseType(string n)
        {
            databaseName = n;

        }

        public void OnEnable()
        {
            if (database == null)
            {
                LoadDatabase();
            }
        }

        public void OnGUI()
        {
        //    ListView();
          //  ItemDetails();
        }
    }
}
