using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(300f, 1250f)] float bulletSpeed = 15f;
    [SerializeField] [Range(1, 10)] int damage = 1;
    
    //Private Variables
    private Rigidbody2D bulletRB;
    private TrailRenderer bulletTrailRen;

    void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        bulletTrailRen = GetComponent<TrailRenderer>();
    }

    void OnEnable()
    {
        bulletTrailRen.enabled = true;
        bulletTrailRen.Clear(); //Clear bullet trail renderer on start
    }

    void OnDisable()
    {
        bulletTrailRen.Clear();
        bulletTrailRen.enabled = false;
    }

    //Getter Functions
    public int GetBulletDamage()
    {
        return damage;
    }

    public float GetBulletSpeed()
    {
        return bulletSpeed;
    }

    //Setter Functions
    public void SetBulletDamage(int newBulletDamage)
    {
        damage = newBulletDamage;
    }

    public void SetBulletSpeed(float newBulletSpeed)
    {
        bulletSpeed = newBulletSpeed;
    }

}