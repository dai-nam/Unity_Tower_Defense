using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

  [SerializeField] List<Tile> waypoints = new List<Tile>();

    public List<Tile> GetWaypoints()
    {
        return waypoints;
    }


}
