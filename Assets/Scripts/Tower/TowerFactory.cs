using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    public int maxTowers = 4;
    public Tower[] towers;
    public int index = 0;
    Vector3 yOffset;
    public static event Action<Tower> OnTowerPlaced;


    private void Start()
    {
        towers = new Tower[maxTowers];
        yOffset = new Vector3(0, towerPrefab.transform.localScale.y, 0);
    }
    public void PlaceTower(GrassTile tile)
    {
        if (tile.isTowerPlaced)
        {
            return;
        }
        if (towers.Any(item => item == null))
        {
            InstantiateNewTower(tile);
        }
        else
        {
            MoveExistingTower(tile);
        }

        index = (index + 1) % maxTowers;

    }

    private void InstantiateNewTower(GrassTile tile)
    {
        Tower tower = Instantiate(towerPrefab, tile.transform.position + yOffset, Quaternion.identity);
        towers[index] = tower;
        tower.transform.SetParent(gameObject.transform);
        tower.gameObject.name = "Tower " + index;
        towers[index].ParentTile = tile;
        tile.SetTowerToTile(tower);

        OnTowerPlaced?.Invoke(tower);

    }

    private void MoveExistingTower(GrassTile tile)
    {
        towers[index].ParentTile.RemoveTowerFromTile();
       // towers[index].ParentTile.isTowerPlaced = false;                     //Reset isTowerPlaced for old Position
        towers[index].transform.position = tile.transform.position + yOffset;
        towers[index].ParentTile = tile;
        tile.SetTowerToTile(towers[index]);

        OnTowerPlaced?.Invoke(towers[index]);
    }
}
