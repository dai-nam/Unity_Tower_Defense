using UnityEngine;
using System;


public class GrassTile : Tile
{
    public static event EventHandler<Transform> OnGrassTileClicked;
    bool towerPlaced;

    private void OnMouseDown()
    {
        if(!towerPlaced)
        {
            OnGrassTileClicked?.Invoke(this, this.transform);
            towerPlaced = true;
        }
    }

    protected override void  UpdateName()
    {
    string name = transform.position.x / gridSize + "," + transform.position.z / gridSize;
    gameObject.name = "Grass " + name;
    }

}
