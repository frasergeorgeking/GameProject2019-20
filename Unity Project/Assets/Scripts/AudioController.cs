using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] audioSamples;

    private GameObject audioGameObject;

    //Debug Key Tests
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayNote(1f);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayNote(1.059463f);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayNote(1.122462f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayNote(1.189207f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayNote(1.259921f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayNote(1.334840f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            PlayNote(1.414214f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            PlayNote(1.498307f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PlayNote(1.587401f);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayNote(1.681793f);
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            PlayNote(1.781797f);
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            PlayNote(1.887749f);
        }
    }

    void PlayNote(float pitch)
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        //Assign Pooled audioGameObject AudioSource Game Component, Set Clip, Passthrough Pitch and Play Clip
        AudioSource audioSource = audioGameObject.GetComponent<AudioSource>();
        audioSource.clip = audioSamples[0]; //Debug Assign Clip
        audioSource.pitch = pitch;
        audioSource.PlayOneShot(audioSource.clip, 1f);

        StartCoroutine(RecycleNote(audioSource.clip.length, audioGameObject)); //Recycle GameObject Back into Pool
                      
    }

    IEnumerator RecycleNote(float delay, GameObject audioGameObject)
    {
        yield return new WaitForSeconds(delay + 1f);
        audioGameObject.SetActive(false);
    }

}
