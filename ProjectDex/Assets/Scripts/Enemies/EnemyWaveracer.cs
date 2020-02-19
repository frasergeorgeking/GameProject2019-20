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

    void Awake()
    {
        //Define Variables
        player = GameObject.FindGameObjectWithTag("player");
        col = GetComponent<PolygonCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

    }

    private void HandleMovement()
    {
        
        
        //Clamp Enemy Position to Arena Boundary
        rb.position = new Vector2
            (
            Mathf.Clamp(rb.position.x, (ArenaScaler.Instance.GetArenaBoundary("minX") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxX") - ArenaScaler.Instance.GetColliderBufferSize())),
            Mathf.Clamp(rb.position.y, (ArenaScaler.Instance.GetArenaBoundary("minY") + ArenaScaler.Instance.GetColliderBufferSize()), (ArenaScaler.Instance.GetArenaBoundary("maxY") - ArenaScaler.Instance.GetColliderBufferSize()))
            );
    }

    private void CalculateTargetPos()
    {
        
    }



}
