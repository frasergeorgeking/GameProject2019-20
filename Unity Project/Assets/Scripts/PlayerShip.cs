﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;
    [SerializeField] float bulletSpeed = 15f;

    private GameObject bullet;
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Player Controller Movement
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        //Pull bullet reference from pooler
        bullet = ObjectPooler.sharedInstance.GetPooledObject("bullet");

        if (bullet != null)
        {
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true);
            Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            Rigidbody2D bulletSpawnedrb = bullet.GetComponent<Rigidbody2D>();
            bulletSpawnedrb.velocity = new Vector2(bulletSpeed + direction.x, 0);
        }
    }
}
