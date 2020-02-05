using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipManager : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] AudioClip[] audioTracks;

    //Getter Functions
    public AudioClip GetAudioTrack(int trackNum)
    {
        return audioTracks[trackNum - 1]; //Return Requested Track (-1 because array counts from 0)
    }
}
