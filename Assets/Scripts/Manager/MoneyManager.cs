using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager
{
   public static Text MoneyText { get; set; }

    private static int deposit;
    public static int Deposit
    {
        get
        {
            return deposit;
        }
        private set
        {
            MoneyText.text = value.ToString();
            deposit = value;
        }
    }

    public static MoneyManager Instance { get; private set; }

    public MoneyManager(int money, Text _moneyText)
    {
        Instance = this;
        MoneyText = _moneyText;
        Deposit = money;
    }

  public static void Earn(int amount)
    {
        Deposit += amount;
    }

    public static void LoseMoney(int amount)
    {
        Deposit -= amount;
    }

    public static void KillBonus(Enemy enemy)
    {
        EnemyProperties.EnemyType type = enemy.GetEnemyType();
        switch (type)
        {
            case EnemyProperties.EnemyType.SLOW:
                Earn(20);
                break;
            case EnemyProperties.EnemyType.FAST:
                Earn(30);
                break;
            default:
                break;

        }
    }
}
