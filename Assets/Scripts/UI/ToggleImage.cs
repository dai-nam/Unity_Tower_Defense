using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleImage : MonoBehaviour
{

    Image img;
    GameObject go;
    private void Awake()
    {
        // gameObject.active = false;
        img = GetComponent<Image>();
        img.enabled = false;
    }

    public void Toggle()
    {
        // gameObject.active = !gameObject.active;
        img.enabled = !img.enabled;
    }
}
