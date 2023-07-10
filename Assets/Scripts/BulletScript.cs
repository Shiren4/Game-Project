using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float force;
    private Vector3 mousePos; 
    private Camera mainCam; 
    private Rigidbody2D rb; 
     

    private void Start()
    {
        mainCam = Camera.main; 
        rb = GetComponent<Rigidbody2D>(); 
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // Pozycja myszy w grze
        Vector3 direction = mousePos - transform.position; 
     
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; // Ustawienie prêdkoœci pocisku na podstawie kierunku i si³y
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)) 
        {
            enemyComponent.TakeDamage(PlayerStats.Instance.damage); // Wywo³anie metody TakeDamage() na obiekcie Enemy
        }
        Destroy(gameObject); 
    }
}