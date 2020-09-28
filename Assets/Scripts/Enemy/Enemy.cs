using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyProperties properties;
    public int StepsTaken { get; set; }
    static int numEnemies;
    [SerializeField] private int id;
    Path path;
    Vector3 yOffest;
    Vector3 positionOffset;
    [SerializeField] ParticleSystem enemyDeathFX;

    public static event Action<Enemy> OnFinishedPath;
    public static event Action<Enemy> OnGotKilled;
    public static event Action<Enemy> OnHitByBullet;


    private void Awake()
    {
        id = ++numEnemies;
        yOffest = new Vector3(0, transform.localScale.y, 0);
        transform.position += yOffest;
        float maxOffest = 3f;
        positionOffset = new Vector3(UnityEngine.Random.Range(-maxOffest, maxOffest), 0, UnityEngine.Random.Range(-maxOffest, maxOffest));
        transform.position += positionOffset;       //damit wenn sich mehrere Enemies überlagern auch mehr sichtbar sind
    }

    void Start()
    {
        StartCoroutine(MoveEnemy());
    }



    //todo weitere Properties typspezfisch -> zur Laufzeit änderbar -> in EnemyProperty Klasse auslagern. Enemy kann dann mit Remove und AddComponent seinen Typ zur Laufzeit ändern
    public void InitTypeProperties(EnemyProperties.EnemyType type)                                                                 
    {
        switch (type)
        {
            case EnemyProperties.EnemyType.SLOW:
                properties = gameObject.AddComponent<SlowEnemy>();
                break;
            case EnemyProperties.EnemyType.FAST:
                properties = gameObject.AddComponent<FastEnemy>();
                break;
        }
    }


    public int GetID()
    {
        return this.id;
    }

    IEnumerator MoveEnemy()
    {
        WaitForSeconds wfs = new WaitForSeconds(properties.speed);
        foreach (Tile waypoint in FindObjectOfType<Path>().GetWaypoints())
        {
            transform.position = waypoint.transform.position+ yOffest + positionOffset;
            StepsTaken++;
            yield return wfs;
        }
        TriggerFinishEvent();
    }

    private void TriggerFinishEvent()
    {
        OnFinishedPath?.Invoke(this);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(--properties.enemyHealth <= 0)
        {
            Instantiate(enemyDeathFX, this.transform.position, Quaternion.identity);
            OnGotKilled?.Invoke(this);
            return;
        }
        OnHitByBullet?.Invoke(this);
    }

    public EnemyProperties.EnemyType GetEnemyType()
    {
        return this.properties.type;
    }

    public int GetKillBonus()
    {
        return this.properties.killBonus;
    }
    public int GetDamagePlayerHealth()
    {
        return this.properties.damagePlayerHealth;
    }



}
