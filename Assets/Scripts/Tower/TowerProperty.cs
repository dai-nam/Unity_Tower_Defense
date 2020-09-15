using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerProperty : MonoBehaviour
{
    public enum Level
    {
        BASIC = 0,
        ADVANCED = 1,
        EXPERT = 2
    }



    public Level level;
    public float shootSpeed;
    public ShootTarget shootTarget = ShootTarget.FIRST;
   


}
