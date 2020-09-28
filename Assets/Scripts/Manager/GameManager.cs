using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    [Range(0f, 20f)] public float enemySpawnRate = 2f;
    EnemyFactory enemyFactory;
    TowerFactory towerFactory;
    TowerEventHandler towerEventHandler;
    [SerializeField] Text moneyText;
    [SerializeField] Text healthText;
    public static bool isRunning;
    [SerializeField] Canvas gameOverCanvas;

    MoneyManager moneyManager;
    HealthManager healthManager;

    private void Awake()
    {
        isRunning = true;
        gameOverCanvas.enabled = false;
        moneyManager = new MoneyManager(1000, moneyText);
        healthManager = new HealthManager(5, healthText);
    }
    void Start()
    {
        enemyFactory = FindObjectOfType<EnemyFactory>();
        towerFactory = FindObjectOfType<TowerFactory>();
        StartCoroutine(EnemySpawnCoroutine());
        towerEventHandler = TowerEventHandler.Instance;
        HealthManager.OnGameLost += GameLost;
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

    void GameLost(HealthManager hm)
    {
        print("You have lost the Game");
        isRunning = false;
        gameOverCanvas.enabled = true;      //Canvas im Vordergrund blockiert User Input (Workaround)

    }
}

