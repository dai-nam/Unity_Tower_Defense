using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    [Range(0f, 20f)] public float enemySpawnRate = 2f;
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
        isRunning = true;
        gameOverCanvas.enabled = false;
        MoneyStats = new MoneyStats(1000, moneyText);
        HealthStats = new HealthStats(5, healthText);
    }
    void Start()
    {
        enemyFactory = FindObjectOfType<EnemyFactory>();
        StartCoroutine(EnemySpawnCoroutine());
        towerEventHandler = TowerEventHandler.Instance;
        HealthStats.OnGameLost += GameLost;
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

    void GameLost(HealthStats hm)
    {
        print("You have lost the Game");
        isRunning = false;
        gameOverCanvas.enabled = true;      //Canvas im Vordergrund blockiert User Input (Workaround)

    }
}

