using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    BoundBox boundBox;
    ObjKillZone objKillZone;
    PlayerController playerController;
    Spawner sp;
    MovementController mc;

    StartGame StartGame;
    InGame InGame;
    EndGame EndGame;

    // Start is called before the first frame update
    void Start()
    {
        boundBox = FindObjectOfType<BoundBox>();
        objKillZone = FindObjectOfType<ObjKillZone>();
        playerController = FindObjectOfType<PlayerController>();
        mc = FindObjectOfType<MovementController>();
        sp = FindObjectOfType<Spawner>();
        StartGame = FindObjectOfType<StartGame>();
        InGame = FindObjectOfType<InGame>();
        EndGame = FindObjectOfType<EndGame>();
        Intro();
    }

    void Intro()
    {
        boundBox.DisableBounds();
        objKillZone.DisableKillZone();
        playerController.playerMovement = false;
        StartGame.StartCountdown();
    }

    public void BeginGame()
    {
        boundBox.EnableBounds();
        objKillZone.EnableKillZone();
        playerController.playerMovement = true;
        sp.spawning = true;
    }

    public void EndingGame()
    {
        Debug.Log("Game Over");
        sp.spawning = false;
        EndGame.EndScreen();
    }
}
