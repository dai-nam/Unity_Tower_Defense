using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProperty : MonoBehaviour
{
    public EnemyType type;
    public int healthPoints;
    public Color color;
   [Range(0f, 5f)] public float speed = 0.8f;

    public enum EnemyType
    {
        FAST,
        SLOW
    }
}
