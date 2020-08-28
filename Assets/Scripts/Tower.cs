using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    List<Enemy> enemies;

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

    [SerializeField] ParticleSystem bullets;

    private void Awake()
    {
        bullets = GetComponentInChildren<ParticleSystem>();
        bullets.Play();
        enemies = EnemyFactory.spawnedEnemies;
    }

    private void Update()
    {
        ShootAtEnemy();
    }

    void ShootAtEnemy()
    {
        if (enemies.Count <= 0)
        {
            bullets.Stop();
            return;
        }
        if (!bullets.isPlaying)
        {
            bullets.Play();
        }
        bullets.gameObject.transform.LookAt(enemies[0].transform);      //der älteste (am weitesten gelaufene) Enemy

    }
}
