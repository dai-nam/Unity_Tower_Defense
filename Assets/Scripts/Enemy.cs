using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Path path;
    Vector3 yOffest;
    public float speed;
    public bool isTarget;
    public int healthPoints = 3;

    public static event Action<Enemy> OnFinishedPath;
    public static event Action<Enemy> OnGotKilled;



    void Start()
    {
        path = FindObjectOfType<Path>();
        yOffest = new Vector3(0, transform.localScale.y, 0);
        transform.position += yOffest;
        StartCoroutine(MoveEnemy());
    }

    IEnumerator MoveEnemy()
    {
        foreach(Tile wp in path.GetWaypoints())
        {
            transform.position = wp.transform.position+ yOffest;
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
