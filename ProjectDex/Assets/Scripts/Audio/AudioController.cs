using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Create Shared Instance
    private static AudioController sharedInstance;
    public static AudioController Instance { get { return sharedInstance; } } //Getter, returns private sharedInstance
    
    //Editor-Facing Private Variables
    [SerializeField] Metronome metronome;

    //Private Variables
    private GameObject audioGameObject;
    private int globalMeasure = 0;

    //Public Variables
    public bool playFirstTrack = true;
    public bool playSecondTrack = false;
    public bool playThirdTrack = false;
    public bool playFourthTrack = false;
    public bool playFifthTrack = false;
    public bool playSixthTrack = false;
   
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

    public void PlayTrack(AudioClip[] audioClipRef)
    {
        //Pull reference to audioGameObject from pooler
        GameObject audioGameObject = CreateAudioGameObject();

        //Create References to Necessary Components
        AudioSource audioGameObjectSource = audioGameObject.GetComponent<AudioSource>();
        RecycleAudioGameObject audioGameObjectRecycle = audioGameObject.GetComponent<RecycleAudioGameObject>();

        //Set AudioSource Clip, Play Note & Recycle back into Object Pooler
        audioGameObjectSource.clip = audioClipRef[0];
        audioGameObjectSource.Play();
        audioGameObjectRecycle.StartAudioGameObjectRecycleEnumerator(audioClipRef[0].length);
        
    }

    public GameObject CreateAudioGameObject()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        //Set position & set active
        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        return audioGameObject;
    }

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
        PlayTrack(AudioClipManager.Instance.GetTrackAudioClips(1));

        if (playSecondTrack == true)
        {
            PlayTrack(AudioClipManager.Instance.GetTrackAudioClips(2));
        }

        if (playThirdTrack == true)
        {
            PlayTrack(AudioClipManager.Instance.GetTrackAudioClips(3));
        }

        if (playFourthTrack == true)
        {
            PlayTrack(AudioClipManager.Instance.GetTrackAudioClips(4));
        }

        if (playFifthTrack == true)
        {
            PlayTrack(AudioClipManager.Instance.GetTrackAudioClips(5));
        }

        if (playSixthTrack == true)
        {
            PlayTrack(AudioClipManager.Instance.GetTrackAudioClips(6));
        }

        //Debug.Log("FullMeasureCompleted")  //Debug Line - Used for Custom Event Firing Tests

    }

    public void UnlockTrack(int TrackNum)
    {
        switch (TrackNum)
        {
            case 1:
                playFirstTrack = true;
                break;

            case 2:
                playSecondTrack = true;
                break;

            case 3:
                playThirdTrack = true;
                break;

            case 4:
                playFourthTrack = true;
                break;

            case 5:
                playFifthTrack = true;
                break;

            case 6:
                playSixthTrack = true;
                break;
        }
    }

    IEnumerator RecycleAudioGameObject(float delay, GameObject audioGameObjectRef)
    {
        yield return new WaitForSeconds(delay + 2f); //Float provides additional 2 sec buffer
        audioGameObject.SetActive(false);
    }
}
