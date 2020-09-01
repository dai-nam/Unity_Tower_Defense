using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    [SerializeField] List<Tile> waypoints = new List<Tile>();       //direkt initialisieren, damit Liste im Inspector gefüllt werden kann


    public List<Tile> GetWaypoints()
    {
        return waypoints;
    }


}
