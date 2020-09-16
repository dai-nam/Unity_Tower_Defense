using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedTower : TowerProperty
{


    private new void Awake()
    {
        base.Awake();

        level = Level.ADVANCED;
        shootSpeed = 2f;

        ChangeTowerLook(towerUpgrades.upgrade_1);
    }

 
}
