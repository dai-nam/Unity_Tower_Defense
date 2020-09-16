using Packages.Rider.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{

    public static Button upgrade;
    public static Button sell;
    private Tower tower;
   public Tower AttachedTower
    {
        get { return tower; }
        set
        {
            tower = value;
            tower.towerUI = this;
        }

    }


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

    public void SetPosition(Tower _tower)                    //transform statt tower?
    {
        gameObject.transform.position = _tower.transform.position;
    }


    void Upgrade(Tower _tower)
    {
        _tower.Upgrade();
    }
    void Sell(Tower _tower)
    {
        _tower.Downgrade();
    }
}
