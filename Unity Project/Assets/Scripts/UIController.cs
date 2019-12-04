using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject[] spriteHearts;

    public GameObject heart1, heart2, heart3;

    private int playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameController.sharedInstance.playerShip.GetComponent<PlayerShip>().GetPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RemoveHeart()
    {

    }
}
