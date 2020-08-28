using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Path path;
    Vector3 yOffest;
   [Range (0f, 10f)] [SerializeField] float speed = 1f;
    public event Action OnPathFinished;

    void Start()
    {
        path = FindObjectOfType<Path>();
        yOffest = new Vector3(0, transform.position.y, 0);
        transform.position = path.waypoints[0].transform.position+yOffest;
        StartCoroutine(MoveEnemy());

    }



 

    IEnumerator MoveEnemy()
    {
        foreach(Tile wp in path.waypoints)
        {
            transform.position = wp.transform.position+ yOffest;
            yield return new WaitForSeconds(speed);
        }

        PathFinished();
    }

    private void PathFinished()
    {
        print(gameObject + " finished the path");
        OnPathFinished?.Invoke();
        Destroy(gameObject);
    }

}
