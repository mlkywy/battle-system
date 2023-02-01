using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int maxHp;
    public int currentHp;
    public int maxSp;
    public int currentSp;

    public int level;
    public int attackPower;
    public int strength;
    public int intelligence;
    public int agility;
    public int luck;
    public int defense;

    /// <summary>
    /// Contains a list of the unit's abilities (special attacks and spells)
    /// </summary>
    public List<AbilityObject> abilities;

    private void Start()
    {
       SetData();
    }

    /// <summary>
    /// Saves unit's current stats to the DataManager class before scene-switching.
    /// </summary>
    private void SetData()
    {
        if (DataManager.instance.unitStats.TryGetValue(unitName, out var stats))
        {
            maxHp = stats["maxHp"];
            currentHp = stats["currentHp"];
            maxSp = stats["maxSp"];
            currentSp = stats["currentSp"];

            level = stats["level"];
            attackPower = stats["attackPower"];
            strength = stats["strength"];
            intelligence = stats["intelligence"];
            agility = stats["agility"];
            luck = stats["luck"];
            luck = stats["defense"];

            print($"stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}");
        }
        else
        {
            print("This unit does not exist in the dictionary!");
        }
    }

    /// <summary>
    /// Sets the unit's current stats based on the data in the DataManager.
    /// </summary>
    private void SaveData()
    {
        var stats = new Dictionary<string, int>
        {
            { "maxHp", maxHp },
            { "currentHp", currentHp },
            { "maxSp", maxSp },
            { "currentSp", currentSp },
            { "level", level }, 
            { "attackPower", attackPower },
            { "strength", strength }, 
            { "intelligence", intelligence }, 
            { "agility", agility }, 
            { "luck", luck },
            { "defense", defense },
        };

        DataManager.instance.unitStats[unitName] = stats;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SaveData();
            SceneManager.LoadScene("Scene2");
            print($"SWITCHED TO SCENE2! stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SaveData();
            SceneManager.LoadScene("Scene1");
            print($"SWITCHED TO SCENE1! stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}");
        }
    }
}
