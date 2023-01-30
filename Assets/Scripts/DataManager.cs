using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public Dictionary<string, Dictionary<string, int>> unitStats = new Dictionary<string, Dictionary<string, int>>
    {
        { "Unit1", new Dictionary<string, int> { { "maxHp", 200 }, { "currentHp", 200 }, { "maxSp", 200 }, { "currentSp", 200 }, { "attackPower", 200 } } },
        { "Unit2", new Dictionary<string, int> { { "maxHp", 100 }, { "currentHp", 100 }, { "maxSp", 100 }, { "currentSp", 100 }, { "attackPower", 100 } } }
    };

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
