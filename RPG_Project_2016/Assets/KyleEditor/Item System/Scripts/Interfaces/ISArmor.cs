/// Kyle Bull
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
    public class ISArmor : ISObject, IISArmor, IISDestructable, IISGameObject {
        [SerializeField]int _currentArmor;
        [SerializeField]int _maxArmor;
        [SerializeField]int _durability;
        [SerializeField]int _maxDurability;
        [SerializeField]GameObject _prefab;
        public EquipmentSlot equipmentSlot;


        public ISArmor()
        {
            _currentArmor = 0;
            _maxArmor = 0;
            _durability = 1;
            _maxDurability = 1;
            _prefab = new GameObject();
            equipmentSlot = EquipmentSlot.Chest;
        }


        #region IISGameObject implmentation
        public GameObject Prefab
        {
            get
            {

            }
        }

        #endregion
        #region IISDestructable implmenation
        public void TakeDamage(int amount)
        {

        }

        public void Repair()
        {

        }

        public void Break()
        {

        }
        public int Durability
        {
            get
            {

            }
        }

        public int MaxDurability
        {
            get
            {

            }
        }


        #endregion
        #region IISArmor implmentation
        public Vector2 Armor
        {
            get
            {

            }
            set
            {

            }
        }
        #endregion
    }
}

