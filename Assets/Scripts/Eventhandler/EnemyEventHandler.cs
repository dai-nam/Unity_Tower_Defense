using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventHandler : MonoBehaviour
{
    void Awake()
    {
        Enemy.OnHitByBullet += HandleHitByBullet;
        Enemy.OnGotKilled += HandleOnGotKilled;
        Enemy.OnFinishedPath += HandleOnFinishedPath;
    }


    private void HandleHitByBullet(Enemy enemy)
    {
        AudioManager.PlaySound("Enemy Hit");
    }


    private void HandleOnGotKilled(Enemy enemy)
    {
        MoneyManager.KillBonus(enemy);
        AudioManager.PlaySound("Enemy Killed");
        RemoveEnemy(enemy);
    }

    private void HandleOnFinishedPath(Enemy enemy)
    {
        HealthManager.LoseLives(enemy);
        AudioManager.PlaySound("Finished Path");
        RemoveEnemy(enemy);
    }

    private void RemoveEnemy(Enemy enemy)
    {
        EnemyFactory.spawnedEnemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
