using UnityEngine;
using System.Collections;

public class BattleController : MonoBehaviour {
    int i;

    public class Monster
    {
        
    }
    public void makeMonster()
    {
        Monsters[] monster = new Monsters[5];
        for (int i = 0; i < monster.Length; i++)
            monster[i] = new Monsters();
    }
}
