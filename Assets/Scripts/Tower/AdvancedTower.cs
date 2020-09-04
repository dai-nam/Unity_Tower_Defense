using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedTower : TowerProperty
{

    private void Awake()
    {
        level = Level.ADVANCED;
        shootSpeed = 2f;
    }
}
