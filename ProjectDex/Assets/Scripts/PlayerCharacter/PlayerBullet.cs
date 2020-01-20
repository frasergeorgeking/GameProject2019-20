using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(1f, 30f)] float bulletSpeed;
    
    //Private Variables
    private Rigidbody2D bulletRB;

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public void SetBulletSpeed(float newBulletSpeed)
    {
        bulletSpeed = newBulletSpeed;
    }

}