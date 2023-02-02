using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public List<SpellObject> spells;

    /// <summary>
    /// Contains the base stats of each of unit and keeps tracks of their changes.
    /// </summary>
    public Dictionary<string, Dictionary<string, int>> startingStats = new Dictionary<string, Dictionary<string, int>>
    {
        { "Friendly1", new Dictionary<string, int> 
            { 
                { "unitState", 0 }, 
                { "isDead", 0 },
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
                { "magicDefense", 10 }
            } 
        },
        { "Friendly2", new Dictionary<string, int> 
            { 
                { "unitState", 0 }, 
                { "isDead", 0 },
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
                { "magicDefense", 35 }
            } 
        }
    };

    /// <summary>
    /// Contains the abilities of each unit and keeps track of changes such as adding/removing spells.
    /// </summary>
    public Dictionary<string, List<SpellObject>> startingSpells = new Dictionary<string, List<SpellObject>>
    {
        { "Friendly1", new List<SpellObject>() },
        { "Friendly2", new List<SpellObject>() }
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
