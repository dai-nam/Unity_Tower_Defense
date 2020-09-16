using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TowerUpgradeDowngrade : MonoBehaviour                  //todo Monobehaviour entfernen und vom Gameibjebt entfernen, Singleton
{

    Tower tower;

    //Upgrade Events
    public delegate void Upgraded(Tower tower);
    public  event Upgraded OnUpgraded;
    //Downgrade Events
    public delegate void Downgraded(Tower tower);
    public  event Downgraded OnDowngraded;
    public delegate void TowerSold(Tower tower);
    public  event TowerSold OnTowerSold;

    void Awake()
    {
        OnUpgraded += TowerEventHandler.HandleUpgradeEvent;
        OnDowngraded += TowerEventHandler.HandleDowngradeEvent;
        OnTowerSold += TowerEventHandler.HandleSoldEvent;
    }

    public void SetTowerReference(Tower _tower)
    {
        tower = _tower;
        print("Current tower = " + tower.name);
    }

    public  void Upgrade()
    {
        int currentIndex = (int) tower.possibleLevels.Find(level => level == tower.currentLevel);  // Wert=Index des enums erhalten
        if (currentIndex >= tower.possibleLevels.Count() - 1)
        {
            return;
        }
        else
        {
            UpdateToNewLevel(tower.possibleLevels[currentIndex + 1]);
            OnUpgraded?.Invoke(tower);
        }
    }

    public  void Downgrade()
    {
        int currentIndex = (int) tower.possibleLevels.Find(level => level == tower.currentLevel);  // Wert=Index des enums erhalten
        if (currentIndex <= 0)
        {
            OnTowerSold?.Invoke(tower);
            return;

        }
        else
        {
            UpdateToNewLevel(tower.possibleLevels[currentIndex - 1]);
            OnDowngraded?.Invoke(tower);
        }
    }

    private  void UpdateToNewLevel(TowerProperty.Level level)
    {
        tower.currentLevel = level;
        DestroyCurrentLevelComponent();
        AddNewLevelComponent(level);
    }

    private  void DestroyCurrentLevelComponent()
    {
        var currentComponent = tower.gameObject.GetComponent<TowerProperty>();
        if (currentComponent != null)
        {
            UnityEngine.Object.Destroy(currentComponent);
        }
    }

    private  void AddNewLevelComponent(TowerProperty.Level level)
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
}
