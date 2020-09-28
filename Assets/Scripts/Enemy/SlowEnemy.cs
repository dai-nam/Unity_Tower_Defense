using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemy : EnemyProperties
{
    private void Awake()
    {
        type = EnemyType.SLOW;
       healthPoints = 3;
        color = Color.red;
        speed = base.speed;
        SetEnemyColor();

    }


    private void SetEnemyColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
