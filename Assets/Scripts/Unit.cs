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
    public int attackPower;

    /// <summary>
    /// Contains a list of the unit's abilities (special attacks and spells)
    /// </summary>
    public List<AbilityObject> abilities;

    private void Start()
    {
        if (DataManager.Instance.unitStats.TryGetValue(unitName, out var stats))
        {
            maxHp = stats["maxHp"];
            currentHp = stats["currentHp"];
            maxSp = stats["maxSp"];
            currentSp = stats["currentSp"];
            attackPower = stats["attackPower"];

            print($"stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}, {attackPower}");
        }
        else
        {
            print("This unit does not exist in the dictionary!");
        }
    }

    /// <summary>
    /// This method saves the unit's current stats to the DataManager class before scene-switching.
    /// </summary>
    private void SaveData()
    {
        var stats = new Dictionary<string, int>
        {
            { "maxHp", maxHp },
            { "currentHp", currentHp },
            { "maxSp", maxSp },
            { "currentSp", currentSp },
            { "attackPower", attackPower }
        };

        DataManager.Instance.unitStats[unitName] = stats;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentHp = currentHp - 10;
            print($"10 DAMAGE TAKEN! stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}, {attackPower}");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            currentHp = currentHp + 10;
            print($"10 HEALTH HEALED! stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}, {attackPower}");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            maxHp = maxHp + 50;
            print($"LEVEL UP, MAX HEALTH INCREASED! stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}, {attackPower}");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SaveData();
            SceneManager.LoadScene("Scene2");
            print($"SWITCHED TO SCENE2! stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}, {attackPower}");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SaveData();
            SceneManager.LoadScene("Scene1");
            print($"SWITCHED TO SCENE1! stats: {unitName}, {currentHp}/{maxHp}, {currentSp}/{maxSp}, {attackPower}");
        }
    }
}
