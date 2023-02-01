using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMath 
{
    string _attackerName;
    string _opponentName;
    int _level;
    int _attackPower;
    int _strength;
    int _luck;
    int _opponentAgility;
    int _opponentDefense;

    public BattleMath(Unit unit, Enemy enemy)
    {
        _attackerName = unit.unitName;
        _opponentName = enemy.enemyName;
        _level = unit.level;
        _attackPower = unit.attackPower;
        _strength = unit.strength;
        _luck = unit.luck;
        _opponentAgility = enemy.agility;
        _opponentDefense = enemy.defense;
    }

    public BattleMath(Enemy enemy, Unit unit)
    {
        _attackerName = enemy.enemyName;
        _opponentName = unit.unitName;
        _level = enemy.level;
        _attackPower = enemy.attackPower;
        _strength = enemy.strength;
        _luck = enemy.luck;
        _opponentAgility = unit.agility;
        _opponentDefense = unit.defense;
    }

    /// <summary>
    /// Calculates the physical damage output based on the current character's stats and the current opponent's stats.
    /// </summary>
    public int CalculatePhysicalAttackDamage()
    {  
        Debug.Log($"Current attacker is: {_attackerName}, current opponent is: {_opponentName}!");

        double damage = 0;
        float randDodge = UnityEngine.Random.value;
        float randCrit = UnityEngine.Random.value;
        float randVariance = UnityEngine.Random.value;

        float criticalHitChance = (float) _luck / 100;
        float criticalHitMultiplier = 1.5f;
        float baseDamage = _attackPower + _strength;
        float opponentDodgeChance = (float) _opponentAgility / 100;

        if (randDodge < opponentDodgeChance) 
        {
            // Attack misses!
            Debug.Log("ATTACK MISSED!");  
            return Convert.ToInt32(damage);  
        } 

        // Add random variance to the base damage
        baseDamage *= (float) (1 + (randVariance - 0.5) * criticalHitChance);
        Debug.Log($"Base damage: {1 + (randVariance - 0.5) * criticalHitChance}");

        if (randCrit < criticalHitChance) 
        {
            // Critical hit!
            damage = baseDamage * criticalHitMultiplier;
            Debug.Log("CRITICAL HIT!");  
        } 
        else 
        {
            // Normal hit!
            damage = baseDamage;
            Debug.Log("NORMAL HIT!");    
        }

        // Apply damage reduction based on opponent's defense stat
        damage -= _opponentDefense / 100 * damage;
        
        return Convert.ToInt32(damage);
    }
}
