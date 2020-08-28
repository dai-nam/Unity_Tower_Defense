using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFactory : MonoBehaviour
{

    Tile spawnPoint;
   [SerializeField] Enemy enemyPrefab;
    public delegate void EnemySpawned(Enemy enemy);
    public event EnemySpawned OnEnemySpawned;


    // Damit spawnPoint != null, sonst Bug, weil EnemySpawner von GameManager aufgerufen wird, bevor hier in Start() die Referenz gesetzt wurde
    public void SetSpawnPointReference()   
    {
        spawnPoint = FindObjectOfType<Path>().GetWaypoints()[0];
    }

    public void SpawnEnemy()
    {
        Enemy  enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemy.transform.SetParent(this.gameObject.transform);
        OnEnemySpawned?.Invoke(enemy);
    }



}
