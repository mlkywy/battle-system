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
                { "level", 2 }, 
                { "maxHp", 200 }, 
                { "currentHp", 200 }, 
                { "maxSp", 140 }, 
                { "currentSp", 140 }, 
                { "maxMp", 90 }, 
                { "currentMp", 90 }, 
                { "physicalAttackPower", 150 },
                { "magicAttackPower", 150 },
                { "strength", 200 }, 
                { "intelligence", 90 }, 
                { "agility", 50 }, 
                { "luck", 10 },
                { "physicalDefense", 45 },
                { "magicDefense", 10 },
                { "maxLimit", 1000 },
                { "currentLimit", 0 },
                { "expToNextLevel", 100 },
                { "currentExp", 0 },
            } 
        },
        { 1, new Dictionary<string, int> 
            { 
                { "level", 2 }, 
                { "maxHp", 170 }, 
                { "currentHp", 170 }, 
                { "maxSp", 100 }, 
                { "currentSp", 100 }, 
                { "maxMp", 230 }, 
                { "currentMp", 230 }, 
                { "physicalAttackPower", 60 },
                { "magicAttackPower", 150 },
                { "strength", 80 }, 
                { "intelligence", 200 }, 
                { "agility", 100 }, 
                { "luck", 20 },
                { "physicalDefense", 25 },
                { "magicDefense", 35 },
                { "maxLimit", 1000 },
                { "currentLimit", 0 },
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
