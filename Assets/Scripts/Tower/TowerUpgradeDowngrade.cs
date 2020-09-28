using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class TowerUpgradeDowngrade : MonoBehaviour                  //todo Monobehaviour entfernen und vom Gameibjebt entfernen, Singleton
{

    Tower tower;

    //Upgrade Events
    public static event Action<Tower, TowerProperty.Level> OnUpgrade;
    //Downgrade Events
    public static event Action<Tower, TowerProperty.Level> OnDowngrade;
    public static event Action<Tower> OnTowerSold;



    public void SetTowerReference(Tower _tower)
    {
        tower = _tower;
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
            OnUpgrade?.Invoke(tower, tower.possibleLevels[currentIndex + 1]);
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
            OnDowngrade?.Invoke(tower, tower.possibleLevels[currentIndex - 1]);
        }
    }

   
}
