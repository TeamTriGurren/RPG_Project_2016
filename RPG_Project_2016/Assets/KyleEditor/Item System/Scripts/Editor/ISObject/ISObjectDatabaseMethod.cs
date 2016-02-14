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
            Database.Item.Add(item);
            EditorUtility.SetDirty(Database);
        }

        public void Insert(int index, T item)
        {
            Database.Item.Insert(index, item);
            EditorUtility.SetDirty(Database);
        }

        public void Remove(T item)
        {
            Database.Item.Remove(item);
            EditorUtility.SetDirty(Database);
        }

        public void Remove(int index)
        {
            Database.Item.RemoveAt(index);
            EditorUtility.SetDirty(Database);
        }

        public void Replace(int index, T item)
        {
            Database.Item[index] = item;
            EditorUtility.SetDirty(Database);
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
