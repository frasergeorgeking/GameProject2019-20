using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    float[] noteLookup = new float[13];



    //public AudioClip pianoC3;
    AudioSource audioSource;

     // Start is called before the first frame update
    void Start()
    {
        noteLookup[0] = 1f;
        noteLookup[1] = 1.059463f;
        noteLookup[2] = 1.122462f;
        noteLookup[3] = 1.189207f;
        noteLookup[4] = 1.259921f;
        noteLookup[5] = 1.334840f;
        noteLookup[6] = 1.414214f;
        noteLookup[7] = 1.498307f;
        noteLookup[8] = 1.587401f;
        noteLookup[9] = 1.681793f;
        noteLookup[10] = 1.781797f;
        noteLookup[11] = 1.887749f;
        noteLookup[12] = 2f;

        audioSource = GetComponent<AudioSource>();
      
        foreach (float item in noteLookup)
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            audioSource.pitch = noteLookup[0];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            audioSource.pitch = noteLookup[1];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            audioSource.pitch = noteLookup[2];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            audioSource.pitch = noteLookup[3];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            audioSource.pitch = noteLookup[4];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            audioSource.pitch = noteLookup[5];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            audioSource.pitch = noteLookup[6];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            audioSource.pitch = noteLookup[7];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            audioSource.pitch = noteLookup[8];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            audioSource.pitch = noteLookup[9];
            audioSource.PlayOneShot(audioSource.clip, 1f);
            Debug.Log("Event Fired");
        }
    }
}
