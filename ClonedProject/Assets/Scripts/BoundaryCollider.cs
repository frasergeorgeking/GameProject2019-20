using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollider : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            other.gameObject.SetActive(false); //Recycle Bullet Back into Object Pool
        }

        if (other.gameObject.tag == "enemy01" && other.gameObject.transform.position.y < 0) //Ensures enemy isn't being recycled when hitting the top-most collider
        {
            other.gameObject.SetActive(false); //Recycle Enemy Back into Object Pool
        }
    }
}
