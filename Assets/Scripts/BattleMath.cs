using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMath 
{
    /// <summary>
    /// Calculates the physical damage output of a basic attack based on the current attacker's stats and the current opponent's stats.
    /// </summary>
    public int CalculateBasicAttackDamage(Unit attacker, Unit opponent)
    {  
        double damage = 0;
        double baseDamage = attacker.physicalAttackPower + attacker.strength;

        float randDodge = UnityEngine.Random.value;
        float randCrit = UnityEngine.Random.value;
        float randVariance = UnityEngine.Random.value;

        float criticalHitChance = (float) attacker.luck / 100;
        float criticalHitMultiplier = 1.5f;
        float opponentDodgeChance = (float) opponent.agility / 100;

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

        damage -= opponent.physicalDefense / 100 * damage; // Apply damage reduction based on opponent's defense stat
        
        return Convert.ToInt32(damage);
    }

    /// <summary>
    /// Calculates the magical damage output of a spell based on the current attacker's stats and the current opponent's stats.
    /// </summary>
    public int CalculateSpellDamage(Unit attacker, Unit opponent, SpellObject spell)
    {  
        return 0;
    }
}