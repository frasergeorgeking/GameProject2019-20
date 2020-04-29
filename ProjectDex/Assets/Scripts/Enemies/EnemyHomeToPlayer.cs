using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomeToPlayer : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 75f)] float speed = 15f;
    [SerializeField] [Range(1, 15)] int health = 6;
    [SerializeField] [Range(1, 20)] int damageToPlayer = 1;

    //Private Variables
    private GameObject player;
    private PolygonCollider2D col;
    private Rigidbody2D rb;
    private float arenaBufferSize; //Arena varibles used to track reference to arena size (arena dimensions can differ)
    private float arenaMinX; 
    private float arenaMaxX;
    private float arenaMinY;
    private float arenaMaxY;

    void Awake()
    {
        //Define Variables
        player = GameObject.FindGameObjectWithTag("player");
        col = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //Define Arena Dimensions - Must be Performed in Start() as ArenaScaler Calculates Offsets in Awake()
        arenaBufferSize = ArenaScaler.Instance.GetColliderBufferSize();
        arenaMinX = ArenaScaler.Instance.GetArenaBoundary("minX");
        arenaMaxX = ArenaScaler.Instance.GetArenaBoundary("maxX");
        arenaMinY = ArenaScaler.Instance.GetArenaBoundary("minY");
        arenaMaxY = ArenaScaler.Instance.GetArenaBoundary("maxY");
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "playerBullet")
        {
            ReduceHealth(other.gameObject.GetComponent<PlayerBullet>().GetBulletDamage()); //Reduce enemy health
            other.gameObject.SetActive(false); //Recycle bullet back into pooler
        }

        if (other.gameObject.tag == "player")
        {
            player.GetComponent<PlayerController>().TakeDamage(damageToPlayer); //Deal damage to the player
            gameObject.SetActive(false); //Destroy self
            CalculateFixedRatioReward.Instance.IncrementCurrentX();//Increment Current X Value
        }

    }

    private void HandleMovement()
    {
        //Clamp Enemy Position to Arena Boundary
        rb.position = new Vector2
            (
                Mathf.Clamp(rb.position.x, (arenaMinX + arenaBufferSize), (arenaMaxX - arenaBufferSize)),
                Mathf.Clamp(rb.position.y, (arenaMinY + arenaBufferSize), (arenaMaxY - arenaBufferSize))
            );


        //Handle Rotation        
        transform.up = player.transform.position - transform.position;

        //Apply RigidBody Force
        rb.AddForce(transform.up * speed, ForceMode2D.Force); //transform.up used as rotation should always match that of the player
    }

    public void ReduceHealth(int damageDealt)
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            CalculateFixedRatioReward.Instance.IncrementCurrentX();//Increment Current X Value
        }
        
        health = health - damageDealt;
    }

}
