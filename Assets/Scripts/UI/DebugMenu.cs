using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    InGame InGame;
    GameState GameState;
    public BoxCollider2D boxCollider;

    bool GodMode;
    public TMP_Text godText;

    void Start()
    {
        InGame = FindObjectOfType<InGame>();
        GameState = FindObjectOfType<GameState>();
        GodMode = false;
    }

    void Update()
    {
        GodModeStatus();
    }

    public void finishGame()
    {
        GameState.elapsedTime = GameState.elapsedTime + 4000f;
    }

    public void GodModeToggle()
    {
        if(GodMode == false)
        {
            GodMode = true;
        }
        else
        {
            GodMode = false;
        }
    }

    void GodModeStatus()
    {
        if(GodMode == true)
        {
            boxCollider.enabled = false;
            godText.SetText("God ON");
        } 
        else
        {
            boxCollider.enabled = true;
            godText.SetText("God OFF");
        }
    }
}
