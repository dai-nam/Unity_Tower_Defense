using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootingBehaviour : MonoBehaviour
{
    TowerProperty towerProperties;
    List<Enemy> enemies;
    public delegate void Fire(Enemy enemy);
    public event Fire OnFire;

    private void Awake()
    {
        enemies = EnemyFactory.spawnedEnemies;
    }

    void Start()
    {
     //   towerProperties = GetComponent<TowerProperty>();
        StartCoroutine(FireEventCoroutine());
    }

   public void SetTowerPropertyReference(TowerProperty tp)
    {
        towerProperties = tp;
    }


    IEnumerator FireEventCoroutine ()
    {
        while (true)
        {
            //erkundigt sich alle shootSpeed Sekunden nach dem Target und feuert das Event ab. Wenn kein Enemy mehr vorhanden ist und ein neuer gespawnt wird während man wartet, gibt es eine Verzögerung,
            // bis das neue Target erfasst wird, weil dies erst im nächsten Schleifendruchlauf nach der Wartezeit geschieht. Es wird sich immer erkundigt, auch wenn enemy.Count leer ist
            OnFire?.Invoke(GetTargetEnemy(towerProperties.shootTarget));
            yield return new WaitForSeconds(1/towerProperties.shootSpeed);     //nicht cachen, weil shootspeed sich je nach Level ändert   
        }
    }


    public Enemy GetTargetEnemy(ShootTarget shootAt)
    {
        if (enemies.Count == 0)
        {
            return null;
        }

        switch (shootAt)
        {
            case ShootTarget.FIRST:
                return GetMostAdvancedEnemy(enemies);
            case ShootTarget.LAST:
                return GetLeastAdvancedEnemy(enemies);
            case ShootTarget.OLDEST:
                return GetOldestEnemy(enemies);
            case ShootTarget.RANDOM:
                return GetRandomEnemy(enemies);
            default:
                return GetMostAdvancedEnemy(enemies);

        }
    }

    private Enemy GetMostAdvancedEnemy(List<Enemy> _enemies)
    {
       
        int maxSteps = _enemies.Max(enemy => enemy.StepsTaken);
        List<Enemy> mostAdvancedEnemies = _enemies.Where(enemy => enemy.StepsTaken == maxSteps).ToList();

        if (mostAdvancedEnemies.Count == 1)
        {
            return mostAdvancedEnemies[0];
        }
        else
        {
            return GetOldestEnemy(mostAdvancedEnemies);
        }
    }

    private Enemy GetLeastAdvancedEnemy(List<Enemy> _enemies)
    {
   
        int leastSteps = _enemies.Min(enemy => enemy.StepsTaken);
        List<Enemy> leastAdvancedEnemies = _enemies.Where(enemy => enemy.StepsTaken == leastSteps).ToList();

        if (leastAdvancedEnemies.Count == 1)
        {
            return leastAdvancedEnemies[0];
        }
        else
        {
            return GetOldestEnemy(leastAdvancedEnemies);
        }
    }

    private Enemy GetOldestEnemy(List<Enemy> _enemies) //Immer den ältestten falls mehrere an der gleichen Stelle sind
    {
        int oldest = _enemies.Min(enemy => enemy.GetID());
        return _enemies.Find(enemy => enemy.GetID() == oldest);
    }

    private Enemy GetRandomEnemy(List<Enemy> _enemies) //Immer den ältestten falls mehrere an der gleichen Stelle sind
    {
        int randomIndex = UnityEngine.Random.Range(0, _enemies.Count - 1);
        Debug.Log(randomIndex);
        return _enemies[randomIndex];
    }
}
