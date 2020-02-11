using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    private static AudioClipManager sharedInstance;
    public static AudioClipManager Instance { get { return sharedInstance; } } //Getter, returns private sharedInstance

    //Editor-Facing Private Variables
    [SerializeField] AudioClipData[] audioClipData;


    [System.Serializable] //Allows editing in editor
    public class AudioClipData //Creates class that contains neccessary data types
    {
        public AudioClip[] audioClips; //Audio clip(s) that comprise of the full track
        public string trackName; //Name of track, used to make clear in the editor each track
    }

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

    //Getter Functions
    public AudioClip[] GetTrackAudioClips(int trackNum)
    {
        return audioClipData[trackNum - 1].audioClips;
    }

    public int GetNumTotalTracks()
    {
        return audioClipData.Length;
    }
    
}
