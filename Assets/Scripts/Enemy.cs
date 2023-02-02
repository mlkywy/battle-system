using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    /// <summary>
    /// The unit's elemental weaknesses, which includes ice, fire, lightning, wind, or earth.
    /// </summary>
    public List<ElementType> weaknesses;

    /// <summary>
    /// The unit's elemental immunities, which includes ice, fire, lightning, wind, or earth.
    /// </summary>
    public List<ElementType> immunities;
}
