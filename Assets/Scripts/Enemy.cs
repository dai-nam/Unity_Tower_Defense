using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Path path;
    Vector3 yOffest;
   [Range (0f, 10f)] [SerializeField] float speed = 1f;
    public delegate void FinishedPath(Enemy enemy);
    public event FinishedPath OnFinishedPath;


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
        print(gameObject + " finished the path");
        OnFinishedPath?.Invoke(this);
        Destroy(gameObject);
    }

}
