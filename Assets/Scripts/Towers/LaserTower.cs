using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTower : TowerAbstract
{
    [Header("Laser Stuff")]
    public int damageOverTime = 40;
    public float laserSlow = .1f;

    public LineRenderer lineRenderer;
    public ParticleSystem laserImpactEffect;
    public Light laserImpactLight;

    public override void Initialize()
    {
        laserImpactEffect.Stop();
    }

    void Update()
    {

        if (target == null) {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
                laserImpactEffect.Stop();
                laserImpactLight.enabled = false;
            }
            return;
        }

        LockOnTarget();
        Laser();
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(laserSlow,1);

        if (!lineRenderer.enabled)
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
        laserImpactEffect.transform.position = target.position + dir.normalized * (target.localScale.z / 2);
    }
}