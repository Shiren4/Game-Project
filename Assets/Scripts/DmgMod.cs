using UnityEngine;

public class DmgMod : MonoBehaviour
{
    public int damage = 10;
    public float attackInterval = 1f; // Częstotliwość ataków przeciwnika
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                InvokeRepeating("AttackPlayer", 0f, attackInterval);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CancelInvoke("AttackPlayer");
        }
    }

    private void AttackPlayer()
    {
        PlayerStats playerStats = PlayerStats.Instance;
        if (playerStats != null)
        {
            playerStats.TakeDamage(damage);
            Debug.Log("Gracz otrzymuje obrażenia: " + damage);
        }
    }
}