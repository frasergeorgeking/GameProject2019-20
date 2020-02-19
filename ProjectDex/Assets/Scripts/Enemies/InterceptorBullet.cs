using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterceptorBullet : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(1f, 30f)] float bulletSpeed = 15f;
    [SerializeField] [Range(1, 10)] int damage = 1;

    //Private Variables
    private CircleCollider2D col;
    private GameObject player;

    void Awake()
    {
        //Pull References
        col = GetComponent<CircleCollider2D>();
        player = GameObject.FindGameObjectWithTag("player");
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

    public void SetBulletSpeeed(float newBulletSpeed)
    {
        bulletSpeed = newBulletSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "player")
        {
            player.GetComponent<PlayerController>().TakeDamage(damage); //Deal damage to the player
            gameObject.SetActive(false); //Destroy self
        }
    }


}