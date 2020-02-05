using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Create Shared Instance
    private static AudioController sharedInstance;
    public static AudioController Instance { get { return sharedInstance; } } //Getter, returns private sharedInstance
    
    //Editor-Facing Private Variables
    [SerializeField] Metronome metronome; //Pull Reference to metronome in scene

    //Private Variables
    private GameObject audioGameObject; //Declare audioGameObject
   
    void Awake()
    {
        //Set Shared Instance
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    public void PlayTrack(AudioClip audioClipRef)
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }
        
        //Assign Audio Clip to Audio Source & 
        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = audioClipRef;
        audioGameObjectAudioSource.Play();

        StartCoroutine(RecycleAudioGameObject(audioClipRef.length, audioGameObject)); //Recycle GameObject back into pooler when clip has played
    }

    /* REQUIRES REIMPLEMENTATION IN SEPERATE CLASS
    public void PlayMelody()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = melodies[(Random.Range(0,1))];
        audioGameObjectAudioSource.Play();
    }
    */

    public void Metronome16thTick()
    {
        //Debug.Log("16th"); //Debug Line - Used for Custom Event Firing Tests
    }
    public void Metronome8thTick()
    {
        //Debug.Log("8th"); //Debug Line - Used for Custom Event Firing Tests
    }
    public void MetronomeQuarterTick()
    {
        //Debug.Log("Quarter Note"); //Debug Line - Used for Custom Event Firing Tests
    }
    public void MetronomeHalfTick()
    {
        //Debug.Log("Half Note"); //Debug Line - Used for Custom Event Firing Tests
    }
    public void MetronomeWholeTick()
    {
        //Debug.Log("Whole Note"); //Debug Line - Used for Custom Event Firing Tests
    }
    
    public void MetronomeWholeMeasure()
    {
        //Debug.Log("FullMeasureCompleted")  //Debug Line - Used for Custom Event Firing Tests
    }

    IEnumerator RecycleAudioGameObject(float delay, GameObject audioGameObjectRef)
    {
        yield return new WaitForSeconds(delay + 2f); //Float provides additional 2 sec buffer
        audioGameObject.SetActive(false);
    }
    

}
