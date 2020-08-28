using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : Tile
{

    protected override void UpdateName()
    {
        string name = transform.position.x / gridSize + "," + transform.position.z / gridSize;
        gameObject.name = "WP "+name;
        GetComponentInChildren<TextMesh>().text = name;
    }


}
