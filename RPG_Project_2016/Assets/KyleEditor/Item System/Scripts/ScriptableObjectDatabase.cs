#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace KyleBull
{
	public class ScriptableObjectDatabase<T> : ScriptableObject where T: class
	{
		[SerializeField] protected List<T> item = new List<T>();

        public List<T> Item
        {
            get
            {
                return item;
            }
        }

        public int Count
        {
            get
            {
                return item.Count;
            }
        }

        public T Get(int index)
        {
            return item.ElementAt(index);
        }
#if UNITY_EDITOR
        public void Add(T i)
        {
            item.Add(i);
            EditorUtility.SetDirty(this);
        }

        public void Insert(int index, T i)
        {
            item.Insert(index, i);
            EditorUtility.SetDirty(this);
        }

        public void Remove(T i)
        {
            item.Remove(i);
            EditorUtility.SetDirty(this);
        }

        public void Remove(int index)
        {
            item.RemoveAt(index);
            EditorUtility.SetDirty(this);
        }

        public void Replace(int index, T i)
        {
            item[index] = i;
            EditorUtility.SetDirty(this);
        }
#endif

#if UNITY_EDITOR




        public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
        {
            string dbFullPath = @"Assets/" + dbPath + "/" + dbName;
            // Checks to see if folder exists O_O!
            U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;
            if (db == null)
            {
                if (!AssetDatabase.IsValidFolder("Assets/" + dbPath))
                    AssetDatabase.CreateFolder("Assets", dbPath);

                db = ScriptableObject.CreateInstance<U>() as U;
                AssetDatabase.CreateAsset(db, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
            return db;
        }
#endif
    }
}
