using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTile : Tile
{


    protected override void UpdateName()
    {
        gameObject.name = "WP "+base.GetCoordinates();
        GetComponentInChildren<TextMesh>().text = base.GetCoordinates();
    }


}
