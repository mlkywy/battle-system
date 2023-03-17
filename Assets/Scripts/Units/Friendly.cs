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

        level = stats[nameof(level)];
        maxHp = stats[nameof(maxHp)];
        currentHp = stats[nameof(currentHp)];
        maxSp = stats[nameof(maxSp)];
        currentSp = stats[nameof(currentSp)];
        maxMp = stats[nameof(maxMp)];
        currentMp = stats[nameof(currentMp)];
        physicalAttackPower = stats[nameof(physicalAttackPower)];
        magicAttackPower = stats[nameof(magicAttackPower)];
        strength = stats[nameof(strength)];
        intelligence = stats[nameof(intelligence)];
        agility = stats[nameof(agility)];
        luck = stats[nameof(luck)];
        physicalDefense = stats[nameof(physicalDefense)];
        magicDefense = stats[nameof(magicDefense)];
        maxPower = stats[nameof(maxPower)];
        currentPower = stats[nameof(currentPower)];
        expToNextLevel = stats[nameof(expToNextLevel)];
        currentExp = stats[nameof(currentExp)];

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
            { nameof(level), level }, 
            { nameof(maxHp), maxHp },
            { nameof(currentHp), currentHp },
            { nameof(maxSp), maxSp },
            { nameof(currentSp), currentSp },
            { nameof(maxMp), maxMp },
            { nameof(currentMp), currentMp },
            { nameof(physicalAttackPower), physicalAttackPower },
            { nameof(magicAttackPower), magicAttackPower },
            { nameof(strength), strength }, 
            { nameof(intelligence), intelligence }, 
            { nameof(agility), agility }, 
            { nameof(luck), luck },
            { nameof(physicalDefense), physicalDefense },
            { nameof(magicDefense), magicDefense },
            { nameof(maxPower), maxPower },
            { nameof(currentPower), currentPower },
            { nameof(expToNextLevel), expToNextLevel },
            { nameof(currentExp), currentExp },
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
