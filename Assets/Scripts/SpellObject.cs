using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell", menuName = "ScriptableObjects/Spell", order = 1)]
public class SpellObject : ScriptableObject
{
    /// <summary>
    /// The spell's name.
    /// </summary>
    public string spellName;

    /// <summary>
    /// The spell's type. This includes spell (magic) and special (physical).
    /// </summary>
    public SpellType spellType;

    /// <summary>
    /// The ability's element type. This includes none (no element), ice, fire, lightning, wind, or earth.
    /// </summary>
    public ElementType elementType;

    /// <summary>
    /// The spell's base power. This includes physical damage, magic damage, healing potency, etc.
    /// </summary>
    public int spellPower;

    /// <summary>
    /// The spell's mana point cost, reducing a unit's current MP with each use.
    /// </summary>
    public int mpCost;
}