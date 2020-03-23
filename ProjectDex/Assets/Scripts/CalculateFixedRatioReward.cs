using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalculateFixedRatioReward : MonoBehaviour
{
    //Create Shared Instance
    private static CalculateFixedRatioReward sharedInstance;
    public static CalculateFixedRatioReward Instance { get { return sharedInstance; } }//Getter, returns private sharedInstance


    //Editor-Facing Private Variables
    [SerializeField] int startingGoal = 4;
    [SerializeField] int progressionModifier = 1;
    [SerializeField] ClearHUDText clearHUDText; //Reference required for invoking events

    //Private Variables
    private int currentX = 0;
    private int currentY;
    private int currentGoal;
    private int trackToPlay = 2;

    //Declare Event
    UnityEvent m_AllTracksUnlocked;

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
        
        currentGoal = startingGoal;
        currentY = currentGoal;
    }

    void Start()
    {
        //Define Unity Event
        if (m_AllTracksUnlocked == null)
        {
            m_AllTracksUnlocked = new UnityEvent();
        }

        //Add Event Listener
        m_AllTracksUnlocked.AddListener(clearHUDText.ShowNewText);
    }

    //Getter Functions
    public int GetCurrentX()
    {
        return currentX;
    }

    public int GetCurrentY()
    {
        return currentY;
    }

    //Incremental Functions
    public void IncrementCurrentX()
    {
        currentX++;

        if (trackToPlay < AudioClipManager.Instance.GetNumTotalTracks())
        {
            if (currentX >= currentY)
            {
                currentGoal = currentGoal + progressionModifier; //Calculate new goal
                SetCurrentY(currentGoal); //Set goal

                Debug.Log("Goal Hit"); //Debug Line

                AudioController.Instance.UnlockTrack(trackToPlay);
                trackToPlay++;

                currentX = 0;
            }
        }

        else if (trackToPlay >= AudioClipManager.Instance.GetNumTotalTracks())
        {
            m_AllTracksUnlocked.Invoke();
        }

    }

    //Setter Functions
    public void SetCurrentY(int updatedY)
    {
        currentY = updatedY;
    }
}
