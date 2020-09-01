using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    ShootingBehaviour shootingBehaviour;
    [SerializeField] bool isShooting = true;
    [SerializeField] ParticleSystem bullets;

    private GrassTile parentTile;
    public GrassTile ParentTile
    {
        get
        {
            return parentTile;
        }
        set
        {
            parentTile = value;
            parentTile.isTowerPlaced = true;
        }
    }

    private void Awake()
    {
        bullets = GetComponentInChildren<ParticleSystem>();
        shootingBehaviour = GetComponent<ShootingBehaviour>();
        shootingBehaviour.OnFire += Shoot;
    }

    private void Shoot(Enemy target)
    {
        print("B");
        if (target == null) return;
        bullets.gameObject.transform.LookAt(target.transform);
        if (isShooting)
        {
            bullets.Emit(1);
        }
    }

}
