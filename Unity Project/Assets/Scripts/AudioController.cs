using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip[] soundScapeAudioSamples;
    [SerializeField] Metronome metronome;
       
    private GameObject audioGameObject;
    
    private float[] notePitchValues = { 1f, 1.059463f, 1.122462f, 1.189207f, 1.259921f, 1.334840f, 1.414214f, 1.498307f, 1.587401f, 1.681793f, 1.781797f, 1.887749f, 2f };
    private int[] CKey = { 0, 2, 4, 5, 7, 9, 11, 12 };

    //Debug Key Tests
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayNote(notePitchValues[0]);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayNote(notePitchValues[1]);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayNote(notePitchValues[2]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlayNote(notePitchValues[3]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PlayNote(notePitchValues[4]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            PlayNote(notePitchValues[5]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            PlayNote(notePitchValues[6]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            PlayNote(notePitchValues[7]);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            PlayNote(notePitchValues[8]);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayNote(notePitchValues[9]);
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            PlayNote(notePitchValues[10]);
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            PlayNote(notePitchValues[11]);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayNote(notePitchValues[CKey[7]]);
        }
    }

    public void PlayNote(float pitch)
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
        audioSource.clip = soundScapeAudioSamples[0]; //Debug Assign Clip
        audioSource.pitch = pitch;
        //audioSource.volume = 0.8f;
        audioSource.PlayOneShot(audioSource.clip, 1f);

        StartCoroutine(RecycleNote(audioSource.clip.length, audioGameObject)); //Recycle GameObject Back into Pool
                      
    }

    public void Metronome16thTick()
    {
        Debug.Log("16th");
    }
    public void Metronome8thTick()
    {
        Debug.Log("8th");
    }
    public void MetronomeQuarterTick()
    {
        Debug.Log("Quarter Note");
    }
    public void MetronomeHalfTick()
    {
        Debug.Log("Half Note");
    }
    public void MetronomeWholeTick()
    {
        if(((metronome.currentMeasure % 4) == 0) && metronome.currentStep <= 1)
        {
            PlayNote(notePitchValues[CKey[Random.Range(0, 7)]]);
        }
    }

    IEnumerator RecycleNote(float delay, GameObject audioGameObject)
    {
        yield return new WaitForSeconds(delay + 1f);
        audioGameObject.SetActive(false);
    }

}
