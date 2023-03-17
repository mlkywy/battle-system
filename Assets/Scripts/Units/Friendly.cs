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
        if (!DataManager.instance.startingStats.TryGetValue(unitId, out var stats))
        {
            Debug.Log("This unit does not exist in the dictionary for stats!");
        }

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

        spells = LoadList(DataManager.instance.spells, spells, unitId);
        skills = LoadList(DataManager.instance.skills, skills, unitId);
        specials = LoadList(DataManager.instance.specials, specials, unitId);
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
    
    /// <summary>
    /// Helper method that returns the list parameter if it exists and has at least one item. Otherwise, it is added to the dictionary and returned. 
    /// </summary>
    private List<T> LoadList<T>(Dictionary<int, List<T>> dict, List<T> list, int unitId)
    {
        if (dict.TryGetValue(unitId, out var listType) && listType.Count > 0)
        {
            return listType;
        }
        else 
        {
            dict[unitId] = list;
            return list;
        }
    }
}
