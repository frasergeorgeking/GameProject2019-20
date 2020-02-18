using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInterceptor : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 50f)] float speed = 15f;
    [SerializeField] [Range(1, 15)] int health = 4;
    [SerializeField] [Range(1, 20)] int damageToPlayer = 1;
    [SerializeField] float playerDistanceBuffer; //Defines the distance between the player and enemy
    [SerializeField] [Range(0.1f, 5f)] float minFireDelay = 0.3f;
    [SerializeField] [Range(0.1f, 5f)] float maxFireDelay = 2.5f;
    [SerializeField] GameObject bullet;

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

    void HandleMovement()
    {
        //Handle Rotation
        Vector3 rotDiff = player.transform.position - transform.position;
        float atan2 = Mathf.Atan2(rotDiff.x, rotDiff.y);
        transform.rotation = Quaternion.Euler(0f, 0f, -atan2 * Mathf.Rad2Deg);

        //Handle Movement
       
    }


}
