using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager
{
   public static Text HealthText { get; set; }
    public static event Action<HealthManager> OnGameLost;

    private static int health;
    public static int Health
    {
        get
        {
            return health;
        }
        private set
        {
            HealthText.text = value.ToString();
            health = value;
        }
    }

    public static HealthManager Instance { get; private set; }

    public HealthManager(int money, Text _moneyText)
    {
        Instance = this;
        HealthText = _moneyText;
        Health = money;
    }

  public static void EarnLives(int amount)
    {
        Health += amount;
    }

    private static void LoseLives(int amount)
    {
        Health -= amount;
        if(Health <= 0)
        {
            OnGameLost?.Invoke(null);
        }
    }

    public static void LoseLives(Enemy enemy)
    {
        EnemyProperties.EnemyType type = enemy.GetEnemyType();
        switch(type)
        {
            case EnemyProperties.EnemyType.SLOW: 
                LoseLives(1);
                break;
            case EnemyProperties.EnemyType.FAST:
                LoseLives(2);
                break;
            default:
                break;

        }
    }
}
