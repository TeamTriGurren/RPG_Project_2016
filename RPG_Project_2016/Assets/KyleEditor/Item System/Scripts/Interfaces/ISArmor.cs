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
         //   _prefab = new GameObject();
            equipmentSlot = EquipmentSlot.Chest;
        }

		public ISArmor(ISArmor armor)
		{
			Clone(armor);
		}

		public void Clone(ISArmor armor)
		{
			base.Clone(armor);

			_currentArmor = armor._currentArmor;
			_maxArmor = armor._maxArmor;
			_durability = armor.Durability;
			_maxDurability = armor.MaxDurability;
			equipmentSlot = armor.equipmentSlot;
			_prefab = armor.Prefab;
		}

		public void TakeDamage (int amount)
		{
			_durability -= amount;
			if (_durability < 0)
				_durability = 0;

			if (_durability == 0)
				Break();

		}
		// Reduces Dur to 0;
		public void Break ()
		{
			_durability = 0;
		}

		public void Repair ()
		{
			_durability = _maxDurability;
		}

		public int Durability {
			get {
				return _durability;
			}
		}

		public int MaxDurability {
			get {
				return _maxDurability;
			}
		}

		public GameObject Prefab {
			get {
				if (!_prefab)
					_prefab = new GameObject ();
				
				return _prefab;	
			}
		}
			
        public Vector2 Armor
        {
            get
            {
				return new Vector2(_currentArmor, _maxArmor);
            }
            set
            {
				if (value.x < 0)
					value.x = 0;
				if (value.y < 1)
					value.y = 1;
				if (value.x > value.y)
					value.x = value.y;

				_currentArmor = (int)value.x;
				_maxArmor = (int)value.y;
            }
        }

    }
}

