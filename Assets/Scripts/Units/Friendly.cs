using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Friendly : Unit
{
    /// <summary>
    /// The friendly's maximum power gauge points.
    /// </summary>
    public int maxPower;

    /// <summary>
    /// The friendly's current power gauge points.
    /// </summary>
    public int currentPower;

    /// <summary>
    /// The experience points needed to level the friendly up.
    /// </summary>
    public int expToNextLevel;

    /// <summary>
    /// The friendly's current experience points.
    /// </summary>
    public int currentExp;

    /// <summary>
    /// Contains a list of the unit's special abilities that can be triggered with a full power gauge. Must contain at least one special abliity.
    /// </summary>
    public List<SpecialObject> specials;

    private void Start()
    {
        LoadData();
    }

    /// <summary>
    /// Sets the unit's current stats based on the data in the DataManager.
    /// </summary>
    private void LoadData()
    {
        if (DataManager.instance.startingStats.TryGetValue(unitId, out var stats))
        {
            level = stats["level"];
            maxHp = stats["maxHp"];
            currentHp = stats["currentHp"];
            maxSp = stats["maxSp"];
            currentSp = stats["currentSp"];
            maxMp = stats["maxMp"];
            currentMp = stats["currentMp"];
            physicalAttackPower = stats["physicalAttackPower"];
            magicAttackPower = stats["magicAttackPower"];
            strength = stats["strength"];
            intelligence = stats["intelligence"];
            agility = stats["agility"];
            luck = stats["luck"];
            physicalDefense = stats["physicalDefense"];
            magicDefense = stats["magicDefense"];
            maxPower = stats["maxPower"];
            currentPower = stats["currentPower"];
            expToNextLevel = stats["expToNextLevel"];
            currentExp = stats["currentExp"];
        }
        else
        {
            Debug.Log("This unit does not exist in the dictionary for stats!");
        }

        if (DataManager.instance.spells.TryGetValue(unitId, out var spellList) && spellList.Count > 0)
        {
            spells = spellList;
        }
        else 
        {
            DataManager.instance.spells[unitId] = spells;
        }

        if (DataManager.instance.skills.TryGetValue(unitId, out var skillList) && skillList.Count > 0)
        {
            skills = skillList;
        }
        else 
        {
            DataManager.instance.skills[unitId] = skills;
        }

        if (DataManager.instance.specials.TryGetValue(unitId, out var specialList) && specialList.Count > 0)
        {
            specials = specialList;
        }
        else 
        {
            DataManager.instance.specials[unitId] = specials;
        }
    }


    /// <summary>
    /// Saves unit's current stats to the DataManager class while saving the game and before scene-switching.
    /// </summary>
    public void SaveData()
    {
        var stats = new Dictionary<string, int>
        {
            { "level", level }, 
            { "maxHp", maxHp },
            { "currentHp", currentHp },
            { "maxSp", maxSp },
            { "currentSp", currentSp },
            { "maxMp", maxMp },
            { "currentMp", currentMp },
            { "physicalAttackPower", physicalAttackPower },
            { "magicAttackPower", magicAttackPower },
            { "strength", strength }, 
            { "intelligence", intelligence }, 
            { "agility", agility }, 
            { "luck", luck },
            { "physicalDefense", physicalDefense },
            { "magicDefense", magicDefense },
            { "maxPower", maxPower },
            { "currentPower", currentPower },
            { "expToNextLevel", expToNextLevel },
            { "currentExp", currentExp },
        };
    
        DataManager.instance.startingStats[unitId] = stats;

        DataManager.instance.spells[unitId] = spells;
        DataManager.instance.skills[unitId] = skills;
        DataManager.instance.specials[unitId] = specials;
    }
}
