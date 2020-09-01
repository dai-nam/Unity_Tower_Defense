using UnityEngine;
using System;


public class GrassTile : Tile
{

    public bool isTowerPlaced;

    protected override void  UpdateName()
    {
        gameObject.name = "Grass " + base.GetCoordinates();
    }

}
