using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

// D database T type
namespace KyleBull.ItemSystem.Editor
{
    public class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
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

        void LoadDatabase()
        {
            string dbFullPath = @"Assets/" + DatabasePath + "/" + DatabaseName;
            // Checks to see if folder exists O_O!
            Database = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(D)) as D;
            if (Database == null)
            {
                CreateDatabase(dbFullPath);
            }

        }

        void CreateDatabase(string dbFullPath)
        {
            if (!AssetDatabase.IsValidFolder("Assets/" + DatabasePath))
                AssetDatabase.CreateFolder("Assets", DatabasePath);

            Database = ScriptableObject.CreateInstance<D>() as D;
            AssetDatabase.CreateAsset(Database, dbFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
