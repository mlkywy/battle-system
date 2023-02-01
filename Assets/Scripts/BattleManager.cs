using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<Unit> units;
    public List<Enemy> enemies;

    private BattleMath battleMath;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Unit unit1 = units[0];
        Enemy enemy1 = enemies[0];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            battleMath = new BattleMath(unit1, enemy1);
            int damage = battleMath.CalculatePhysicalAttackDamage();
            enemy1.currentHp = enemy1.currentHp - damage;

            Debug.Log($"{damage} DAMAGE DEALT TO ENEMY!");
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            battleMath = new BattleMath(enemy1, unit1);
            int damage = battleMath.CalculatePhysicalAttackDamage();
            unit1.currentHp = unit1.currentHp - damage;

            Debug.Log($"{damage} DAMAGE TAKEN BY ENEMY!");
        }
    }
}
