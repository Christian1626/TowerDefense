using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningTower : TowerAbstract
{
    [Header("Lightning Stuff")]
    public int damageOverTime = 40; 
    public float laserSlow = .1f;

    public ParticleSystem lineRenderer;
    public ParticleSystem laserImpactEffect;
    public Light laserImpactLight;

    public override void Initialize()
    {
        laserImpactEffect.Stop();
        lineRenderer.Stop();
    }

    void Update()
    {

        if (target == null)
        {
            laserImpactEffect.Stop();
            lineRenderer.Stop();
            laserImpactLight.enabled = false;
            return;
        }

        lineRenderer.Play();
        lineRenderer.transform.LookAt(targetEnemy.transform);


        LockOnTarget();
        Laser();
    }

    void Laser()
    {
        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(laserSlow, 1);

        lineRenderer.transform.position = Vector3.Lerp(firePoint.transform.position, transform.position, 0f);
        laserImpactEffect.Play();
        laserImpactLight.enabled = true;

        //position de départ
        //lineRenderer.SetPosition(0, firePoint.position);
        //position d'arrivée
        //lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

    //direction de l'impact
    laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);

        //position de l'impact sur l'enemmi
        laserImpactEffect.transform.position = target.position + dir.normalized* (target.localScale.z / 2);
    }
}