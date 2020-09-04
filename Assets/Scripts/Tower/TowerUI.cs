using Packages.Rider.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{

    public static Button upgrade;
    public static Button sell;
   public Tower AttachedTower { get; set; }


    private void Awake()
    {
        upgrade =  GameObject.Find("Upgrade").GetComponent<Button>();
        upgrade.onClick.AddListener(delegate { Upgrade(AttachedTower); });
        sell = GameObject.Find("Sell").GetComponent<Button>();
        sell.onClick.AddListener(delegate { Sell(AttachedTower); });
    }

    private void Start()
    {
       gameObject.SetActive(false);             //In Start() damit EventHandler in Awake Referenz aufbauen kann. Sonst findet er es nicht
    }

    public void SetPosition(Tower tower)                    //transform statt tower?
    {
        gameObject.transform.position = tower.transform.position;
    }


    void Upgrade(Tower tower)
    {
        tower.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
    }
    void Sell(Tower tower)
    {
        tower.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
}
