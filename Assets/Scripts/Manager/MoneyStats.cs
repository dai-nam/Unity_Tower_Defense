using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;


public class MoneyStats : GameStats
{ 


    public MoneyStats(int money, Text moneyText)
    {
        Initialize(this, money, moneyText);
    }

    public override void Increase(int amount)
    {
        ModifyAmount(amount);
    }

    public override void Decrease(int amount)
    {
        ModifyAmount(-amount);
    }


    protected override void Modify(Enemy enemy)
    {
        Increase(enemy.GetKillBonus());
    }
}

