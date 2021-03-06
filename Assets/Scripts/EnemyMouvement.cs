﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMouvement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    //modèle de l'ennemy
    public Transform model;

    void Start()
    {
        //recupère l'enemmi du component
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {

        model.transform.LookAt(target);

        //l'ennemie se dirige vers le waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //si on a atteint le waypoint
        if (vector2DDistance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    private float vector2DDistance(Vector3 v1, Vector3 v2)
    {
        float xDiff = v1.x - v2.x;
        float zDiff = v1.z - v2.z;
        return Mathf.Sqrt((xDiff * xDiff) + (zDiff * zDiff));
    }


    void ResetSpeed()
    {
        enemy.speed = enemy.startSpeed;
    }

    //Check le prochain waypoint
    void GetNextWaypoint()
    {
        //quand l'ennemy arrive a la fin
        if (wavepointIndex == Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
        WaveSpawner.EnemiesAlive--;
    }
}
