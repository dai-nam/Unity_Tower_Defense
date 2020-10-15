using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemy : Enemy
{

    private new void Awake()
    {
        base.Awake();
        Properties = GetComponent<EnemyProperties>();
    }

    //More Cube specific behaviour

}
