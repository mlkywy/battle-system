using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BattleMath 
{
    /// <summary>
    /// Returns a list of units based on the unit type.
    /// </summary>
    public static List<Unit> GetUnitByType(this List<Unit> units, UnitType type)
    {
        return units.Where(unit => unit.unitType == type).ToList();
    }

    /// <summary>
    /// Calculates the physical damage output of a basic attack based on the current attacker's stats and the current opponent's stats.
    /// </summary>
    public static int CalculateBasicAttackDamage(Unit attacker, Unit opponent)
    {  
        float damage = 0;
        float baseDamage = attacker.physicalAttackPower + attacker.strength;

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

        baseDamage *= (float) (1 + (randVariance - 0.5) * criticalHitChance); // Add random variance to the base damage

        if (randCrit < criticalHitChance) 
        {
            Debug.Log("Critical hit!");

            damage = baseDamage * criticalHitMultiplier; // Critical hit!
        } 
        else 
        {
            damage = baseDamage; // Normal hit!
        }

        damage -= (float) opponent.physicalDefense / 100 * damage; // Apply damage reduction based on opponent's physical defense stat
        
        return Convert.ToInt32(damage);
    }

    /// <summary>
    /// Calculates the magical damage output of a spell based on the current attacker's stats and the current opponent's stats.
    /// </summary>
    public static int CalculateSpellDamage(Unit attacker, Unit opponent, SpellObject spell)
    {  
        float damage = 0;
        float baseDamage = attacker.magicAttackPower + attacker.intelligence + spell.spellPower;

        float randDodge = UnityEngine.Random.value;
        float randBoost = UnityEngine.Random.value;
        float randVariance = UnityEngine.Random.value;

        float magicBoostChance = attacker.luck / 100f;
        float magicBoostMultiplier = 1.5f;
        float opponentDodgeChance = opponent.agility / 100f;

        if (randDodge < opponentDodgeChance) 
        {
            Debug.Log("Spell missed!");

            return (int) damage; // Spell missed!
        } 

        baseDamage *= (float) (1 + (randVariance - 0.5) * magicBoostChance); // Add random variance to the base damage

        if (opponent is Enemy enemy)
        {
            if (enemy.immunities.Contains(spell.elementType))
            {
                Debug.Log($"Opponent is immune to {spell.elementType}!");

                damage = Math.Abs(baseDamage) * -1;
                return (int) damage; // Spell healed the opponent!
            }

            if (enemy.weaknesses.Contains(spell.elementType))
            {
                Debug.Log($"Opponent is weak to {spell.elementType}!");

                damage = baseDamage * magicBoostMultiplier;
                int reducedDefense = opponent.magicDefense / 2; // Reduce opponent's magic defense stat by half
                damage -= (float) reducedDefense / 100 * damage; // Apply damage reduction based on opponent's reduced defense stat
                return (int) damage; 
            }
        }

        damage = baseDamage;
        damage -= (float) opponent.magicDefense / 100 * damage; // Apply damage reduction based on opponent's magic defense stat

        return (int) damage;
    }

    /// <summary>
    /// Awards experience to friendly units and levels them up as neccessary.
    /// </summary>
    public static void EarnExperience(List<Friendly> friendlyUnits, List<Enemy> enemyUnits)
    {
        int totalExp = enemyUnits.Sum(e => e.expGiven);

        foreach (Friendly friendly in friendlyUnits)
        {
            while (friendly.currentExp + totalExp >= friendly.expToNextLevel)
            {
                friendly.currentExp -= friendly.expToNextLevel;
                friendly.level++;
                LevelUp(friendly);
            }

            friendly.currentExp += totalExp;
        }
    }

    /// <summary>
    /// Levels up an individual friendly unit.
    /// </summary>
    private static void LevelUp(Friendly friendly)
    {
        float level = friendly.level;

        friendly.maxHp += (int) (StatsPerLevel.hpPerLevel + level / 5f);
        friendly.currentHp = friendly.maxHp;

        friendly.maxSp += (int) (StatsPerLevel.spPerLevel + level / 5f);
        friendly.currentMp = friendly.maxMp;

        friendly.maxMp += (int) (StatsPerLevel.mpPerLevel + level / 5f);
        friendly.currentSp = friendly.maxSp;

        friendly.strength += (int) (StatsPerLevel.strengthPerLevel + level / 5f);
        friendly.intelligence += (int) (StatsPerLevel.intPerLevel + level / 10f);
        friendly.agility += (int) (StatsPerLevel.agilityPerLevel + level / 10f);
        friendly.luck += (int) (StatsPerLevel.luckPerLevel + level / 20f);
        friendly.physicalAttackPower += (int)( StatsPerLevel.physAttackPowerPerLevel + level / 10f);
        friendly.physicalDefense += (int) (StatsPerLevel.physDefensePerLevel + level / 10f);
        friendly.magicAttackPower += (int) (StatsPerLevel.magicAttackPowerPerLevel + level / 10f);
        friendly.magicDefense += (int) (StatsPerLevel.magicDefensePerLevel + level / 10f);

        friendly.expToNextLevel *= (int) StatsPerLevel.experienceMultiplier;
    }

    public static void LevelUpParty(List<Friendly> friendlyUnits, List<Enemy> enemyUnits)
    {
        int totalExp = 0;
        foreach (Enemy enemy in enemyUnits)
        {
            totalExp += enemy.expGiven;
        }

        foreach (Friendly friendly in friendlyUnits)
        {
            while (friendly.currentExp + totalExp >= friendly.expToNextLevel)
            {
                float level = friendly.level;
                float expToNextLevel = friendly.expToNextLevel;

                friendly.currentExp -= friendly.expToNextLevel;
                friendly.level++;

                friendly.maxHp += (int) (StatsPerLevel.hpPerLevel + (level / 5f));
                friendly.currentHp = friendly.maxHp;

                friendly.maxSp += (int) (StatsPerLevel.spPerLevel + (level / 5f));
                friendly.currentMp = friendly.maxMp;

                friendly.maxMp += (int) (StatsPerLevel.mpPerLevel + (level / 5f));
                friendly.currentSp = friendly.maxSp;

                friendly.strength += (int) (StatsPerLevel.strengthPerLevel + (level / 10f));
                friendly.intelligence += (int) (StatsPerLevel.intPerLevel + (level / 10f));
                friendly.agility += (int) (StatsPerLevel.agilityPerLevel + (level / 10f));

                friendly.luck += (int) (StatsPerLevel.luckPerLevel + (level / 20f));

                friendly.physicalAttackPower += (int) (StatsPerLevel.physAttackPowerPerLevel + (level / 10f));
                friendly.physicalDefense += (int) (StatsPerLevel.physDefensePerLevel + (level / 10f));
                friendly.magicAttackPower += (int) (StatsPerLevel.magicAttackPowerPerLevel + (level / 10f));
                friendly.magicDefense += (int) (StatsPerLevel.magicDefensePerLevel + (level / 10f));

                expToNextLevel *= StatsPerLevel.experienceMultiplier;
                friendly.expToNextLevel = (int) expToNextLevel;
            }

            friendly.currentExp += totalExp;
        }
    }
}