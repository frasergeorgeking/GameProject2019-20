using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(1f, 30f)] float bulletSpeed;
    [SerializeField] [Range(1, 10)] int damage = 1;
    
    //Private Variables
    private Rigidbody2D bulletRB;

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }

    public int GetBulletDamage()
    {
        return damage;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    public void SetBulletDamage(int newBulletDamage)
    {
        damage = newBulletDamage;
    }

    public void SetBulletSpeed(float newBulletSpeed)
    {
        bulletSpeed = newBulletSpeed;
    }

}