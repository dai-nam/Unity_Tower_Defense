using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;


public class Tower : MonoBehaviour
{
    public TowerUI towerUI;
    TowerUpgradeDowngrade tud;

    public ShootingBehaviour shootingBehaviour;
    [SerializeField] bool isShooting = true;
    [SerializeField] ParticleSystem bullets;
    public List<TowerProperty.Level> possibleLevels;

    public TowerProperty.Level currentLevel;
  
    private GrassTile parentTile;
    public GrassTile ParentTile
    {
        get 
        { 
           return parentTile; 
        }
        set 
        { 
           parentTile = value; 
           parentTile.isTowerPlaced = true; 
        }
    }

    private void Awake()
    {
        var towerProperty = gameObject.AddComponent<BasicTower>();
        currentLevel = towerProperty.level;
        possibleLevels = Enum.GetValues(typeof(TowerProperty.Level)).Cast<TowerProperty.Level>().ToList();  //Liste der Level enums

        shootingBehaviour = GetComponent<ShootingBehaviour>();
        shootingBehaviour.SetTowerPropertyReference(towerProperty);
        shootingBehaviour.OnFire += Shoot;

        bullets = GetComponentInChildren<ParticleSystem>();

        tud = GameObject.FindObjectOfType<TowerUpgradeDowngrade>();
    }


    private void Shoot(Enemy target)
    {
        if (target == null) return;
        bullets.gameObject.transform.LookAt(target.transform);
        if (isShooting)
        {
            bullets.Emit(1);
        }
    }

    public void Upgrade()
    {
        tud.SetTowerReference(this);
        tud.Upgrade();

    }

    public void Downgrade()
    {
        tud.SetTowerReference(this);
        tud.Downgrade();

    }


}
