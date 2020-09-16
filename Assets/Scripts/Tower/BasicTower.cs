using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : TowerProperty
{


    private new void Awake()
    {
        base.Awake();

        level = Level.BASIC;
        shootSpeed = 1f;

        ChangeTowerLook(null);
    }

}
