using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertTower : TowerProperty
{

    private new void Awake()
    {
        base.Awake();
        level = Level.EXPERT;
        shootSpeed = 3f;

        ChangeTowerLook(towerUpgrades.upgrade_2);
    }


   
}
