using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    //Private Variables
    private Vector3 originalPos;
    
    public void TriggerCameraShake(float duration, float amount)
    {
        StopAllCoroutines(); //Stop any pre-existing coroutines
        StartCoroutine(StartCameraShake(duration, amount));
    }
    
    IEnumerator StartCameraShake(float duration, float amount)
    {
        float endTime = Time.time + duration; //Calculate end time by additing current time to shake duration

        while (Time.time < endTime)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }

}
