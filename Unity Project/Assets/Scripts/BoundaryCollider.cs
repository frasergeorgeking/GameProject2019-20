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
    }
}
