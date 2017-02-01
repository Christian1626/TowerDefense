using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    [HideInInspector]
    public float speed;
    public float startSpeed = 10f;

    public float startHealth = 100;
    private float currentHealth;
    public int moneyGain = 30;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;
    public Color FullHealth;
    public Color MediumHealth;
    public Color LowHealth;


    void Start()
    {
        speed = startSpeed;
        currentHealth = startHealth;
    }

    public void TakeDamage(float amount)
    {
        //Debug.Log("LIFE:"+health+" - bullet damage: " + amount);
        currentHealth -= amount;

        float healthPercent = currentHealth * 100 / startHealth;
        if (healthPercent > 75)
        {
            healthBar.color = FullHealth;
        } else if(currentHealth <= 75 && currentHealth > 35)
        {
            healthBar.color = MediumHealth;
        } else
        {
            healthBar.color = LowHealth;
        }

        healthBar.fillAmount = currentHealth / startHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        //Debug.Log("DIE");
        PlayerStats.Money += moneyGain;
        Destroy(gameObject);
    }

    public void Slow(float slow)
    {
        speed = startSpeed * (1f - slow);
    }
}
