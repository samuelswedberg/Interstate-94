using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    public GameObject Stage2;
    public GameObject Stage3;
    public GameObject Stage4;
    public GameObject Finish;
    Spawner Spawner;
    GameState GameState;

    void Start()
    {
        Spawner = FindObjectOfType<Spawner>();
        GameState = FindObjectOfType<GameState>();
    }

    public void transmitStage2()
    {
        StartCoroutine(doStage2());
    }

    public void transmitStage3()
    {
        StartCoroutine(doStage3());
    }
    public void transmitStage4()
    {
        StartCoroutine(doStage4());
    }

    public void transmitFinish()
    {
        StartCoroutine(doFinish());
    }

    public IEnumerator doStage2()
    {
        Stage2.SetActive(true);
        Spawner.spawning = false;
        yield return new WaitForSeconds(3);
        Stage2.SetActive(false);
        Spawner.spawning = true;
    }

    public IEnumerator doStage3()
    {
        Stage3.SetActive(true);
        Spawner.spawning = false;
        yield return new WaitForSeconds(3);
        Stage3.SetActive(false);
        Spawner.spawning = true;
    }
    
    public IEnumerator doStage4()
    {
        Stage4.SetActive(true);
        Spawner.spawning = false;
        yield return new WaitForSeconds(3);
        Stage4.SetActive(false);
        Spawner.spawning = true;
    }

    public IEnumerator doFinish()
    {
        Finish.SetActive(true);
        GameState.WonGame();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Main Menu");  
    }
}
