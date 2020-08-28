using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionToggle : MonoBehaviour
{


    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}
