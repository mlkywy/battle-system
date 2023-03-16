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

    Dictionary<int, int> defenseBoostDict = new Dictionary<int, int>();

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

        if (Input.GetKeyDown(KeyCode.D))
        {
            Defend();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetDefense();
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

        int healing = BattleMath.CalculateSpellHealing(friendly1, friendly1, friendly1.spells[1]);

        if (healing > friendly1.maxHp - friendly1.currentHp)
        {
            friendly1.currentHp = friendly1.maxHp;
            Debug.Log($"Health fully restored!");
        }
        else
        {
            friendly1.currentHp += healing;
            Debug.Log($"Healed party member by {healing}!");
        }
    }

    void Defend()
    {
        Friendly friendly1 = friendlyUnits[0];

        if (!defenseBoostDict.ContainsKey(friendly1.unitId))
        {
            int defenseBoost = BattleMath.CalculateDefenseAmount(friendly1);
            friendly1.physicalDefense += defenseBoost;
            friendly1.magicDefense += defenseBoost;

            defenseBoostDict.Add(friendly1.unitId, defenseBoost);
        
            Debug.Log($"Phys and magic defense increased by {defenseBoost}!");
        }

        Debug.Log($"Defense is already increased!");
    }

    void ResetDefense()
    {
        Friendly friendly1 = friendlyUnits[0];

        if (defenseBoostDict.TryGetValue(friendly1.unitId, out var defenseBoost))
        {
            friendly1.physicalDefense -= defenseBoost;
            friendly1.magicDefense -= defenseBoost;
            defenseBoostDict.Remove(friendly1.unitId);

            Debug.Log($"Defense stats reset!");
        }

        Debug.Log($"Nothing to reset!");
    }

    void Attack()
    {
        if (CheckLists())
        {
            Friendly friendly1 = friendlyUnits[currentFriendlyIndex];
            Enemy enemy1 = enemyUnits[currentEnemyIndex];
            Debug.Log("Exp given: " + enemy1.expGiven);

            int damage = BattleMath.CalculateBasicAttackDamage(friendly1, enemy1);
            // int damage = BattleMath.CalculateSpellDamage(friendly1, enemy1, friendly1.spells[0]);

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

            if (friendly1.currentHp > 0)
            {
                friendly1.currentHp -= damage;

                int powerGaugeIncrease = BattleMath.CalculatePowerGaugeAmount(friendly1, damage);
                friendly1.currentPower += powerGaugeIncrease;

                Debug.Log($"{damage} DAMAGE TAKEN BY ENEMY!");
            }
            else
            {
                Debug.Log("This character is dead!");
                return;
            }
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
