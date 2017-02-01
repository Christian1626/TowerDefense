using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMouvement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    void Start()
    {
        //recupère l'enemmi du component
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[wavepointIndex];
    }

    void Update()
    {
        //l'ennemie se dirife vers le waypoint
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        //si on a atteint le waypoint
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

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
    }
}
