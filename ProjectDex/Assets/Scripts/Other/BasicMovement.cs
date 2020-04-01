using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(0f, 20f)] float speed;
    
    //Private Variables
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed; //Move upwards according to speed variable
    }
}
