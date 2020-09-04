using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpertTower : TowerProperty
{

    private void Awake()
    {
        level = Level.EXPERT;
        shootSpeed = 3f;
    }
}
