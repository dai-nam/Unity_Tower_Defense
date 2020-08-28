using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTileClick : MonoBehaviour
{

    public delegate void GrassTileClicked(GrassTile tile);
    public static event GrassTileClicked OnGrassTileClicked;
    public bool isTowerPlaced;



    private void OnMouseEnter()
    {
        if(!isTowerPlaced)
        {
            GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }

    private void OnMouseDown()
    {
            OnGrassTileClicked?.Invoke(GetComponentInParent<GrassTile>());
    }
}
