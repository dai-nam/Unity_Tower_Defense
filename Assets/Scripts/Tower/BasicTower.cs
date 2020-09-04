using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : TowerProperty
{
    private void Awake()
    {
        level = Level.BASIC;
        shootSpeed = 1f;
    }
}
