using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    public Text statsText;
  

    private void Start()
    {               
        {
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        string stats = "Health: " + PlayerStats.Instance.currentHealth.ToString() +
            "\nDamage: " + PlayerStats.Instance.damage.ToString() +
            "\nSpeed: " + PlayerStats.Instance.moveSpeed.ToString() +
            "\nGold: " + PlayerStats.Instance.gold.ToString() +
            "\nKill Count: " + PlayerStats.Instance.killCount.ToString(); // Dodanie licznika zabójst

        statsText.text = stats;
    }

    private void Update()
    {       
        {
            UpdateUI();
        }
    }
}