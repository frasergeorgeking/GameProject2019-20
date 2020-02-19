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
    [SerializeField] [Range(0.1f, 5f)] float shootCooldown = 2.5f;

    //Private Variables
    private GameObject player;
    private PolygonCollider2D col;
    private Rigidbody2D rb;
    private bool canShoot = true;
    private GameObject bullet;

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
        
        //Perform canShoot Check
        if (canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    void HandleMovement()
    {
        //Handle Rotation
        Vector3 rotDiff = player.transform.position - transform.position;
        float atan2 = Mathf.Atan2(rotDiff.x, rotDiff.y);
        transform.rotation = Quaternion.Euler(0f, 0f, -atan2 * Mathf.Rad2Deg);

        //Handle Movement
        if(Vector2.Distance(transform.position, player.transform.position) > playerDistanceBuffer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }  
    }

    void FireBullet()
    {
        //Pull bullet Reference from Pooler
        bullet = ObjectPooler.sharedInstance.GetPooledObject("interceptorBullet");

        if (bullet != null) //Peform Null-Check on bullet
        {
            //Set bullet position & rotation to that of player character
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = gameObject.transform.rotation;
            bullet.SetActive(true); //Spawn Bullet
            Physics2D.IgnoreCollision(bullet.GetComponent<CircleCollider2D>(), GetComponent<PolygonCollider2D>()); //Create collision exception for bullet col & interceptor col

            //Pull Reference to Neccesary bullet Components
            Rigidbody2D bulletSpawnedRB = bullet.GetComponent<Rigidbody2D>();
            InterceptorBullet bulletInteceptorBullet = bullet.GetComponent<InterceptorBullet>();

            //Set bullet velocity
            Vector2 newShootPos = new Vector2(player.transform.position.x, player.transform.position.y);
            bulletSpawnedRB.velocity = new Vector2((newShootPos.x * bulletInteceptorBullet.GetBulletSpeed()), (newShootPos.y * bulletInteceptorBullet.GetBulletSpeed()));
        }
    }

    IEnumerator Shoot()
    {
        FireBullet();
        canShoot = false;

        yield return new WaitForSeconds(shootCooldown); //Cooldown on Shoot        
        canShoot = true;
    }

}
