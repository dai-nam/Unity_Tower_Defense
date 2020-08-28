using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    public int maxTowers = 4;
    public Tower[] towers;
    public int currentIndex = 0;
    Vector3 yOffset;

    private void Start()
    {
        towers = new Tower[maxTowers];
        yOffset = new Vector3(0, towerPrefab.transform.localScale.y, 0);

    }
    public void BuildTower(GrassTile tile)
    {

        if (towers[currentIndex] == null && !tile.isTowerPlaced)
        {
            Tower tower = Instantiate(towerPrefab, tile.transform.position+yOffset, Quaternion.identity);
            towers[currentIndex] = tower;
            tower.transform.SetParent(gameObject.transform);
            tower.ParentTile = tile;
        }
        else
        {
            MoveExistingTower(tile);
        }

        currentIndex = (currentIndex + 1) % maxTowers;
    }

    private void MoveExistingTower(GrassTile tile)
    {
        towers[currentIndex].ParentTile.isTowerPlaced = false;                     //Reset isTowerPlaced for old Position
        towers[currentIndex].transform.position = tile.transform.position + yOffset;
        towers[currentIndex].ParentTile = tile;                   
    }
}
