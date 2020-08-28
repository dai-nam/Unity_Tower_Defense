using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Range(0f, 20f)] public float enemySpawnRate = 2f;
    EnemyFactory enemyFactory;

    void Start()
    {
        enemyFactory = FindObjectOfType<EnemyFactory>();
        StartCoroutine(EnemySpawner());
    }


    IEnumerator EnemySpawner()
    {
        enemyFactory.SetSpawnPointReference();  //sicherstellen, dass die Referenz besteht, weil ansonsten NullPointer
        while(true)
        {           
            enemyFactory.SpawnEnemy();
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }

}
