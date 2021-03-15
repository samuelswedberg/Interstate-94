using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject GameOverScreen;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EndScreen()
    {
        GameOverScreen.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Highway");
    }
}
