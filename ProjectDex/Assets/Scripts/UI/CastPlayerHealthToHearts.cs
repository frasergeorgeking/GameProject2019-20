using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CastPlayerHealthToHearts : MonoBehaviour
{
    //Editor-Facing Private Variables
    [SerializeField] List<GameObject> heartGameObjects;
    [SerializeField] Sprite halfHeart;
    [SerializeField] Sprite emptyHeart;

    //Private Variables
    private List<Image> heartImageComponents = new List<Image>();
    
    void Awake()
    {
        //Iterate Through heartGameObjects List & Add Image Component Reference to heartImageComponents List
        foreach (GameObject heart in heartGameObjects)
        {
            heartImageComponents.Add(heart.GetComponent<Image>());
            Debug.Log(heart);
        }

    }

    void Start()
    {

    }

    private void UpdateHeartImage(Image heartImageToUpdate, bool heartStatus) //heartStatus bool whereby 0 = empty, 1 = half full (a full heart never has to be assigned, as player can only lose health)
    {
        if (heartStatus)
        {
            heartImageToUpdate.sprite = halfHeart;
        }

        else if (!heartStatus)
        {
            heartImageToUpdate.sprite = emptyHeart;
        }
    }
        
    public void UpdateHearts(int playerHealth)
    {
        switch (playerHealth)
        {
            case (5):
                UpdateHeartImage(heartImageComponents[0], true);
                break;

            case (4):
                UpdateHeartImage(heartImageComponents[0], false);
                break;

            case (3):
                UpdateHeartImage(heartImageComponents[1], true);
                break;

            case (2):
                UpdateHeartImage(heartImageComponents[1], false);
                break;

            case (1):
                UpdateHeartImage(heartImageComponents[2], true);
                break;

            case (0):
                UpdateHeartImage(heartImageComponents[2], false);
                break;
        }
    }

}
