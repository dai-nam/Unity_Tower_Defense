using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyProperties : MonoBehaviour
{
    public EnemyType Type { get; set; }

    public Level CurrentLevel { get; set; }
    public int KillBonus { get; set; }
    public int DamagePlayerHealth { get; set; }
    public int EnemyHealth { get; set; }
    private float speed;
    public float Speed 
    {
        get
        {
            return speed;
        } 
        set
        {
            speed = 1/value;
        }
    }

    private Color enemyColor;
    public Color EnemyColor
    {
        get
        {
            return enemyColor;
        }
        set
        {
            SetEnemyColor(value);
            enemyColor = value;
        }
    }


    private void SetEnemyColor(Color enemyColor)
    {
        GetComponent<Renderer>().material.SetColor("_Color", enemyColor);
    }

    public enum EnemyType
    {
        SPHERE,
        CUBE
    }

    public enum Level
    {
        LEVEL_2,
        LEVEL_1
    }
}
