/// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace KyleBull.ItemSystem
{
	[System.Serializable]
	public class ISWeapon : ISObject, IISWeapon, IISDestructable,  IISGameObject
	{
		[SerializeField] int _minDamage;
		[SerializeField] int _durability;
		[SerializeField] int _maxDurability;
		[SerializeField] GameObject _prefab;

		public EquipmentSlot equipmentSlot;

		public ISWeapon()
		{
			
		}

		public ISWeapon(ISWeapon weapon)
		{
            Clone(weapon);
		}

        public void Clone(ISWeapon weapon)
        {
            base.Clone(weapon);

            _minDamage = weapon.MinDamage;
            _durability = weapon.Durability;
            _maxDurability = weapon.MaxDurability;
            equipmentSlot = weapon.equipmentSlot;
            _prefab = weapon.Prefab;
        }

		public int Attack ()
		{
			throw new System.NotImplementedException ();
		}


		public int MinDamage {
			get {
				return _minDamage;
			}
			set {
				_minDamage = value;
			}
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
				return _prefab;	
			}
		}

		public override void OnGUI(){
			base.OnGUI ();
			DisplayPrefab();
			DisplayEquipmentSlot();

            _minDamage = EditorGUILayout.IntField("Damage", _minDamage);
            GUILayout.BeginHorizontal();
            _durability = EditorGUILayout.IntField("Current Durability", _durability);
            _maxDurability = EditorGUILayout.IntField("Max Durability", _maxDurability);
            GUILayout.EndHorizontal();
        }

		public void DisplayEquipmentSlot()
		{
			equipmentSlot = (EquipmentSlot)EditorGUILayout.EnumPopup ("Equipment Slot", equipmentSlot);
		}

        public void DisplayPrefab()
        {
            _prefab = EditorGUILayout.ObjectField("Prefab: ", _prefab, typeof(GameObject), true) as GameObject;
        }
	}
}
