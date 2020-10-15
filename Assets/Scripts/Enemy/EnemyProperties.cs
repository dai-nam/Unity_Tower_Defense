
using UnityEngine;

public abstract class EnemyProperties : MonoBehaviour
{
    #region ###Properties###
    public EnemyLevel currentLevel;
    public EnemyType Type { get; set; }

    public Level CurrentLevel { get; set; }
    public int KillBonus { get; set; }
    public int DamagePlayerHealth { get; set; }
    public int EnemyHealth { get; set; }
    private float speed;
    public float Speed {
        get { return speed; } 
        set { speed = 1/value; }
    }

    private Color enemyColor;
    public Color EnemyColor { 
        get { return enemyColor; }
        set { SetEnemyColor(value);
              enemyColor = value; }
    }
    #endregion

    #region ###Enums###
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
    #endregion


    private void Start()
    {
        currentLevel = GetComponent<EnemyLevel>();
        currentLevel.InitLevelProperties(this);
    }

    private void SetEnemyColor(Color enemyColor)
    {
        GetComponent<Renderer>().material.SetColor("_Color", enemyColor);
    }

}
