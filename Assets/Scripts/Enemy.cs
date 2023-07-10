using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int goldReward = 10;
    [SerializeField] float health, maxHealth = 3f;

    private PlayerStats playerStats;
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            if (playerStats != null)
            {
                playerStats.AddGold(goldReward);
                playerStats.score += 23;
                playerStats.AddKill(); // Dodanie zabójstwa do licznika gracza
            }
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        health = maxHealth;
        playerStats = PlayerStats.Instance;
        if (playerStats == null)
        {
            Debug.LogWarning("Nie znaleziono komponentu PlayerStats w scenie.");
        }
    }

}