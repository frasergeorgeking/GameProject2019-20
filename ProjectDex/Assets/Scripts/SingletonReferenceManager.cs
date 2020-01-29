using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonReferenceManager : MonoBehaviour
{
    //Create Shared Instance
    private static SingletonReferenceManager sharedInstance;
    public static SingletonReferenceManager Instance { get { return sharedInstance; } } //Getter, returns private sharedInstance

    void Awake()
    {

    }

    void Start()
    {
        Debug.Log("player");
    }


    public GameObject GetGameObjectReference(string tagName)
    {
        return GameObject.FindGameObjectWithTag(tagName);
    }
}