using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFactory : MonoBehaviour
{

    Tile spawnPoint;
    [SerializeField] Enemy enemyPrefab;
    public static List<Enemy> spawnedEnemies;
    [Range(0f, 10f)] [SerializeField] float speed = 2f;
    public List<Enemy> tempList;


    public delegate void EnemySpawned(Enemy enemy);
    public event EnemySpawned OnEnemySpawned;

    private void Awake()
    {
        spawnedEnemies = new List<Enemy>();
        tempList = spawnedEnemies;
    }

    private void Start()
    {
        Enemy.OnGotKilled += RemoveEnemy;
        Enemy.OnFinishedPath += RemoveEnemy;

    }

    // Damit spawnPoint != null, sonst Bug, weil EnemySpawner von GameManager aufgerufen wird, bevor hier in Start() die Referenz gesetzt wurde
    public  void SetSpawnPointReference()   
    {
        spawnPoint = FindObjectOfType<Path>().GetWaypoints()[0];
    }

    public void SpawnEnemy()
    {
        Enemy  enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
        enemy.transform.SetParent(this.gameObject.transform);
        enemy.speed = this.speed;
        spawnedEnemies.Add(enemy);
        OnEnemySpawned?.Invoke(enemy);
    }


    private void RemoveEnemy(Enemy enemy)
    {
        EnemyFactory.spawnedEnemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }


}
