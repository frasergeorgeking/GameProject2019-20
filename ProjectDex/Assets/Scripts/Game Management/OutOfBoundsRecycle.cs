using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsRecycle : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "boundaryTrigger")
        {
            gameObject.SetActive(false); //Set object inactive after collision with boundaryTrigger
        }
    }
}
