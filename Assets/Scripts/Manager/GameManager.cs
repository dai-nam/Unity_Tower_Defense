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
        StartCoroutine(EnemySpawnCoroutine());
    }

 

    IEnumerator EnemySpawnCoroutine()
    {
        enemyFactory.SetSpawnPointReference();  //sicherstellen, dass die Referenz besteht, weil ansonsten NullPointer
        WaitForSeconds wfs = new WaitForSeconds(enemySpawnRate);    //cachen, damit es im while Loop nicht immer wieder neu kreiert wird 
        while (true)
        {           
            enemyFactory.SpawnEnemy();
            yield return wfs;
        }
    }

}
