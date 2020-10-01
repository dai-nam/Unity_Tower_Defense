using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class GameStats
{

    public  Text TextField { get; set; }

    private  int amount;
    public int Amount
    {
        get
        {
            return amount;
        }
        protected set
        {
            TextField.text = value.ToString();
            amount = value;
        }
    }

    public GameStats Instance { get; private set; }


    public void Initialize(GameStats _instance, int _amount, Text _text)
    {
        Instance = _instance;
        TextField = _text;
        Amount = _amount;
    }

    public void ModifyAmount(int amount)
    {
        Amount += amount;
    }

    public void ModifyAmountDependingOnEnemyLevel(Enemy enemy)
    {
        Modify(enemy);
    }


    public abstract void Increase(int amount);
    public abstract void Decrease(int amount);
    protected abstract void Modify(Enemy enemy);


}
