using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] AudioClip debugAudioClip; //debug AudioClip to play

    public float Base;
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
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartMetronome();
        }
    }

    public void StartMetronome()
    {
        StopCoroutine("DoTick"); //stop any existing coroutine of the metronome
        currentStep = 1; //start at first step of new measure
        var multiplier = Base / 4f; //base time division in music is the quarter note, which is signature base 4
        var tmpInterval = 60f / bpm; //this is a basic inverse proportion operation where 60BPM at signature base 4 is 1 second/beat so x BPM is ((60 * 1 ) / x) seconds/beat
        interval = tmpInterval / multiplier; //final interval is modified by the multiplier
        nextTime = Time.time; //set the relative time to now
        StartCoroutine("DoTick");
    }

    IEnumerator DoTick()
    {
        for (; ; ) //creates an infinite loop
        {
            AudioSource.PlayClipAtPoint(debugAudioClip, Camera.main.transform.position); //plays debugAudioClip at main camera pos
            nextTime += interval; //add interval to our relative time
            yield return new WaitForSeconds((nextTime - Time.time) /16); //1
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //2
            Debug.Log("16th");
            Debug.Log("8th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //3
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //4
            Debug.Log("16th");
            Debug.Log("8th");
            Debug.Log("Quarter Note");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //5
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //6
            Debug.Log("16th");
            Debug.Log("8th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //7
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //8
            Debug.Log("16th");
            Debug.Log("8th");
            Debug.Log("Quarter Note");
            Debug.Log("Half Note");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //9
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //10
            Debug.Log("16th");
            Debug.Log("8th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //11
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //12
            Debug.Log("16th");
            Debug.Log("8th");
            Debug.Log("Quarter Note");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //13
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //14
            Debug.Log("16th");
            Debug.Log("8th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //15
            Debug.Log("16th");
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //16
            Debug.Log("16th");
            Debug.Log("8th");
            Debug.Log("Quarter Note");
            Debug.Log("Half Note");
            Debug.Log("Whole beat");
            currentStep++;
            if (currentStep > step)
            {
                currentStep = 1;
                currentMeasure++;
            }
        }
    }
}
