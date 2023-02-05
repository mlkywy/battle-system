using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManagerTest : MonoBehaviour
{
    protected List<Unit> allUnits => FindObjectsOfType<Unit>().ToList();
    
    public List<Friendly> friendlyUnits => allUnits.GetUnitByType(UnitType.Friendly).Cast<Friendly>().ToList();
    public List<Enemy> enemyUnits => allUnits.GetUnitByType(UnitType.Enemy).Cast<Enemy>().ToList();

    int currentFriendlyIndex = 0;
    int currentEnemyIndex = 0;

    void Start()
    {
        
    }

    void Update()
    {
        SwitchingScenes();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            DamageTaken();
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Heal();
        }
    }

    bool CheckLists() 
    {
        if (friendlyUnits.Count == 0 || friendlyUnits == null)
        {
            Debug.Log("Missing friendly units!");
            return false;
        }

        if (enemyUnits.Count == 0 || enemyUnits == null)
        {
            Debug.Log("Missing enemy units!");
            return false;
        }

        return true;
    }

    void Heal()
    {
        Friendly friendly1 = friendlyUnits[0];
        Friendly friendly2 = friendlyUnits[1];

        int healing = BattleMath.CalculateSpellHealing(friendly1, friendly2, friendly1.spells[1]);
        friendly2.currentHp += healing;

        Debug.Log($"Healed party member by {healing}!");
    }

    void Attack()
    {
        if (CheckLists())
        {
            Friendly friendly1 = friendlyUnits[currentFriendlyIndex];
            Enemy enemy1 = enemyUnits[currentEnemyIndex];
            Debug.Log("Exp given: " + enemy1.expGiven);

            // int damage = BattleMath.CalculateBasicAttackDamage(friendly1, enemy1);
            int damage = BattleMath.CalculateSpellDamage(friendly1, enemy1, friendly1.spells[0]);

            if (enemy1.currentHp > 0)
            {
                enemy1.currentHp -= damage;
            }
            else
            {
                Debug.Log("This enemy is dead!");
                return;
            }

            if (damage >= 0)
            {
                Debug.Log($"{damage} DAMAGE DEALT TO ENEMY!");
            }
            else
            {
                Debug.Log($"{damage} ENEMY HEALTH HEALED!");
            }

            if (enemy1.currentHp <= 0)
            {
                enemy1.isDead = true;
                Debug.Log("You win!");
                BattleMath.EarnExperience(friendlyUnits, enemyUnits);
            }
        }
    }

    void DamageTaken()
    {
        if (CheckLists())
        {
            Friendly friendly1 = friendlyUnits[currentFriendlyIndex];
            Enemy enemy1 = enemyUnits[currentEnemyIndex];

            int damage = BattleMath.CalculateBasicAttackDamage(enemy1, friendly1);
            friendly1.currentHp -= damage;

            Debug.Log($"{damage} DAMAGE TAKEN BY ENEMY!");
        }
    }

    void SwitchingScenes()
    {
        if (friendlyUnits.Count == 0 || friendlyUnits == null)
        {
            Debug.Log("Missing friendly units!");
            return;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            foreach (Friendly friendly in friendlyUnits)
            {
                friendly.SaveData();
            }

            SceneManager.LoadScene("Scene2");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            foreach (Friendly friendly in friendlyUnits)
            {
                friendly.SaveData();
            }

            SceneManager.LoadScene("Scene1");
        }
    }
}
