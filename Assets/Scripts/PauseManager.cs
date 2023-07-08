using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI DamagePriceText;
    [SerializeField]
    private TextMeshProUGUI SpeedPriceText;

    private bool isPaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f; // Zatrzymaj czas w grze
        pauseMenu.SetActive(true); // Wyświetl menu pauzy
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Wznów czas w grze
        pauseMenu.SetActive(false); // Ukryj menu pauzy
    }

    public void UpgradeDMG()
        
    {
        if (PlayerStats.Instance.gold >= PlayerStats.Instance.requiredGoldForDmg)
        {
            PlayerStats.Instance.damage += 1;
            PlayerStats.Instance.ExchangeGoldForStat(PlayerStats.UpgradeStat.Damage);
            PlayerStats.Instance.IncreaseGoldForStats(PlayerStats.UpgradeStat.Damage);
            DamagePriceText.text = string.Format("Price: {0} GOLD", PlayerStats.Instance.requiredGoldForDmg.ToString());
        }
              
    }

    public void UpgradeSpeed()
    {
        if (PlayerStats.Instance.gold >= PlayerStats.Instance.requiredGoldForSpeed)
        {
            PlayerStats.Instance.moveSpeed += 0.5f;
            PlayerStats.Instance.ExchangeGoldForStat(PlayerStats.UpgradeStat.Speed);
            PlayerStats.Instance.IncreaseGoldForStats(PlayerStats.UpgradeStat.Speed);
            SpeedPriceText.text = string.Format("Price: {0} GOLD", PlayerStats.Instance.requiredGoldForSpeed.ToString());
        }

    }

    public void Exit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);                     
    }



    private void Start()
    {
        pauseMenu.SetActive(false); // Wyłącz menu pauzy na starcie gry
        DamagePriceText.text = string.Format("Price: {0} GOLD",PlayerStats.Instance.requiredGoldForDmg.ToString());
        SpeedPriceText.text = string.Format("Price: {0} GOLD", PlayerStats.Instance.requiredGoldForSpeed.ToString());
    }
}