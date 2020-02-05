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
    private GameObject audioGameObject;
    private int globalMeasure = 0;
   
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

    void Start()
    {
        PlayTrack(AudioClipManager.Instance.GetTrackAudioClips(1));
    }

    public void PlayTrack(AudioClip[] audioClipRef)
    {

        //Pull reference to audioGameObject from pooler
        audioGameObject = CreateAudioGameObject();

        AudioSource audioGameObjectSource = audioGameObject.GetComponent<AudioSource>(); //Create Reference to AudioSource Component

        audioGameObjectSource.clip = audioClipRef[0]; //HARD CODED CLIP REFERENCE - UPDATE 

        audioGameObjectSource.Play(); //Immediately play first bar

        //INSERT CODE TO TIME NEXT BARS - ALSO REQUIRES CODE THAT REPLAYS A GIVEN TRACK EVERY 4BARS (GATE WITH playTrack01, 02 etc.... bools)


        //Assign Audio Clip to Audio Source & Start Recycle Coroutine
        //AudioSource audioGameObjectSource = audioGameObject.GetComponent<AudioSource>();
        //audioGameObjectSource.clip = audioClipRef[i];
        //audioGameObjectSource.Play();

        //StartCoroutine(RecycleAudioGameObject(audioClipRef[i].length, audioGameObject)); //Recycle GameObject back into pooler when clip has played




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
        globalMeasure++; //Increment globalMeasure

        //Debug.Log("FullMeasureCompleted")  //Debug Line - Used for Custom Event Firing Tests
    }

    IEnumerator RecycleAudioGameObject(float delay, GameObject audioGameObjectRef)
    {
        yield return new WaitForSeconds(delay + 2f); //Float provides additional 2 sec buffer
        audioGameObject.SetActive(false);
    }
    

}
