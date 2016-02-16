
/// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using System.Collections;

namespace KyleBull.ItemSystem.Editor
{
	public partial class ISObjectCategory
	{
		protected ISArmorDatabase Database { get; set; }
		protected string DatabaseName { get; set; }
		const string DATABASE_PATH = @"Database";

  
        public ISObjectCategory()
		{
			DatabaseName = @"ArmorDatabase.asset";
		}

		public string DatabaseFullPath {
			get { return @"Assets/" + DATABASE_PATH + "/" + DatabaseName; }
		}

		public void OnEnable ()
		{
			if (Database == null)
				Database = ISArmorDatabase.GetDatabase<ISArmorDatabase> (DATABASE_PATH, DatabaseName);
		}

        public void OnGUI()
        {
            ListView();
            ItemDetails();
        }
	}
}
