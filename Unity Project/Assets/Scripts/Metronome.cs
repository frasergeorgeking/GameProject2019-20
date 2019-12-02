using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Metronome : MonoBehaviour
{
    [SerializeField] AudioController audioController;

    public float Base;
    public int step;
    public float bpm;
    public int currentStep;
    public int currentMeasure;

    private float interval;
    private float nextTime;

    UnityEvent m_16thNote;
    UnityEvent m_8thNote;
    UnityEvent m_quarterNote;
    UnityEvent m_halfNote;
    UnityEvent m_note;
    
    // Start is called before the first frame update
    void Start()
    {
        StartMetronome();

        if (m_16thNote == null)
        {
            m_16thNote = new UnityEvent();
        }
        
        if (m_8thNote == null)
        {
            m_8thNote = new UnityEvent();
        }

        if (m_quarterNote == null)
        {
            m_quarterNote = new UnityEvent();
        }

        if (m_halfNote == null)
        {
            m_halfNote = new UnityEvent();
        }

        if (m_note == null)
        {
            m_note = new UnityEvent();
        }

        m_16thNote.AddListener(audioController.Metronome16thTick);
        m_8thNote.AddListener(audioController.Metronome8thTick);
        m_quarterNote.AddListener(audioController.MetronomeQuarterTick);
        m_halfNote.AddListener(audioController.MetronomeHalfTick);
        m_note.AddListener(audioController.MetronomeWholeTick);

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
            nextTime += interval; //add interval to our relative time
            
            //Time Divided into 16ths to highlight legal notes (e.g. can play 16 16ths, 8 8ths, 4 quarter beats etc...)
            yield return new WaitForSeconds((nextTime - Time.time) /16); //1
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //2
            m_16thNote.Invoke();
            m_8thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //3
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //4
            m_16thNote.Invoke();
            m_8thNote.Invoke();
            m_quarterNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //5
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //6
            m_16thNote.Invoke();
            m_8thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //7
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //8
            m_16thNote.Invoke();
            m_8thNote.Invoke();
            m_quarterNote.Invoke();
            m_halfNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //9
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //10
            m_16thNote.Invoke();
            m_8thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //11
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //12
            m_16thNote.Invoke();
            m_quarterNote.Invoke();
            m_8thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //13
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //14
            m_16thNote.Invoke();
            m_8thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //15
            m_16thNote.Invoke();
            
            yield return new WaitForSeconds((nextTime - Time.time) / 16); //16
            m_16thNote.Invoke();
            m_8thNote.Invoke();
            m_quarterNote.Invoke();
            m_halfNote.Invoke();
            m_note.Invoke();

            currentStep++;
            if (currentStep > step)
            {
                currentStep = 1;
                currentMeasure++;
            }
        }
    }
}
