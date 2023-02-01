using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public List<Unit> units;
    public List<Enemy> enemies;

    private BattleMath battleMath;

    void Start()
    {
        
    }

    void Update()
    {
        TestSwitchingScenes();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TestAttack();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TestDamageTaken();
        }
    }

    bool TestCheckLists() 
    {
        if (units.Count == 0 || units == null)
        {
            Debug.Log("Missing units!");
            return false;
        }

        if (enemies.Count == 0 || enemies == null)
        {
            Debug.Log("Missing enemies!");
            return false;
        }

        return true;
    }

    void TestAttack()
    {
        if (TestCheckLists())
        {
            Unit unit1 = units[0];
            Enemy enemy1 = enemies[0];

            battleMath = new BattleMath(unit1, enemy1);
            int damage = battleMath.CalculatePhysicalAttackDamage();
            enemy1.currentHp = enemy1.currentHp - damage;

            Debug.Log($"{damage} DAMAGE DEALT TO ENEMY!");
        }
    }

    void TestDamageTaken()
    {
        if (TestCheckLists())
        {
            Unit unit1 = units[0];
            Enemy enemy1 = enemies[0];

            battleMath = new BattleMath(enemy1, unit1);
            int damage = battleMath.CalculatePhysicalAttackDamage();
            unit1.currentHp = unit1.currentHp - damage;

            Debug.Log($"{damage} DAMAGE TAKEN BY ENEMY!");
        }
    }

    void TestSwitchingScenes()
    {
        if (units.Count == 0 || units == null)
        {
            Debug.Log("Missing units!");
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (Unit unit in units)
            {
                unit.SaveData();
            }

            SceneManager.LoadScene("Scene2");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (Unit unit in units)
            {
                unit.SaveData();
            }

            SceneManager.LoadScene("Scene1");
        }
    }
}
