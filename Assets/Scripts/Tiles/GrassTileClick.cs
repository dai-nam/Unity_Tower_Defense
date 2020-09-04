using Assets.Scripts.Tiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrassTileClick : TileClick
{
    GrassTile root;
    Material mat;

    public delegate void GrassTileClicked(GrassTile tile);
    public static event GrassTileClicked OnGrassTileClicked;
    public delegate void TowerClicked(Tower tower);
    public static event TowerClicked OnTowerClicked;
 

    private void Awake()
    {
        root = GetComponentInParent<GrassTile>();
        mat = GetComponent<Renderer>().material;
    }


    protected override void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!root.isTowerPlaced)                // -> schöner machen? Biding?
        {
            mat.EnableKeyword("_EMISSION");
            return;
        }
    }

    protected override void OnMouseExit()
    {
     
        mat.DisableKeyword("_EMISSION");
    }

    protected override void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!root.isTowerPlaced)             //oder besser root.tower != null  ?
        {
            OnGrassTileClicked?.Invoke(root);
        }
        else
        {
            OnTowerClicked?.Invoke(root.GetTower());
        }
    }
}
