using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartTower : TowerAbstract
{
    [Header("Standart tower suff")]
    public float fireRate = 1f;
    public GameObject bulletPrefab;

    //temps restant avant le prochain shoot
    private float fireCountdown = 0f;

    public override void Initialize()
    {

    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        LockOnTarget();

        //gère le shoot
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    /* Instancie la bullet */
    public void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }


}