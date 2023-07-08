using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;   

    private void Start()
    {
        healthSlider.maxValue = PlayerStats.Instance.maxHealth;
        healthSlider.value = PlayerStats.Instance.currentHealth;
    }

    private void Update()
    {
        healthSlider.value = PlayerStats.Instance.currentHealth;
    }
}