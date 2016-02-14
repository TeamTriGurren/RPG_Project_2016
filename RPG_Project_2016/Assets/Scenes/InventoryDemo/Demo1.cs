// This is just a demo/test to make sure items can go from the datata to game
// spawning

using UnityEngine;
using System.Collections;
using KyleBull.ItemSystem; // This line is needed on everything to call the item
//


[DisallowMultipleComponent]
public class Demo1 : MonoBehaviour {
    public ISWeaponDatabase database;// calls the data

    void OnGUI()
    {
        for (int i = 0; i <database.Count; i++)
        if(GUILayout.Button("Spawn Items " + database.Get(i).Name))
        {
            Spawn(i);
        }
    }

    void Spawn(int index)
    {
        ISWeapon isw = database.Get(index);
        GameObject weapon = Instantiate(isw.Prefab);
        weapon.name = isw.Name;
        Weapon myWeapon = weapon.AddComponent<Weapon>();
        myWeapon.Icon = isw.Icon;
        myWeapon.Value = isw.Value;
        myWeapon.Quality = isw.Quality.Icon;
        myWeapon.MinDamage = isw.MinDamage;
        myWeapon.MaxDurabilty = isw.MaxDurability;
        myWeapon.Durability = isw.Durability;
    //    myWeapon.EquipmentSlot = isw.Equipment_Slot;
        myWeapon.Equipment_Slot = isw.equipmentSlot;
    }

}
