using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartGame : MonoBehaviour
{

    public GameObject Ready, Set, Go, Tip;

    GameState GameState;
    CoinSystem CoinSystem;
    StartCop StartCop;


    void Start()
    {
        GameState = FindObjectOfType<GameState>();
        StartCop = FindObjectOfType<StartCop>();
        CoinSystem = FindObjectOfType<CoinSystem>();
        CoinSystem.coincounter = 0;
        GameState.Tips();
    }


    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }
    
    IEnumerator Countdown()
    {
        Ready.SetActive(true);
        Tip.SetActive(true);
        yield return new WaitForSeconds(2);
        Ready.SetActive(false);

        StartCop.copMovement = true;

        Set.SetActive(true);
        yield return new WaitForSeconds(2);
        Set.SetActive(false);

        GameState.BeginGame();

        Go.SetActive(true);
        yield return new WaitForSeconds(2);
        Go.SetActive(false);
        Tip.SetActive(false);
        
    }
}
