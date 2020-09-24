using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFactory : MonoBehaviour
{

    Tile spawnPoint;
    [SerializeField] Enemy enemyPrefab;
    public static List<Enemy> spawnedEnemies;
    public List<Enemy> showListInInspector;

    public delegate void EnemySpawned(Enemy enemy);
    public event EnemySpawned OnEnemySpawned;

    private void Awake()
    {
        spawnedEnemies = new List<Enemy>();
        showListInInspector = spawnedEnemies;

    }


    // Damit spawnPoint != null, sonst Bug, weil EnemySpawner von GameManager aufgerufen wird, bevor hier in Start() die Referenz gesetzt wurde
    public  void SetSpawnPointReference()   
    {
        spawnPoint = FindObjectOfType<Path>().GetWaypoints()[0];
    }

    public void SpawnEnemy()
    {
        EnemyProperty.EnemyType type = SelectEnemyType();
        Enemy enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemy.InitTypeProperties(type);
        enemy.transform.SetParent(this.gameObject.transform);
        spawnedEnemies.Add(enemy);
        OnEnemySpawned?.Invoke(enemy);
    }

    private static EnemyProperty.EnemyType SelectEnemyType()
    {
        EnemyProperty.EnemyType type;
        float f = UnityEngine.Random.Range(0f, 1f);
        type = (f <= 0.6f) ? EnemyProperty.EnemyType.SLOW : EnemyProperty.EnemyType.FAST;
        return type;
    }




    }



