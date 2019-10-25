using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] [Range (1, 8)] float enemySpeed = 3f;
    [SerializeField] [Range (1, 10)] int enemyHealth = 3;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1f * enemySpeed, 0f);
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            other.gameObject.SetActive(false); //Recycle Bullet Back into Object Pool
            enemyHealth--;

            if (enemyHealth <= 0)
            {
                Destroy(gameObject); //**UPDATE LATER TO INTEGRATE IN OBJECT POOL**
            }
        }
    }
}
