using UnityEngine;
using System.Collections;

[System.Serializable]
public class Monsters {
    float baseHP;
    float curHP;
    float baseATK;
    float curATK;
    float baseDEF;
    float curDEF;
    float baseSPATK;
    float curSPATK;
    float baseSPDEF;
    float curSPDEF;
    float speed;
    string name;
    int level;
}

    public enum Type
    {
        Human,
        Dragon,
        Undead,
        Fire,
        Wind,
        Water,
        Earth,
        Plant,
        Electric
    }

