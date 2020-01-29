using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeToPlayer : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 50f)] float speed = 15f;
    [SerializeField] [Range(1, 15)] int health = 6;
    [SerializeField] [Range(1, 20)] int damageToPlayer = 1;

    //Private Variables
    private GameObject player;
    private PolygonCollider2D col;
    private Rigidbody2D rb;

    void Awake()
    {
        //Define Variables
        player = GameObject.FindGameObjectWithTag("player");
        col = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "playerBullet")
        {
            ReduceHealth(other.gameObject.GetComponent<PlayerBullet>().GetBulletDamage()); //Reduce enemy health
            other.gameObject.SetActive(false); //Recycle bullet back into pooler
        }

        if (other.gameObject.tag == "player")
        {
            player.GetComponent<PlayerController>().TakeDamage(damageToPlayer); //Deal damage to the player
            gameObject.SetActive(false); //Destroy self
        }

    }

    private void HandleMovement()
    {
        //Handle Rotation        
        transform.up = player.transform.position - transform.position;

        //Apply RigidBody Force
        rb.AddForce(transform.up * speed, ForceMode2D.Force); //transform.up used as rotation should always match that of the player
    }

    public void ReduceHealth(int damageDealt)
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        
        health = health - damageDealt;
    }

}
