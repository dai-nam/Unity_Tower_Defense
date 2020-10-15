using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyFactory : MonoBehaviour
{
    Tile spawnPoint;
    [SerializeField] SphereEnemy sphereEnemy;
    [SerializeField] CubeEnemy cubeEnemy;

    [Range(0f, 1f)] public float propabilityForLevel1 = 1f;

    public List<Enemy> SpawnedEnemies { get; set; }
    public List<Enemy> showListInInspector;

    public delegate void EnemySpawned(Enemy enemy);
    public event EnemySpawned OnEnemySpawned;

    public static EnemyFactory Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        SpawnedEnemies = new List<Enemy>();
        showListInInspector = SpawnedEnemies;
    }


    // Damit spawnPoint != null, sonst Bug, weil EnemySpawner von GameManager aufgerufen wird, bevor hier in Start() die Referenz gesetzt wurde
    public void SetSpawnPointReference()   
    {
        spawnPoint = FindObjectOfType<Path>().GetWaypoints()[0];
    }

    public void SpawnEnemy()
    {
        Enemy currentEnemy = SetEnemyType();
        currentEnemy = Instantiate(currentEnemy, spawnPoint.transform.position, Quaternion.identity);
        SetLevel(currentEnemy);
        currentEnemy.transform.SetParent(this.gameObject.transform);
        SpawnedEnemies.Add(currentEnemy);
        OnEnemySpawned?.Invoke(currentEnemy);
    }

    private Enemy SetEnemyType()                        //todo refactor
    {
        float x = UnityEngine.Random.Range(0f, 1f);
        if (x <= 0.5f)
            return sphereEnemy;
        else
            return cubeEnemy;
    }

    private void SetLevel(Enemy enemy)
    {
        float f = UnityEngine.Random.Range(0f, 1f);
        if(f <= propabilityForLevel1)
        {
            enemy.gameObject.AddComponent<EnemyLevel1>();
        }
        else
        {
            enemy.gameObject.AddComponent<EnemyLevel2>();
        }
    }

    public void SetPropabiltyForLevel1(float prob)
    {
        propabilityForLevel1 = prob;
    }

  



    }



