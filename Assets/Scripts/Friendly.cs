using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : Unit
{
    /// <summary>
    /// The friendly's maximum limit gauge points.
    /// </summary>
    public int maxLimit;

    /// <summary>
    /// The friendly's current limit gauge points.
    /// </summary>
    public int currentLimit;

    /// <summary>
    /// The experience points needed to level the friendly up.
    /// </summary>
    public int expToNextLevel;

    /// <summary>
    /// The friendly's current experience points.
    /// </summary>
    public int currentExp;

    private void Start()
    {
       SetData();
    }

    /// <summary>
    /// Sets the unit's current stats based on the data in the DataManager.
    /// </summary>
    private void SetData()
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
            maxLimit = stats["maxLimit"];
            currentLimit = stats["currentLimit"];
            expToNextLevel = stats["expToNextLevel"];
            currentExp = stats["currentExp"];
        }
        else
        {
            Debug.Log("This unit does not exist in the dictionary for stats!");
        }

        if (DataManager.instance.startingSpells.TryGetValue(unitId, out var spellObjects))
        {
            if (spellObjects.Count > 0)
            {
                spells = spellObjects;
            }
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
            { "maxLimit", maxLimit },
            { "currentLimit", currentLimit },
            { "expToNextLevel", expToNextLevel },
            { "currentExp", currentExp },
        };

        if (spells.Count > 0)
        {
            var spellObjects = spells;
            DataManager.instance.startingSpells[unitId] = spellObjects;
        }
    
        DataManager.instance.startingStats[unitId] = stats;
    }
}
