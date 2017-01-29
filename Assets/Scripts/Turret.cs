using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float turnSpeed = 10f;

    [Header("Use Bullets (default)")]
    public float fireRate = 1f;
    public float range = 15f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool userLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem laserImpactEffect;
    public Light laserImpactLight;
    public int damageOverTime = 40;
    public float laserSlow = .1f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint;

    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget",0f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            if(userLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserImpactEffect.Stop();
                    laserImpactLight.enabled = false;
                }
            }
            return;
        }

        LockOnTarget();

        if(userLaser)
        {
            //laser
            Laser();
        } else
        {
            //bullet
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }

    }

    void Laser()
    {
        
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(laserSlow);

        if(!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserImpactEffect.Play();
            laserImpactLight.enabled = true;
        }
            
        //position de départ
        lineRenderer.SetPosition(0, firePoint.position);
        //position d'arrivée
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        //direction de l'impact
        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);

        //position de l'impact sur l'enemmi
        laserImpactEffect.transform.position = target.position + dir.normalized*(target.localScale.z/2);
    }

    void LockOnTarget()
    {
        //direction
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //smooth rotation
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //rotate sur y
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        //recupère tous les ennemies avec le tag "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        //check la target la plus proche
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //selectionne la target
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        } else
        {
            target = null;
        }
    }
}
