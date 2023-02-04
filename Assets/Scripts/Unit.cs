using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    /// <summary>
    /// The unit's name.
    /// </summary>
    public string unitName;

    /// <summary>
    /// Determines the unit type. (Friendly, Enemy)
    /// </summary>
    public UnitType unitType;

    /// <summary>
    /// Determines whether the unit is dead or alive.
    /// </summary>
    public bool isDead;

    /// <summary>
    /// The unit's current level.
    /// </summary>
    public int level;

    /// <summary>
    /// The unit's maximum health points.
    /// </summary>
    public int maxHp;

    /// <summary>
    /// The unit's current health points.
    /// </summary>
    public int currentHp;

    /// <summary>
    /// The unit's maximum skill points.
    /// </summary>
    public int maxSp;

    /// <summary>
    /// The unit's current skill points.
    /// </summary>
    public int currentSp;

    /// <summary>
    /// The unit's maximum mana points.
    /// </summary>
    public int maxMp;

    /// <summary>
    /// The unit's current mana points.
    /// </summary>
    public int currentMp;

    /// <summary>
    /// The unit's base physical attack power.
    /// </summary>
    public int physicalAttackPower;

    /// <summary>
    /// The unit's base magic attack power.
    /// </summary>
    public int magicAttackPower;

    /// <summary>
    /// The unit's strength stat. This affects their physical attack damage output.
    /// </summary>
    public int strength;

    /// <summary>
    /// The unit's intelligence stat. This affects the output of both offensive and healing spells.
    /// </summary>
    public int intelligence;

    /// <summary>
    /// The unit's agility stat. This affects their chance of dodging an opponent's attacks.
    /// </summary>
    public int agility;

    /// <summary>
    /// The unit's luck stat. This increases their chance of landing a critical hit.
    /// </summary>
    public int luck;

    /// <summary>
    /// The unit's physical defense stat. This reduces the damage taken from an opponent's physical attack.
    /// </summary>
    public int physicalDefense;

    /// <summary>
    /// The unit's magic defense stat. This reduces the damage taken from an opponent's magic attack.
    /// </summary>
    public int magicDefense;

    /// <summary>
    /// Contains a list of the unit's abilities that consume MP. They include both special physical attacks and magic spells. Must contain at least one spell.
    /// </summary>
    public List<SpellObject> spells;
}
