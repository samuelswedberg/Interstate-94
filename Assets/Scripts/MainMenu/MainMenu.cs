﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Highway");  
    }


    public void ExitGame() 
    {  
        Debug.Log("Exit Game");  
        Application.Quit();  
    }  
}
