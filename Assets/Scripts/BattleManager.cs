using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public List<Friendly> friendlies;
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
        if (friendlies.Count == 0 || friendlies == null)
        {
            Debug.Log("Missing friendly units!");
            return false;
        }

        if (enemies.Count == 0 || enemies == null)
        {
            Debug.Log("Missing enemy units!");
            return false;
        }

        return true;
    }

    void TestAttack()
    {
        if (TestCheckLists())
        {
            Unit friendly1 = friendlies[0];
            Enemy enemy1 = enemies[0];

            battleMath = new BattleMath(friendly1, enemy1);
            int damage = battleMath.CalculatePhysicalAttackDamage();
            enemy1.currentHp = enemy1.currentHp - damage;

            Debug.Log($"{damage} DAMAGE DEALT TO ENEMY!");
        }
    }

    void TestDamageTaken()
    {
        if (TestCheckLists())
        {
            Unit friendly1 = friendlies[0];
            Enemy enemy1 = enemies[0];

            battleMath = new BattleMath(enemy1, friendly1);
            int damage = battleMath.CalculatePhysicalAttackDamage();
            friendly1.currentHp = friendly1.currentHp - damage;

            Debug.Log($"{damage} DAMAGE TAKEN BY ENEMY!");
        }
    }

    void TestSwitchingScenes()
    {
        if (friendlies.Count == 0 || friendlies == null)
        {
            Debug.Log("Missing friendly units!");
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (Friendly friendly in friendlies)
            {
                friendly.SaveData();
            }

            SceneManager.LoadScene("Scene2");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (Friendly friendly in friendlies)
            {
                friendly.SaveData();
            }

            SceneManager.LoadScene("Scene1");
        }
    }
}
