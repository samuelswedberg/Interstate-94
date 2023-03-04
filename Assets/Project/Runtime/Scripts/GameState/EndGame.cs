using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject GameOverScreen;
    CoinSystem CoinSystem;

    void Start()
    {
        CoinSystem = FindObjectOfType<CoinSystem>();
    }

    public void EndScreen()
    {
        GameOverScreen.SetActive(true);
        CoinSystem.coins += CoinSystem.coincounter;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Highway");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
