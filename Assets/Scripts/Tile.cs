//Oberklasse für Path und Grass Tiles

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public abstract class Tile : MonoBehaviour
{

    public int gridSize = 10;

    void Update()
    {
        SnapToGrid();
        UpdateName();
    }


    void SnapToGrid()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10) * 10f;
        snapPos.y = 0;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10) * 10f;
        transform.position = snapPos;
    }

    protected abstract void UpdateName();
   
}
