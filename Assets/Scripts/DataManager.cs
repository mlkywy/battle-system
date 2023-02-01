using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    /// <summary>
    /// Contains the base stats of each of unit and keeps tracks of their changes.
    /// </summary>
    public Dictionary<string, Dictionary<string, int>> unitStats = new Dictionary<string, Dictionary<string, int>>
    {
        { "Unit1", new Dictionary<string, int> 
            { 
                { "maxHp", 200 }, 
                { "currentHp", 200 }, 
                { "maxSp", 140 }, 
                { "currentSp", 140 }, 
                { "level", 2 }, 
                { "physicalAttackPower", 150 },
                { "magicAttackPower", 150 },
                { "strength", 200 }, 
                { "intelligence", 90 }, 
                { "agility", 50 }, 
                { "luck", 10 },
                { "defense", 45 },
            } 
        },
        { "Unit2", new Dictionary<string, int> 
            { 
                { "maxHp", 170 }, 
                { "currentHp", 170 }, 
                { "maxSp", 230 }, 
                { "currentSp", 230 }, 
                { "level", 2 }, 
                { "physicalAttackPower", 60 },
                { "magicAttackPower", 150 },
                { "strength", 80 }, 
                { "intelligence", 200 }, 
                { "agility", 100 }, 
                { "luck", 20 },
                { "defense", 25 },
            } 
        }
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
