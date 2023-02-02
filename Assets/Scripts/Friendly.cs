using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : Unit
{
    private void Start()
    {
       SetData();
    }

    /// <summary>
    /// Sets the unit's current stats based on the data in the DataManager.
    /// </summary>
    private void SetData()
    {
        if (DataManager.instance.startingStats.TryGetValue(unitName, out var stats))
        {
            unitState = stats["unitState"];
            isDead = stats["isDead"];
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
        }
        else
        {
            Debug.Log("This unit does not exist in the dictionary for stats!");
        }

        if (DataManager.instance.startingSpells.TryGetValue(unitName, out var spellObjects))
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
            { "unitState", unitState }, 
            { "isDead", isDead },
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
        };

        if (spells.Count > 0)
        {
            var spellObjects = spells;
            DataManager.instance.startingSpells[unitName] = spellObjects;
        }
    
        DataManager.instance.startingStats[unitName] = stats;
    }
}
