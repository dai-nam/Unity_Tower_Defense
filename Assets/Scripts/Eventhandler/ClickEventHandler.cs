using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickEventHandler : MonoBehaviour
{

    TowerFactory towerFactory;
    TowerUI towerUI;

    void Awake()
    {

        towerFactory = FindObjectOfType<TowerFactory>();
        towerUI = FindObjectOfType<TowerUI>();

        GrassTileClick.OnGrassTileClicked += towerFactory.PlaceTower;
        GrassTileClick.OnGrassTileClicked += ToggleTowerUIinactive;

        GrassTileClick.OnTowerClicked += towerUI.SetPosition;
        GrassTileClick.OnTowerClicked += ToggleTowerUIActive;

    }

    Tower previousSelectedTower;
    void ToggleTowerUIActive(Tower selectedTower)           //unschön, weil Parameter hier sinnlos
    {
        if(selectedTower == previousSelectedTower)
        {
            towerUI.gameObject.SetActive(!towerUI.gameObject.activeSelf);
        }
        else
        {
            towerUI.gameObject.SetActive(true);
            towerUI.AttachedTower = selectedTower;
            previousSelectedTower = selectedTower;
        }
    }

    void ToggleTowerUIinactive(GrassTile tile)          //unschön, weil Parameter hier sinnlos
    {
       towerUI.gameObject.SetActive(false);
    }






}
