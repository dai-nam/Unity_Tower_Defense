
using UnityEngine;

public class EnemyLevel1 : EnemyLevel
{
    public override void InitLevelProperties(EnemyProperties properties)
    {
        properties.CurrentLevel = EnemyProperties.Level.LEVEL_1;
        properties.EnemyColor = Color.red;

    }



}
