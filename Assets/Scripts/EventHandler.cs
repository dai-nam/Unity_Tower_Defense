using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : MonoBehaviour
{

    public delegate void TowerBuildingMode();
    public event TowerBuildingMode OnTowerBuildingMode;
    TowerFactory towerFactory;

    void Start()
    {

        towerFactory = FindObjectOfType<TowerFactory>();
        GrassTileClick.OnGrassTileClicked += towerFactory.BuildTower;

        OnTowerBuildingMode += Test;
    }

    void Test()
    {
        print("Tower Building Mode Enter");
    }

    private void Update()
    {
        if (Input.GetKeyDown("a"))
            OnTowerBuildingMode?.Invoke();
    }



}
