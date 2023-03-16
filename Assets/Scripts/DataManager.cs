using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    /// <summary>
    /// Contains the base stats of each of unit and keeps tracks of their changes.
    /// </summary>
    public Dictionary<int, Dictionary<string, int>> startingStats = new Dictionary<int, Dictionary<string, int>>
    {
        { 0, new Dictionary<string, int> 
            { 
                { "level", 30 }, 
                { "maxHp", 2000 }, 
                { "currentHp", 2000 }, 
                { "maxSp", 340 }, 
                { "currentSp", 340 }, 
                { "maxMp", 190 }, 
                { "currentMp", 190 }, 
                { "physicalAttackPower", 150 },
                { "magicAttackPower", 150 },
                { "strength", 200 }, 
                { "intelligence", 90 }, 
                { "agility", 50 }, 
                { "luck", 10 },
                { "physicalDefense", 45 },
                { "magicDefense", 10 },
                { "maxPower", 10000 },
                { "currentPower", 0 },
                { "expToNextLevel", 100 },
                { "currentExp", 0 },
            } 
        },
        { 1, new Dictionary<string, int> 
            { 
                { "level", 30 }, 
                { "maxHp", 1700 }, 
                { "currentHp", 1700 }, 
                { "maxSp", 200 }, 
                { "currentSp", 200 }, 
                { "maxMp", 430 }, 
                { "currentMp", 430 }, 
                { "physicalAttackPower", 60 },
                { "magicAttackPower", 150 },
                { "strength", 80 }, 
                { "intelligence", 200 }, 
                { "agility", 100 }, 
                { "luck", 20 },
                { "physicalDefense", 25 },
                { "magicDefense", 35 },
                { "maxPower", 10000 },
                { "currentPower", 0 },
                { "expToNextLevel", 100 },
                { "currentExp", 0 },
            } 
        }
    };

    /// <summary>
    /// Contains the abilities of each unit and keeps track of changes such as adding/removing spells.
    /// </summary>
    public Dictionary<int, List<SpellObject>> startingSpells = new Dictionary<int, List<SpellObject>>
    {
        { 0, new List<SpellObject>() },
        { 1, new List<SpellObject>() }
    };

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
