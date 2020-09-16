using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class TowerProperty : MonoBehaviour
{

    public enum Level
    {
        BASIC = 0,
        ADVANCED = 1,
        EXPERT = 2
    }


    public TowerUpgrades towerUpgrades;
    public Level level;
    public float shootSpeed;
    public ShootTarget shootTarget = ShootTarget.FIRST;

    public void Awake()
    {
        towerUpgrades =  FindObjectOfType<TowerUpgrades>();
    }


    protected void ChangeTowerLook(Upgrade upgrade)
    {

        RemovePreviousLook();
        AddNewLook(upgrade);
}

    private void RemovePreviousLook()                       
    {
        Upgrade currentUpgrade = gameObject.GetComponentInChildren<Upgrade>();

        if (currentUpgrade != null)
        {
            Destroy(currentUpgrade.gameObject);
        }
    }

    protected void AddNewLook(Upgrade upgrade)
    {
        if(upgrade == null)
        {
            return;
        }

        Vector3 position = gameObject.transform.position + new Vector3(0, gameObject.transform.position.y - 0.8f, 0);
        Upgrade upgradeInstance = Instantiate(upgrade, position, Quaternion.identity);
        upgradeInstance.transform.parent = gameObject.transform;
        upgradeInstance.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);

    }
}
