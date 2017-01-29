using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;

    public float health = 100;
    public int moneyGain = 30;

    public GameObject deathEffect;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        Debug.Log("LIFE:"+health+" - bulelt damage: " + amount);
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Debug.Log("DIe");
        PlayerStats.Money += moneyGain;
        Destroy(gameObject);
    }

    public void Slow(float slow)
    {
        speed = startSpeed * (1f - slow);
        Debug.Log("speed:"+speed);
    }
}
