using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceTraveled : MonoBehaviour
{
    GameState GameState;
    public TMP_Text distText;
    void Start()
    {
        GameState = FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        distText.SetText("You traveled " + GameState.elapsedTime.ToString("f1") + " meters");
    }
}
