using UnityEngine;
using System;


public class GrassTile : Tile
{

    public bool isTowerPlaced;
    private Tower tower;

    protected override void  UpdateName()
    {
        gameObject.name = "Grass " + base.GetCoordinates();
    }

    public void SetTowerToTile(Tower _tower)
    {
        tower = _tower;
        isTowerPlaced = true;
    }

    public void RemoveTowerFromTile()
    {
        tower = null;
        isTowerPlaced = false;
    }

    public Tower GetTower()
    {
        return this.tower;
    }
}
