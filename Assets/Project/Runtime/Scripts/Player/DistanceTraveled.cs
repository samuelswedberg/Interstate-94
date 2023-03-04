using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTraveled : MonoBehaviour
{
    GameState GameState;
    CoinSystem CoinSystem;
    public TMP_Text distText, running, cointext, coinrun, highscoreText;
    public float highscore;
    void Start()
    {
        GameState = FindObjectOfType<GameState>();
        CoinSystem = FindObjectOfType<CoinSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        distText.SetText("You traveled " + GameState.elapsedTime.ToString("f0") + " meters");
        running.SetText(GameState.elapsedTime.ToString("f0"));
        coinrun.SetText(CoinSystem.coincounter.ToString());
        cointext.SetText("+ " + CoinSystem.coincounter);
        if(highscore < GameState.elapsedTime)
        {
            highscore = GameState.elapsedTime;
            highscoreText.SetText("New high score!: " +  GameState.elapsedTime.ToString("f0"));
        }
        else
        {
            highscoreText.SetText("High score: " + highscore.ToString("f0"));
        }
    }
}
