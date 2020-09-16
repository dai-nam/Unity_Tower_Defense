using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEventHandler
{


 public static void HandleUpgradeEvent(Tower tower)
    {
        Debug.Log("Tower Upgraded");
    }

    public static void HandleDowngradeEvent(Tower tower)
    {
        Debug.Log("Tower Downgraded");
    }

    public static void HandleSoldEvent(Tower tower)
    {
        Debug.Log("Tower Sold");
        tower.towerUI.gameObject.SetActive(false);
        tower.ParentTile.RemoveTowerFromTile();
        UnityEngine.Object.Destroy(tower.gameObject);
    }

}
