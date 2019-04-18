using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickEventsManager : MonoBehaviour
{
    PlayerController playerController;
    CharacterControllerU characterController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        // characterController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerU>();
    }
    public void ContinueButtonOnItemMisMatchUI()
    {
        //playerController.Die();
        playerController.StartOverAgain();
        //characterController.StartOverAgain();
    }
}
