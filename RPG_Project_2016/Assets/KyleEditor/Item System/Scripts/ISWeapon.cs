/// Kyle Bull
// RPG Project 2016
// Item System

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace KyleBull.ItemSystem
{
	[System.Serializable]
	public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISEquipable, IISGameObject
	{
		[SerializeField] int _minDamage;
		[SerializeField] int _durability;
		[SerializeField] int _maxDurability;
		[SerializeField] ISEquipmentSlot _equipmentSlot;
		[SerializeField] GameObject _prefab;

		public ISWeapon()
		{
			_equipmentSlot = new ISEquipmentSlot ();
		}

		public ISWeapon(int durability, int maxDurability, ISEquipmentSlot equipmentSlot, GameObject prefab)
		{
			_durability = durability;
			_maxDurability = maxDurability;
			_equipmentSlot = equipmentSlot;
			_prefab = prefab;
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



		public bool Equip ()
		{
			throw new System.NotImplementedException ();
		}

		public ISEquipmentSlot Equipmentslot {
			get {
				return _equipmentSlot;
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
			DisplayEquipmentslot();

			_minDamage = System.Convert.ToInt32(EditorGUILayout.TextField ("Damage:  ", _minDamage.ToString()));
			_durability = System.Convert.ToInt32(EditorGUILayout.TextField ("Durability: ", _durability.ToString()));
			_maxDurability = System.Convert.ToInt32(EditorGUILayout.TextField ("Max Durability: ", _maxDurability.ToString()));

		}

		public void DisplayEquipmentslot()
		{
			GUILayout.Label("Equipmet slot: Still on todo");
		}

		public void DisplayPrefab()
		{
			GUILayout.Label("Prefab: Still on todo");
		}

	}
}
