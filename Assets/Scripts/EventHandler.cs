using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{

    TowerFactory towerFactory;
    Enemy enemy;

    void Start()
    {

        towerFactory = FindObjectOfType<TowerFactory>();
        enemy = FindObjectOfType<Enemy>();

        GrassTile.OnGrassTileClicked += towerFactory.BuildTower;

    }



}
