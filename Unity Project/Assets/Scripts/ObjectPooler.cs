using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] public class ObjectPoolItem
{
    public GameObject objectToPool; //GameObject to be pooled - e.g. bullet, enemy etc...
    public int amountToPool; //Number of objects to start in pool - scales with demand if shouldExpand == true
    public bool shouldExpand = true; //!shouldExpand deactivates pool scaling
}
public class ObjectPooler : MonoBehaviour
{
    public List<ObjectPoolItem> itemsToPool;
    public static ObjectPooler sharedInstance; //Shared Instance Allows Multiple Scripts to Access Pooler w/o getting a component reference
    public List<GameObject> pooledObjects; //List of pooled objects
       
    void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        
        foreach (ObjectPoolItem item in itemsToPool)
        {
            //Create object pool equal to number of requested starting objects
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    //Public method returns reference to pooled object - string parameter allows comparison against tag
    public GameObject GetPooledObject(string tag)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //Iterate through the item list - is the item required not currently in the scene? If it is, loop to the next object in the list
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i]; //Return requested object
            }
        }

        foreach (ObjectPoolItem item in itemsToPool)
        {
            //Perform tag lookup on object pool
            if(item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }

    //Test Method for Referencing Number of Active GameObjects in Pool
   public int GetTotalActiveNumOfObjects(string tag)
    {
        int totalActiveNumOfObjects = 0;
        
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //Iterate through item list and check how many active objects match tag parameter
            if(pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                totalActiveNumOfObjects++;
            }
         
        }
        return totalActiveNumOfObjects;
    }

}
