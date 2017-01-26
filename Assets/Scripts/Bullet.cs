using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius;

    public void Seek(Transform _target)
    {
        target = _target;
    }

	void Update () {
        //detruit la bullet si la target n'existe plus
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        //direction
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //Quand on touche une cible
        //dir.manitude est la distance entre la tour et la bullet
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

	}

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        if(explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }
        Destroy(gameObject);
        Destroy(target.gameObject);
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

}
