using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    [Range(0f, 4f)] public float enemySpawnRate = 1f;
    EnemyFactory enemyFactory;
    TowerEventHandler towerEventHandler;
    [SerializeField] Text moneyText;
    [SerializeField] Text healthText;
    public static bool isRunning;
    [SerializeField] Canvas gameOverCanvas;

    public static MoneyStats MoneyStats;
    public static HealthStats HealthStats;

    private void Awake()
    {
        enemySpawnRate = 1/enemySpawnRate;
        isRunning = true;
        gameOverCanvas.enabled = false;
        MoneyStats = new MoneyStats(1000, moneyText);
        HealthStats = new HealthStats(5, healthText);
    }
    void Start()
    {
        enemyFactory = EnemyFactory.Instance;
        StartCoroutine(EnemySpawnCoroutine());
        towerEventHandler = TowerEventHandler.Instance;
        HealthStats.OnGameLost += GameLost;
    }



    IEnumerator EnemySpawnCoroutine()
    {
        enemyFactory.SetSpawnPointReference();  //sicherstellen, dass die Referenz besteht, weil ansonsten NullPointer
        while (true)
        {           
            enemyFactory.SpawnEnemy();
            yield return new WaitForSeconds(1/enemySpawnRate);
        }
    }

    void GameLost(HealthStats hm)
    {
        print("You have lost the Game");
        isRunning = false;
        gameOverCanvas.enabled = true;      //Canvas im Vordergrund blockiert User Input (Workaround)

    }
}

