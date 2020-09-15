using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;


public class Tower : MonoBehaviour
{
    ShootingBehaviour shootingBehaviour;
    [SerializeField] bool isShooting = true;
    [SerializeField] ParticleSystem bullets;
    List<TowerProperty.Level> possibleLevels;

    TowerProperty.Level currentLevel;
  
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
       // GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        int currentIndex = (int) possibleLevels.Find(level => level == currentLevel);  // Wert=Index des enums erhalten
        if (currentIndex >= possibleLevels.Count() - 1)
        {
            print("Already highest level");
            return;
        }
        else
        {
            UpdateToNewLevel(possibleLevels[currentIndex + 1]);
        }

    }

    public void Downgrade()
    {
      //  GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        int currentIndex = (int) possibleLevels.Find(level => level == currentLevel);  // Wert=Index des enums erhalten
        if (currentIndex <= 0)
        {
            print("Already lowest level");
            return;
        }
        else
        {
            UpdateToNewLevel(possibleLevels[currentIndex - 1]);
        }
    }

    private void UpdateToNewLevel(TowerProperty.Level level)
    {
        this.currentLevel = level;
        DestroyCurrentLevelComponent();
        AddNewLevelComponent(level);
    }

    private void DestroyCurrentLevelComponent()
    {
        var currentComponent = GetComponent<TowerProperty>();         
        if (currentComponent != null)
        {
           Destroy(currentComponent);
        }
    }

    private void AddNewLevelComponent(TowerProperty.Level level)
    {
        TowerProperty newComponent = null;
        switch (level)
        {
            case TowerProperty.Level.BASIC:
                newComponent = gameObject.AddComponent<BasicTower>();
                break;
            case TowerProperty.Level.ADVANCED:
                newComponent = gameObject.AddComponent<AdvancedTower>();
                break;
            case TowerProperty.Level.EXPERT:
                newComponent = gameObject.AddComponent<ExpertTower>();
                break;
            default:
                break;
        }

        shootingBehaviour.SetTowerPropertyReference(newComponent);

        Debug.Log("Switched behaviour to: " + level);
    }





}
