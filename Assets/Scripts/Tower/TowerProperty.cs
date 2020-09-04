using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProperty : MonoBehaviour
{
    public enum Level
    {
        BASIC,
        ADVANCED,
        EXPERT
    }

    public Level level;
    public float shootSpeed;
    public ShootTarget shootTarget = ShootTarget.FIRST;
   


}
