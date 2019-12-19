using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] Metronome metronome; //Pull Reference to metronome in scene
    
    //Private Variables
    private GameObject audioGameObject; //Declare audioGameObject
    private float[] notePitchValues = { 1f, 1.059463f, 1.122462f, 1.189207f, 1.259921f, 1.334840f, 1.414214f, 1.498307f, 1.587401f, 1.681793f, 1.781797f, 1.887749f, 2f }; //Pitch shift float values
    private int[] CKey = { 0, 2, 4, 5, 7, 9, 11, 12 }; //Initialisation of C Key Variables in accordance with notePitchValues array (e.g. 0 = 1f, 5 = 1.334840f)

    public void PlayNote(float pitch)
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        /* TEST CODE - USED FOR DEBUGGING THE PLAYING OF AUDIO CLIPS/PITCHSHIFTING
        //Assign Pooled audioGameObject AudioSource Game Component, Set Clip, Passthrough Pitch and Play Clip
        AudioSource audioSource = audioGameObject.GetComponent<AudioSource>();
        audioSource.clip = soundScapeAudioSamples[0]; //Debug Assign Clip
        audioSource.pitch = pitch;
        //audioSource.volume = 0.8f;
        audioSource.PlayOneShot(audioSource.clip, 1f);
        

        StartCoroutine(RecycleNote(audioSource.clip.length, audioGameObject)); //Recycle GameObject Back into Pool
        */
        
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
        Debug.Log("Whole Note");
    }

    IEnumerator RecycleNote(float delay, GameObject audioGameObject)
    {
        yield return new WaitForSeconds(delay + 1f);
        audioGameObject.SetActive(false);
    }

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

}
