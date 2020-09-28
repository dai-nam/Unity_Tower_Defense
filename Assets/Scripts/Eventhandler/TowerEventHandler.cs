using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEventHandler
{
    //Singleton
    private static TowerEventHandler _instance;
   public static TowerEventHandler Instance
    {
        get
        {
            if ( _instance == null) { return new TowerEventHandler(); }
            else { return _instance; }
        }
        private set { _instance = value; }
    }

    private TowerEventHandler()
    {
        Instance = this;
        TowerUpgradeDowngrade.OnUpgrade += HandleUpgradeEvent;
        TowerUpgradeDowngrade.OnDowngrade += HandleDowngradeEvent;
        TowerUpgradeDowngrade.OnTowerSold += HandleSoldEvent;
        TowerFactory.OnTowerPlaced += HandleTowerPlacedEvent;
    }



    public  void HandleUpgradeEvent(Tower tower, TowerProperty.Level level)
    {
        int cost = 100;
        if (!CanAfford(cost))
        {
            return;
        }
        UpdateToNewLevel(tower, level);
        MoneyManager.LoseMoney(cost);
        AudioManager.PlaySound("Tower Upgrade");
    }

   

    public  void HandleDowngradeEvent(Tower tower, TowerProperty.Level level)
    {
        UpdateToNewLevel(tower, level);
        MoneyManager.Earn(100);
        AudioManager.PlaySound("Tower Downgrade");
    }

    public static void HandleSoldEvent(Tower tower)
    {
        MoneyManager.Earn(200);
        AudioManager.PlaySound("Tower Sold");
        tower.towerUI.gameObject.SetActive(false);
        tower.ParentTile.RemoveTowerFromTile();
        UnityEngine.Object.Destroy(tower.gameObject);
    }


    private void HandleTowerPlacedEvent(Tower tower)
    {
        int cost = 300;
        if(!CanAfford(cost))
        {
            return;
        }
        MoneyManager.LoseMoney(cost);
        AudioManager.PlaySound("Tower Placed");
    }


    private void UpdateToNewLevel(Tower tower, TowerProperty.Level level)
    {
        tower.currentLevel = level;
        DestroyCurrentLevelComponent(tower);
        AddNewLevelComponent(tower, level);
    }

    private void DestroyCurrentLevelComponent(Tower tower)
    {
        var currentComponent = tower.gameObject.GetComponent<TowerProperty>();
        if (currentComponent != null)
        {
            UnityEngine.Object.Destroy(currentComponent);
        }
    }

    private void AddNewLevelComponent(Tower tower, TowerProperty.Level level)
    {
        switch (level)
        {
            case TowerProperty.Level.BASIC:
                tower.gameObject.AddComponent<BasicTower>();
                break;
            case TowerProperty.Level.ADVANCED:
                tower.gameObject.AddComponent<AdvancedTower>();
                break;
            case TowerProperty.Level.EXPERT:
                tower.gameObject.AddComponent<ExpertTower>();
                break;
            default:
                break;
        }
        TowerProperty newComponent = tower.gameObject.GetComponent<TowerProperty>();
        tower.shootingBehaviour.SetTowerPropertyReference(newComponent);
    }


    private bool CanAfford(int cost)
    {
        if (MoneyManager.Deposit >= cost)
        {
            return true;
        }
            Debug.Log("You have no money");
            return false;
    }
}
