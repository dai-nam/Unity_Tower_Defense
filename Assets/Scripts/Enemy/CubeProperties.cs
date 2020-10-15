using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeProperties : EnemyProperties
{
    private void Awake()
    {
        //Base Values
        Type = EnemyType.CUBE;
        KillBonus = 20;
        DamagePlayerHealth = 1;
        EnemyHealth = 2;
        Speed = 1.5f;
    }

}
