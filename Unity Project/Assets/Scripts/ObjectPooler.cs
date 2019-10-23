using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    //Declare Variables
    public static ObjectPooler sharedInstance; //Shared Instance Allows Multiple Scripts to Access Pooler w/o getting a component reference
    public List<GameObject> pooledObjects; //List of pooled objects
    public GameObject objectToPool; //GameObject to be pooled - e.g. bullet
    public int amountToPool; //Number of objects to start in pool - scales with demand if shouldExpand == true
    public bool shouldExpand = true; //!shouldExpand turns off pool scaling
    
    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        
        //Create object pool equal to number of requested starting objects
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    //Public method returns reference to pooled object
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //Iterate through the item list - is the item required not currently in the scene? If it is, loop to the next object in the list
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i]; //Return requested object
            }
        }

        //Expand pool if all pooled items are active
        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        } 
        
        else
        {
            return null;
        }      
    }

}
