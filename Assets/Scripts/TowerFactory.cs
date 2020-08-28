using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Transform towerPrefab;


  

    public void BuildTower(object sender, Transform location)
    {
       var tower = Instantiate(towerPrefab, location);
        tower.SetParent(gameObject.transform);
    }


}
