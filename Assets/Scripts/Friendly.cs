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
    /// Saves unit's current stats to the DataManager class before scene-switching.
    /// </summary>
    private void SetData()
    {
        if (DataManager.instance.friendlyStats.TryGetValue(unitName, out var stats))
        {
            unitState = stats["unitState"];
            isDead = stats["isDead"];
            maxHp = stats["maxHp"];
            currentHp = stats["currentHp"];
            maxSp = stats["maxSp"];
            currentSp = stats["currentSp"];
            level = stats["level"];
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
            Debug.Log("This unit does not exist in the dictionary!");
        }
    }

    /// <summary>
    /// Sets the unit's current stats based on the data in the DataManager.
    /// </summary>
    public void SaveData()
    {
        var stats = new Dictionary<string, int>
        {
            { "unitState", unitState }, 
            { "isDead", isDead },
            { "maxHp", maxHp },
            { "currentHp", currentHp },
            { "maxSp", maxSp },
            { "currentSp", currentSp },
            { "level", level }, 
            { "physicalAttackPower", physicalAttackPower },
            { "magicAttackPower", magicAttackPower },
            { "strength", strength }, 
            { "intelligence", intelligence }, 
            { "agility", agility }, 
            { "luck", luck },
            { "physicalDefense", physicalDefense },
            { "magicDefense", magicDefense },
        };

        DataManager.instance.friendlyStats[unitName] = stats;
    }
}