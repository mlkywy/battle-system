using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    /// <summary>
    /// The number of actions this enemy can complete per turn.
    /// </summary>
    public int actionsPerTurn;

    /// <summary>
    /// The amount of exp earned by defeating this enemy.
    /// </summary>
    public int expGiven => CalculateExpGiven(this);

    /// <summary>
    /// The enemy's elemental weaknesses, which includes ice, fire, lightning, wind, or earth.
    /// </summary>
    public List<ElementType> weaknesses;

    /// <summary>
    /// The enemy's elemental immunities, which includes ice, fire, lightning, wind, or earth.
    /// </summary>
    public List<ElementType> immunities;

    /// <summary>
    /// Calculates the amount of experience that should be earned when defeating this enemy.
    /// </summary>
    private int CalculateExpGiven(Unit enemy)
    {
        return (enemy.level * (enemy.maxHp + enemy.physicalAttackPower + enemy.magicAttackPower)) / 3;
    }
}
