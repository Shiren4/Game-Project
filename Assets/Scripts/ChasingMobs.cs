using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingMobs : MonoBehaviour

{
    public float speed;
    private GameObject player;
 
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);   
    }
}
