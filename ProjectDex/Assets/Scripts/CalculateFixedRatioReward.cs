using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateFixedRatioReward : MonoBehaviour
{
    //Create Shared Instance
    private static CalculateFixedRatioReward sharedInstance;
    public static CalculateFixedRatioReward Instance { get { return sharedInstance; } }//Getter, returns private sharedInstance


    //Editor-Facing Private Variables
    [SerializeField] int startingGoal = 4;
    [SerializeField] int progressionModifier = 1;

    //Private Variables
    private int currentX = 0;
    private int currentY;
    private int currentGoal;
    private int trackToPlay = 2;

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

        if (currentX >= currentY)
        {
            currentGoal = currentGoal + progressionModifier; //Calculate new goal
            SetCurrentY(currentGoal); //Set goal

            Debug.Log("Goal Hit");

            //AudioController.Instance.PlayTrack(trackToPlay);
            trackToPlay++;
            
            currentX = 0;
        }
    }

    //Setter Functions
    public void SetCurrentY(int updatedY)
    {
        currentY = updatedY;
    }
}
