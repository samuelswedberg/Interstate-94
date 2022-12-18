using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject Ready;
    public GameObject Set;
    public GameObject Go;

    GameState GameState;

    StartCop StartCop;

    void Start()
    {
        GameState = FindObjectOfType<GameState>();
        StartCop = FindObjectOfType<StartCop>();
    }

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }
    
    IEnumerator Countdown()
    {
        Ready.SetActive(true);
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
        
    }
}
