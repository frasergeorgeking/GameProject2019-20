using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveracer : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(2f, 50f)] float speed = 20f;
    [SerializeField] [Range(1, 15)] int health = 6;
    [SerializeField] [Range(1, 20)] int damageToPlayer = 1;
    [SerializeField] [Range(0.1f, 5f)] float shootCooldown = 2.5f;

    //Private Variables
    private GameObject player;
    private PolygonCollider2D col;
    private Rigidbody2D rb;
    private bool canShoot = false;
    private GameObject bullet;
    private Vector2 targetPos;
    private bool maxTargetReached = false;
    private bool minTargetReached = false;

    public enum waveracerDirection
    {
        horizontal,
        vertical
    }

    private waveracerDirection desiredDirection;

    void Awake()
    {
        //Define Variables
        player = GameObject.FindGameObjectWithTag("player");
        col = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SelectDirection(); //Select direction for waveracer
        CalculateTargetPos("max");
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (new Vector2(transform.position.x, transform.position.y) == targetPos)
        {
            //do stuff
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        
        //Clamp Enemy Position to Arena Boundary
        rb.position = new Vector2
            (
            Mathf.Clamp(rb.position.x, (ArenaScaler.Instance.GetArenaBoundary("minX") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxX") - ArenaScaler.Instance.GetColliderBufferSize())),
            Mathf.Clamp(rb.position.y, (ArenaScaler.Instance.GetArenaBoundary("minY") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxY") - ArenaScaler.Instance.GetColliderBufferSize()))
            );
    }

    private void CalculateTargetPos(string maxOrMin)
    {
        switch (desiredDirection)
        {
            case (waveracerDirection.horizontal):
                if (maxOrMin == "max")
                {
                    targetPos = new Vector2(gameObject.transform.position.x, ArenaScaler.Instance.GetArenaBoundary("maxY") - 1);
                }
                
                if (maxOrMin == "min")
                {
                    targetPos = new Vector2(gameObject.transform.position.x, ArenaScaler.Instance.GetArenaBoundary("minY") - 1);
                }
                
                break;

            case (waveracerDirection.vertical):
                if (maxOrMin == "max")
                {
                    targetPos = new Vector2(ArenaScaler.Instance.GetArenaBoundary("maxX") - 1, gameObject.transform.position.y);
                }

                if (maxOrMin == "min")
                {
                    targetPos = new Vector2(ArenaScaler.Instance.GetArenaBoundary("minX") - 1, gameObject.transform.position.y);
                }
                break;
        }
    }

    private void SelectDirection()
    {
        float randValue = Random.value; //Effectively flips a pseudo-random coin

        if (randValue < 0.5f)
        {
            desiredDirection = waveracerDirection.horizontal; //Set Direction to Horizontal
        }

        else
        {
            desiredDirection = waveracerDirection.vertical; //Set Direction to Vertical
        }
    }


}
