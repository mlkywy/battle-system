using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHp;
    public int currentHp;
    public int maxSp;
    public int currentSp;

    public int level;
    public int attackPower;
    public int strength;
    public int intelligence;
    public int agility;
    public int luck;
    public int defense;

    /// <summary>
    /// Contains a list of the unit's abilities (special attacks and spells)
    /// </summary>
    public List<AbilityObject> abilities;
}
