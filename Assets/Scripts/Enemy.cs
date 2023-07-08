using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 3f;
    public int goldReward = 10;

    private PlayerStats playerStats;

    private void Start()
    {
        health = maxHealth;
        playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats == null)
        {
            Debug.LogWarning("Nie znaleziono komponentu PlayerStats w scenie.");
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            if (playerStats != null)
            {
                playerStats.AddGold(goldReward);
                PlayerStats.Instance.score += 23;
                playerStats.AddKill(); // Dodanie zabójstwa do licznika gracza
            }
            Destroy(gameObject);
        }
    }
}