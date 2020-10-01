using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    void Awake()
    {
        Enemy.OnHitByBullet += HandleHitByBullet;
        Enemy.OnGotKilled += HandleOnGotKilled;
        Enemy.OnGotKilled += RemoveEnemy;
        Enemy.OnFinishedPath += HandleOnFinishedPath;
        Enemy.OnFinishedPath += RemoveEnemy;

    }


    private void HandleHitByBullet(Enemy enemy)
    {
        AudioManager.PlaySound("Enemy Hit");
    }


    private void HandleOnGotKilled(Enemy enemy)
    {
        if (!GameManager.isRunning)
        {
            Enemy.OnGotKilled -= HandleOnGotKilled;
            return;
        }
        GameManager.MoneyStats.ModifyAmountDependingOnEnemyLevel(enemy);
        AudioManager.PlaySound("Enemy Killed");
    }

    private void HandleOnFinishedPath(Enemy enemy)
    {
        if (!GameManager.isRunning)
        {
            Enemy.OnFinishedPath -= HandleOnFinishedPath;
            return;
        }
        GameManager.HealthStats.ModifyAmountDependingOnEnemyLevel(enemy);
        AudioManager.PlaySound("Finished Path");
    }

    private void RemoveEnemy(Enemy enemy)
    {
        EnemyFactory.Instance.SpawnedEnemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
