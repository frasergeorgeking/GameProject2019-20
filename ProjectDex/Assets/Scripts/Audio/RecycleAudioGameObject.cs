using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleAudioGameObject : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] [Range(0f, 10f)] float delay = 2f;

    //Private Variables
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void StartAudioGameObjectRecycleEnumerator(float clipLength)
    {
        StartCoroutine(SetAudioGameObjectInactive(clipLength + delay));
    }

    IEnumerator SetAudioGameObjectInactive(float timeToDelay)
    {
        yield return new WaitForSeconds(timeToDelay);
        audioSource.clip = null; //Reset audio clip, should be overwriten in AudioController but cleared for safety
        gameObject.SetActive(false);
    }
}
