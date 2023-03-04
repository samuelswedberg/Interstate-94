
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    DataManager DataManager;
    public AudioSource audioSource, engine;
    public Image image;
    public GameObject black, l1, l2, l3;
    public Transform vehicle;
    bool startMove = false;


    void Start() {
        DataManager = FindObjectOfType<DataManager>();
    }
    void Update()
    {
        if(startMove == true)
            vehicle.Translate(Vector3.right * 2f * Time.deltaTime);
    }
    public void StartGame()
    {
        Debug.Log("Start Gamee");
        StartCoroutine(fadeOut()); 
    }


    public void ExitGame() 
    {  
        DataManager.SaveCharacterInfo();
        Debug.Log("Exit Game. Saved game.");  
        Application.Quit();  
    }  

    IEnumerator fadeOut()
    {   

        int x = 0;
        black.SetActive(true);
        Color c = image.color;
        while(x != 100)
        {
            audioSource.volume -= .001f;
            yield return new WaitForSeconds(0.001f);
            x++;
        }
        engine.Play();
        yield return new WaitForSeconds(1.25f);
        l1.SetActive(true);
        l2.SetActive(true);
        l3.SetActive(true);
        yield return new WaitForSeconds(.25f);
        startMove = true;
        x=0;
        while(x != 100)
        {
            c.a += .01f;
            image.color = c;
            yield return new WaitForSeconds(0.01f);
            x++;
        }
        
        SceneManager.LoadScene("Highway"); 
    }
}
