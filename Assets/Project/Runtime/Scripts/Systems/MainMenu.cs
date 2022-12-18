
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    DataManager DataManager;

    void Start() {
        DataManager = FindObjectOfType<DataManager>();
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Highway");  
    }


    public void ExitGame() 
    {  
        DataManager.SaveCharacterInfo();
        Debug.Log("Exit Game. Saved game.");  
        Application.Quit();  
    }  
}
