using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    /// <summary>
    /// The character's name.
    /// </summary>
    public string unitName;

    /// <summary>
    /// The character's maximum health points.
    /// </summary>
    public int maxHp;

    /// <summary>
    /// The character's current health points.
    /// </summary>
    public int currentHp;

    /// <summary>
    /// The character's maximum skill points.
    /// </summary>
    public int maxSp;

    /// <summary>
    /// The character's current skill points.
    /// </summary>
    public int currentSp;

    /// <summary>
    /// The character's current level.
    /// </summary>
    public int level;

    /// <summary>
    /// The character's base physical attack power.
    /// </summary>
    public int physicalAttackPower;

    /// <summary>
    /// The character's base magic attack power.
    /// </summary>
    public int magicAttackPower;

    /// <summary>
    /// The character's strength stat. This affects their physical attack damage output.
    /// </summary>
    public int strength;

    /// <summary>
    /// The character's intelligence stat. This affects the output of both offensive and healing spells.
    /// </summary>
    public int intelligence;

    /// <summary>
    /// The character's agility stat. This affects their chance of dodging an opponent's attacks.
    /// </summary>
    public int agility;

    /// <summary>
    /// The character's luck stat. This increases their chance of landing a critical hit.
    /// </summary>
    public int luck;

    /// <summary>
    /// The character's physical defense stat. This reduces the damage taken from an opponent's physical attack.
    /// </summary>
    public int physicalDefense;

    /// <summary>
    /// The character's magic defense stat. This reduces the damage taken from an opponent's magic attack.
    /// </summary>
    public int magicDefense;

    /// <summary>
    /// Contains a list of the character's abilities that consume SP. They include both special physical attacks and magic spells.
    /// </summary>
    public List<AbilityObject> abilities;
}
