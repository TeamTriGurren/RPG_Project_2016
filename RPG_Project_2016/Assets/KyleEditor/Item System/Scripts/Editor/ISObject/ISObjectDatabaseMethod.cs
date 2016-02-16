// Kyle Bull
// RPG Project 2016
// Item System

using UnityEditor;
using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
{

        public void Add(T item)
        {
            database.Item.Add(item);
            EditorUtility.SetDirty(database);
        }

        public void Insert(int index, T item)
        {
            database.Item.Insert(index, item);
            EditorUtility.SetDirty(database);
        }

        public void Remove(T item)
        {
            database.Item.Remove(item);
            EditorUtility.SetDirty(database);
        }

        public void Remove(int index)
        {
            database.Item.RemoveAt(index);
            EditorUtility.SetDirty(database);
        }

        public void Replace(int index, T item)
        {
            database.Item[index] = item;
            EditorUtility.SetDirty(database);
        }

    

        void LoadDatabase()
        {
            string dbFullPath = @"Assets/" + databasePath + "/" + databaseName;
            // Checks to see if folder exists O_O!
            database = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(D)) as D;
            if (database == null)
            {
                CreateDatabase(dbFullPath);
            }

        }


        void CreateDatabase(string dbFullPath)
        {
            if (!AssetDatabase.IsValidFolder("Assets/" + databasePath))
                AssetDatabase.CreateFolder("Assets", databasePath);

            database = ScriptableObject.CreateInstance<D>() as D;
            AssetDatabase.CreateAsset(database, dbFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
