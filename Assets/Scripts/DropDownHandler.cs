using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour
{
    public MainMenu mainMenu;
    public GameManager gm;

    // Passes the Dropdown Value in and changes Difficulty of the Game
    public void HandleInputData(int val)
    {
        if (gm != null)
        {
            gm.ChangeDifficulty(val);
        }

        if (mainMenu != null)
        {
           mainMenu.ChangeDifficulty(val); 
        }
        
    }
}
