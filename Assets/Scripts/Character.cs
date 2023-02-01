using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int maxHp;
    public int currentHp;
    public int maxSp;
    public int currentSp;

    public int level;
    public int physicalAttackPower;
    public int magicAttackPower;
    public int strength;
    public int intelligence;
    public int agility;
    public int luck;
    public int defense;

    /// <summary>
    /// Contains a list of the character's abilities (special attacks and spells)
    /// </summary>
    public List<AbilityObject> abilities;
}
