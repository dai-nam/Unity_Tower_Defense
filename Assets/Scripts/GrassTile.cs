using UnityEngine;
using System;


public class GrassTile : Tile
{
    public delegate void GrassTileClicked(GrassTile tile);
    public static event GrassTileClicked OnGrassTileClicked;
    bool towerPlaced;

    private void OnMouseDown()
    {
        if(!towerPlaced)
        {
            OnGrassTileClicked?.Invoke(this);
            towerPlaced = true;
        }
    }

  

    protected override void  UpdateName()
    {
    string name = transform.position.x / gridSize + "," + transform.position.z / gridSize;
    gameObject.name = "Grass " + name;
    }

}
