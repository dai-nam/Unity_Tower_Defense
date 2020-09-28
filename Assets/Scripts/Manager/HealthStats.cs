using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStats : GameStats
{
    public static event Action<HealthStats> OnGameLost;

    public HealthStats(int health, Text healthText)
    {
        Initialize(this, health, healthText);
    }

    public override void Increase(int amount)
     {
        ModifyAmount(amount);
     }

    public override void Decrease(int amount)
    {
        ModifyAmount(-amount);
        if(Amount <= 0)
        {
            Amount = 0;
            OnGameLost?.Invoke(null);
        }
    }

    protected override void Modify(Enemy enemy)
    {
        Decrease(enemy.GetDamagePlayerHealth());
    }

}
