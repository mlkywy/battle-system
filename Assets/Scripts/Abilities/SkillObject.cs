using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObjects/Skill", order = 2)]
public class SkillObject : ScriptableObject
{
    /// <summary>
    /// The skill's name.
    /// </summary>
    public string skillName;

    /// <summary>
    /// The skill's base power. 
    /// </summary>
    public int skillPower;

    /// <summary>
    /// The skill's skill point cost, reducing a unit's current SP with each use.
    /// </summary>
    public int spCost;
}