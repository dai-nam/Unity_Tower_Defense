using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel1 : EnemyLevel
{
    EnemyProperties current;


    private void Awake()
    {
        current = GetComponent<EnemyProperties>();
        InitLevelProperties();
    }
    protected override void InitLevelProperties()
    {
        current.CurrentLevel = EnemyProperties.Level.LEVEL_1;
        current.EnemyColor = Color.red;

    }



}
