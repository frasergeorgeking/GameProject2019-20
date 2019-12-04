using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] float shootCooldown = 0.06f;
    [SerializeField] int playerHealth = 3;
    [SerializeField] float hitProtection = 1f;

    private GameObject bullet;
    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool canShoot = true;
    private bool canBeHit = true;

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

        if (Input.GetMouseButton(0))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
            }
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
            bulletSpawnedrb.velocity = new Vector2(0, direction.y + bulletSpeed);
        }
    }

    public void ReduceHealth(int damage)
    {
        if (canBeHit)
        {
            StartCoroutine(HitProtection());

            playerHealth = playerHealth - damage;

            if (playerHealth <= 0)
            {
                gameObject.SetActive(false); //Update to pull gameover screen
            }

        }

    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    IEnumerator Shoot()
    {
        //Run Firing Logic
        FireBullet();
        canShoot = false;

        //Cooldown
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }

    IEnumerator HitProtection()
    {
        canBeHit = false;

        yield return new WaitForSeconds(hitProtection);
        canBeHit = true;
    }

}
