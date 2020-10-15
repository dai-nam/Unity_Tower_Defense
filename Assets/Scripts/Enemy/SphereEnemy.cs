using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEnemy : Enemy
{

    public new void Awake()
    {
        base.Awake();
        Properties = GetComponent<EnemyProperties>();
    }

    protected override void OffsetYPosition(Transform _transform)
    {
        yOffest = new Vector3(0, _transform.localScale.y, 0); //Sphere hat einen anderen Offset als Cube, weil Scale vom Mittelpunkt aus gemessen wird
        _transform.position += yOffest;
    }
    //More Sphere specific behaviour


}
