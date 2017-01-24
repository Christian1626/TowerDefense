using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    public float fireRate = 1f;
    private float fireCountdown = 0f;
     
    void Start()
    {
        target = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {
        //l'ennemie se dirife vers le waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //si on a atteint le waypoint
        if(Vector3.Distance(transform.position,target.position) <= 1f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex == Waypoints.waypoints.Length-1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
}
