using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Transform towerPrefab;


    public void BuildTower(GrassTile tile)
    {
        var tower = Instantiate(towerPrefab, tile.transform);
        tower.SetParent(gameObject.transform);
    }


}
