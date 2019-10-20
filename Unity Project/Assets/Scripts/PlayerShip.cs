using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 15f;

    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
        Debug.Log("Bullet Fired"); //Debug Line
        
        //Spawn Bullet, Disable Collision w/ PC & Give Velocity
        var bulletSpawned = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Physics2D.IgnoreCollision(bulletSpawned.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D bulletSpawnedrb = bulletSpawned.GetComponent<Rigidbody2D>();
        bulletSpawnedrb.velocity = new Vector2(bulletSpeed + direction.x, 0);

    }

}
