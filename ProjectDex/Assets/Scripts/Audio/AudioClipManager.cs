using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] AudioClipData[] audioClipData;

    [System.Serializable] //Allows editing in editor
    public class AudioClipData //Creates class that contains neccessary data types
    {
        public AudioClip[] audioClips; //Audio clip(s) that comprise of the full track
        public string trackName;
    }

    //Getter Functions 
    /*
    public AudioClip GetAudioTrack(int trackNum)
    {
        return audioTracks[trackNum - 1]; //Return Requested Track (-1 because array counts from 0)
    }
    */
    
}
