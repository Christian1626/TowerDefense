using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TowerAbstract : MonoBehaviour
{
    protected Transform target;
    protected Enemy targetEnemy;

    [Header("General")]
    public string name;
    public float turnSpeed = 10f;
    public float range = 15f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;
    public Transform firePoint;

    void Start()
    {
        //update target toutes les 500ms
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        Initialize();
    }

    public abstract void Initialize();

    /* Gère l'orientation de la tour */
    protected void LockOnTarget()
    {
       
        //direction
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //smooth rotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //rotate sur y
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    /* Affiche la range de la tour */
    protected void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    protected void UpdateTarget()
    {
        //recupère tous les ennemies avec le tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //check la target la plus proche
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //selectionne la target
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
}