using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsRecycle : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        //Check if Collision Occurs Against Boundary Trigger
        if (other.gameObject.tag == "boundaryTrigger")
        {
            gameObject.SetActive(false);
        }
    }
}
