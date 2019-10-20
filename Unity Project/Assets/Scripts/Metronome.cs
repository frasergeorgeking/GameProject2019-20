using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] AudioClip debugAudioClip; //debug AudioClip to play

    public float baseTime;
    public int step;
    public float bpm;
    public int currentStep;
    public int currentMeasure;

    private float interval;
    private float nextTime;

    // Start is called before the first frame update
    void Start()
    {
        StartMetronome();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartMetronome()
    {
        StopCoroutine("DoTick"); //stop any existing coroutine of the metronome
        currentStep = 1; //start at first step of new measure
        var multiplier = baseTime / 4f; //base time division in music is the quarter note, which is signature base 4
        var tmpInterval = 60f / bpm; //this is a basic inverse proportion operation where 60BPM at signature base 4 is 1 second/beat so x BPM is ((60 * 1 ) / x) seconds/beat
        interval = tmpInterval / multiplier; //final interval is modified by the multiplier
        nextTime = Time.time; //set the relative time to now
        StartCoroutine("DoTick");
    }

    IEnumerator DoTick()
    {
        for (; ; ) //creates an infinite loop
        {
            Debug.Log("bop");
            AudioSource.PlayClipAtPoint(debugAudioClip, Camera.main.transform.position); //plays debugAudioClip at main camera pos
            // do something with this beat
            nextTime += interval; //add interval to our relative time
            yield return new WaitForSeconds(nextTime - Time.time); //wait interval seconds before next beat
            currentStep++;
            if (currentStep > step)
            {
                currentStep = 1;
                currentMeasure++;
            }
        }
    }
}
