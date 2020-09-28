using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : EnemyProperties
{
    private void Awake()
    {
        type = EnemyType.SLOW;
        killBonus = 20;
        damagePlayerHealth = 1;
        enemyHealth = 3;
        color = Color.red;
        speed = base.speed;
        SetEnemyColor();

    }


    private void SetEnemyColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
