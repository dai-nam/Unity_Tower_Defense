
using UnityEngine;

public class EnemyLevel2 : EnemyLevel
{

    public override void InitLevelProperties(EnemyProperties properties)
    {
        properties.CurrentLevel = EnemyProperties.Level.LEVEL_2;
        properties.KillBonus += 10;
        properties.DamagePlayerHealth += 1;
        properties.EnemyHealth += 2;
        properties.Speed *= 2f;
        properties.EnemyColor = Color.blue;
    }
}
