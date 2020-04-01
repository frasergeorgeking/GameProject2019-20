using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnalyticsTracker : MonoBehaviour
{
    //Create Shared Instance
    private static PlayerAnalyticsTracker sharedInstance;
    public static PlayerAnalyticsTracker Instance { get { return sharedInstance; } } //Getter, returns private sharedInstance

    //Private Variables
    private int playerKills;
    private int totalPlayerShots;
    
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
    public int GetPlayerKills()
    {
        return playerKills;
    }

    public int GetTotalPlayerShots()
    {
        return totalPlayerShots;
    }

    //Increment Functions
    public void IncrementPlayerKills()
    {
        playerKills++;
    }

    public void IncrementTotalPlayerShots()
    {
        totalPlayerShots++;
    }
}
