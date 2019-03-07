﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIClickEventsManager : MonoBehaviour
{
    PlayerController playerController;


    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void ContinueButtonOnItemMisMatchUI()
    {
        //playerController.Die();
        playerController.StartOverAgain();
    }
}