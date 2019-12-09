using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Collider2D col;

    void Awake()
    {
        col = gameObject.GetComponent<Collider2D>();
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(col, other.gameObject.GetComponent<Collider2D>());    
        }
    }
}
