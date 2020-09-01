using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType Type { get; set; }
    
    public int StepsTaken { get; set; }
    static int numEnemies;
    [SerializeField] private int id;
    Path path;
    Vector3 yOffest;
    [Range(0f, 5f)] [SerializeField] float speed = 0.8f;
    public bool isTarget;
    public int healthPoints = 8;

    public static event Action<Enemy> OnFinishedPath;
    public static event Action<Enemy> OnGotKilled;


    private void Awake()
    {
        id = ++numEnemies;
    }

    void Start()
    {
        yOffest = new Vector3(0, transform.localScale.y, 0);
        transform.position += yOffest;
        StartCoroutine(MoveEnemy());
        SetTypeSpecificProperties();
    }

    //todo weitere Properties typspezfisch -> zur Laufzeit änderbar -> in EnemyProperty Klasse auslagern. Enemy kann dann mit Remove und AddComponent seinen Typ zur Laufzeit ändern
    private void SetTypeSpecificProperties()                                                                 
    {
        switch (Type)
        {
            case EnemyType.Slow:
                SetEnemyColor(Color.red);
                break;
            case EnemyType.Fast:
                SetEnemyColor(Color.blue);
                speed /= 2;
                break;
        }
    }

    private void SetEnemyColor(Color color)
    {
        GetComponent<Renderer>().material.SetColor("_Color", color);
    }

    public int GetID()
    {
        return this.id;
    }

    IEnumerator MoveEnemy()
    {
        foreach(Tile waypoint in FindObjectOfType<Path>().GetWaypoints())
        {
            transform.position = waypoint.transform.position+ yOffest;
            StepsTaken++;
            yield return new WaitForSeconds(speed);
        }
        TriggerFinishEvent();
    }

    private void TriggerFinishEvent()
    {
        OnFinishedPath?.Invoke(this);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(--healthPoints <= 0)
        {
            OnGotKilled?.Invoke(this);
        }
    }


}
