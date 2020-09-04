using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{
    ShootingBehaviour shootingBehaviour;
    [SerializeField] bool isShooting = true;
    [SerializeField] ParticleSystem bullets;

  TowerProperty.Level level;

    public TowerProperty.Level Level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
            SetLevel(value);
        }
    }

  
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
        /////BUGGGG!
         var towerProperty = gameObject.AddComponent<BasicTower>();
         level = towerProperty.level;

        shootingBehaviour = GetComponent<ShootingBehaviour>();
        shootingBehaviour.SetTowerPropertyReference(towerProperty);
        shootingBehaviour.OnFire += Shoot;

        bullets = GetComponentInChildren<ParticleSystem>();
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

    public void SetLevel(TowerProperty.Level level)
    {
        print("SetLevel");
        var current = GetComponent<TowerProperty>();         //unschön -> todo: Event ruft Methode auf, die current ändert.
        if(current != null)
        {
            print("Destroy");
            Destroy(current);
        }

        switch(level)
        {
            case TowerProperty.Level.BASIC:
                print("Basuc");
                gameObject.AddComponent<BasicTower>();
                break;
            case TowerProperty.Level.ADVANCED:
                gameObject.AddComponent<AdvancedTower>();
                break;
            case TowerProperty.Level.EXPERT:
                gameObject.AddComponent<ExpertTower>();
                break;
            default:
                break;
        }
        Debug.Log("switched behaviour to: " + level);


    }






}
