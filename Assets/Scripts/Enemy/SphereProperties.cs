using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereProperties : EnemyProperties
{
    private void Awake()
    {
        //Base Values
        Type = EnemyType.SPHERE;
        KillBonus = 20;
        DamagePlayerHealth = 1;
        EnemyHealth = 3;
        Speed = 1f;
    }


}
