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
                playerStats.score += 25;
                playerStats.AddKill();
            }
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        health = maxHealth;
        playerStats = PlayerStats.Instance;       
    }
}