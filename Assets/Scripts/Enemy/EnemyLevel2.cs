using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel2 : EnemyLevel
{

    EnemyProperties current;
    private void Awake()
    {
        current = GetComponent<EnemyProperties>();
        InitLevelProperties();
    }

    protected override void InitLevelProperties()
    {
        current.CurrentLevel = EnemyProperties.Level.LEVEL_2;
        current.KillBonus += 10;
        current.DamagePlayerHealth += 1;
        current.EnemyHealth += 2;
        current.Speed *= 2f;
        current.EnemyColor = Color.blue;
    }
}
