using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; private set; }
    public int damage = 3;
    public int maxHealth = 100;
    public int currentHealth;
    public int gold = 0;
    public int killCount = 0;
    public float moveSpeed = 1.5f;
    public int requiredGoldForSpeed = 80;
    public int requiredGoldForDmg = 150;
    public int score = 0;
    public enum UpgradeStat
    {
        Damage,
        Speed  
    }
    private void Start()
    {      
        currentHealth = maxHealth;
    }
    public void ExchangeGoldForStat(UpgradeStat stat)

    {
        switch (stat)
        {
            case UpgradeStat.Damage:
                gold -= requiredGoldForDmg;
                break;
            case UpgradeStat.Speed:
                gold -= requiredGoldForSpeed;
                break;
        }
    }
    public void IncreaseGoldForStats(UpgradeStat stat)
    {
        switch (stat)
        {
            case UpgradeStat.Damage:
                requiredGoldForDmg = (int)(requiredGoldForDmg * 1.2f);
                break;
                case UpgradeStat.Speed:
                requiredGoldForSpeed = (int)(requiredGoldForSpeed * 1.2f);
                break;             

        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void AddGold(int amount)
    {
        gold += amount;
    }

    public void AddKill()
    {
        killCount++;
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Die()
    {
        Debug.Log("Gracz zginął");
        SceneManager.LoadScene("Menu");
    }
}