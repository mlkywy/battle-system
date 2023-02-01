using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMath 
{
    string _attackerName;
    string _opponentName;
    int _level;
    int _physicalAttackPower;
    int _magicAttackPower;
    int _strength;
    int _intelligence;
    int _luck;
    int _opponentAgility;
    int _opponentDefense;

    public BattleMath(Character attacker, Character opponent)
    {
        _attackerName = attacker.characterName;
        _opponentName = opponent.characterName;
        _level = attacker.level;
        _physicalAttackPower = attacker.physicalAttackPower;
        _magicAttackPower = attacker.magicAttackPower;
        _strength = attacker.strength;
        _intelligence = attacker.intelligence;
        _luck = attacker.luck;
        _opponentAgility = opponent.agility;
        _opponentDefense = opponent.defense;
    }

    /// <summary>
    /// Calculates the physical damage output based on the current attacker's stats and the current opponent's stats.
    /// </summary>
    public int CalculatePhysicalAttackDamage()
    {  
        Debug.Log($"Current attacker is: {_attackerName}, current opponent is: {_opponentName}!");

        double damage = 0;
        double baseDamage = _physicalAttackPower + _strength;

        float randDodge = UnityEngine.Random.value;
        float randCrit = UnityEngine.Random.value;
        float randVariance = UnityEngine.Random.value;

        float criticalHitChance = (float) _luck / 100;
        float criticalHitMultiplier = 1.5f;
        float opponentDodgeChance = (float) _opponentAgility / 100;

        if (randDodge < opponentDodgeChance) 
        {
            Debug.Log("Attack missed!");
            return Convert.ToInt32(damage); // Attack missed!
        } 

        baseDamage *= (1 + (randVariance - 0.5) * criticalHitChance); // Add random variance to the base damage

        if (randCrit < criticalHitChance) 
        {
            Debug.Log("Critical hit!");
            damage = baseDamage * criticalHitMultiplier; // Critical hit!
        } 
        else 
        {
            damage = baseDamage; // Normal hit!
        }

        damage -= _opponentDefense / 100 * damage; // Apply damage reduction based on opponent's defense stat
        
        return Convert.ToInt32(damage);
    }
}
