using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSounds : GameSounds
{
    [SerializeField] AudioClip towerPlaced;
    [SerializeField] AudioClip towerUpgrade;
    [SerializeField] AudioClip towerDowngrade;
    [SerializeField] AudioClip towerSold;

    [SerializeField] AudioClip enemyHit;
    [SerializeField] AudioClip enemyKilled;
    [SerializeField] AudioClip finishedPath;
}
