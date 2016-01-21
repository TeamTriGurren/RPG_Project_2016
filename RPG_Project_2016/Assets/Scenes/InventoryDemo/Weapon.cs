using UnityEngine;
using System.Collections;
using KyleBull.ItemSystem;

[DisallowMultipleComponent]
public class Weapon : MonoBehaviour {
    public Sprite Icon;
    public int Value;
    public Sprite Quality;
    public int MinDamage;
    public int Durability;
    public int MaxDurabilty;
    public EquipmentSlot Equipment_Slot;

}
