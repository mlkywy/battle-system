using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Special", menuName = "ScriptableObjects/Special", order = 3)]
public class SpecialObject : ScriptableObject
{
    /// <summary>
    /// The special ability's name.
    /// </summary>
    public string specialName;

    /// <summary>
    /// The special ability's base power. 
    /// </summary>
    public int specialPower;
}