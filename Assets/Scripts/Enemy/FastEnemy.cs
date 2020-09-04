using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : EnemyProperty
{
    private void Awake()
    {
        type = EnemyType.FAST;
        healthPoints = 5;
        color = Color.blue;
        speed = base.speed / 2;
        SetEnemyColor();

    }


    private void SetEnemyColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}
