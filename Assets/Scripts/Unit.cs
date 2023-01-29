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

    // Start is called before the first frame update
    void Start()
    {
        unitName = DataManager.Instance.unitName;
        maxHp = DataManager.Instance.maxHp;
        currentHp = DataManager.Instance.currentHp;

        print($"unit: {unitName}, maxHp: {maxHp}, curHp: {currentHp}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentHp = currentHp - 10;
            print($"10 DAMAGE TAKEN! unit: {unitName}, maxHp: {maxHp}, curHp: {currentHp}");
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            currentHp = currentHp + 10;
            print($"10 HEALTH HEALED! unit: {unitName}, maxHp: {maxHp}, curHp: {currentHp}");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            maxHp = maxHp + 50;
            print($"LEVEL UP, MAX HEALTH INCREASED! unit: {unitName}, maxHp: {maxHp}, curHp: {currentHp}");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DataManager.Instance.maxHp = maxHp;
            DataManager.Instance.currentHp = currentHp;
            SceneManager.LoadScene("Scene2");
            print($"SWITCHED TO SCENE2! unit: {unitName}, maxHp: {maxHp}, curHp: {currentHp}");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DataManager.Instance.maxHp = maxHp;
            DataManager.Instance.currentHp = currentHp;
            SceneManager.LoadScene("Scene1");
            print($"SWITCHED TO SCENE1! unit: {unitName}, maxHp: {maxHp}, curHp: {currentHp}");
        }
    }
}
