using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Create Shared Instance
    private static AudioController sharedInstance;
    public static AudioController Instance { get { return sharedInstance; } }//Getter, returns private sharedInstance
    
    //Editor-Facing Private Variables
    [SerializeField] Metronome metronome; //Pull Reference to metronome in scene

    [SerializeField] AudioClip track01;
    [SerializeField] AudioClip track02;
    [SerializeField] AudioClip track03;
    [SerializeField] AudioClip[] melodies;
    [SerializeField] AudioClip track04;
    [SerializeField] AudioClip track05;
    [SerializeField] AudioClip track06;
    [SerializeField] AudioClip track07;
    

    //Private Variables
    private int currentMeasure = 0;
    private GameObject audioGameObject; //Declare audioGameObject
    private float[] notePitchValues = { 1f, 1.059463f, 1.122462f, 1.189207f, 1.259921f, 1.334840f, 1.414214f, 1.498307f, 1.587401f, 1.681793f, 1.781797f, 1.887749f, 2f }; //Pitch shift float values
    private int[] CKey = { 0, 2, 4, 5, 7, 9, 11, 12 }; //Initialisation of C Key Variables in accordance with notePitchValues array (e.g. 0 = 1f, 5 = 1.334840f)

    private int test = 0;

    private bool playTrack01 = true;
    private bool playTrack02 = false;
    private bool playTrack03 = false;
    private bool playTrack04 = false;
    private bool playTrack05 = false;
    private bool playTrack06 = false;
    private bool playTrack07 = false;

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


    public void PlayFirstTrack()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = track01;
        audioGameObjectAudioSource.Play();
    }

    public void PlaySecondTrack()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = track02;
        audioGameObjectAudioSource.Play();
    }

    public void PlayThirdTrack()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = track03;
        audioGameObjectAudioSource.Play();
    }
    public void PlayFourthTrack()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = track04;
        audioGameObjectAudioSource.Play();
    }

    public void PlayFifthTrack()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = track05;
        audioGameObjectAudioSource.Play();
    }
    public void PlaySixthTrack()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = track06;
        audioGameObjectAudioSource.Play();
    }
    public void PlaySeventhTrack()
    {
        //Pull reference to audioGameObject from pooler
        audioGameObject = ObjectPooler.sharedInstance.GetPooledObject("audioGameObject");

        if (audioGameObject != null)
        {
            audioGameObject.transform.position = new Vector3(0f, 0f, 0f);
            audioGameObject.SetActive(true);
        }

        AudioSource audioGameObjectAudioSource = audioGameObject.GetComponent<AudioSource>();
        audioGameObjectAudioSource.clip = track07;
        audioGameObjectAudioSource.Play();
    }

    //DEBUG METHOD
    public void PlayTrack(int trackRef)
    {
        switch (trackRef)
        {
            case 1:
                playTrack01 = true;
                break;
            case 2:
                playTrack02 = true;
                break;
            case 3:
                playTrack03 = true;
                break;
            case 4:
                playTrack04 = true;
                break;
            case 5:
                playTrack05 = true;
                break;
            case 6:
                playTrack06 = true;
                break;
            case 7:
                playTrack07 = true;
                break;
        }
    }

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
      
        //Debug.Log("Whole Note"); ////Debug Line - Used for Custom Event Firing Tests
    }

    public void MetronomeWholeMeasure()
    {
        //PlayMelody();

        if(currentMeasure % 5 == 0)
        {
            PlayFirstTrack();
            
            if (playTrack02 == true)
            {
                PlaySecondTrack();
            }

            if (playTrack03 == true)
            {
                PlayThirdTrack();
            }

            if (playTrack04 == true)
            {
                PlayFourthTrack();
            }

            if (playTrack05 == true)
            {
                PlayFifthTrack();
            }

            if (playTrack06 == true)
            {
                PlaySixthTrack();
            }

            if (playTrack07 == true)
            {
                PlaySeventhTrack();
            }

        }
        currentMeasure++; //Increment Measure
    }

    /* Functionality currently not required - may be required at a later point
    IEnumerator RecycleNote(float delay, GameObject audioGameObject)
    {
        yield return new WaitForSeconds(delay + 1f); //Float provides additional buffer
        audioGameObject.SetActive(false);
    }
    */

}
