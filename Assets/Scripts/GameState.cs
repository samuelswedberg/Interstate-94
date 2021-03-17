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

    public bool timerGoing;
    public float elapsedTime;

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
        timerGoing = false;
        Intro();
    }

    void Update()
    {
        if ( elapsedTime > 1000f && sp.stage == 1)
        {
            sp.stage = 2;
            InGame.transmitStage2();

        }

        if ( elapsedTime > 2000f && sp.stage == 2)
        {
            sp.stage = 3;
            InGame.transmitStage3();
            
        }

        if ( elapsedTime > 3000f && sp.stage == 3)
        {
            sp.stage = 4;
            InGame.transmitStage4();
            
        }

        if ( elapsedTime > 4000f && sp.stage == 3)
        {
            InGame.transmitFinish();
        }
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
        StartTimer();
    }

    public void EndingGame()
    {
        Debug.Log("Game Over");
        sp.spawning = false;
        EndGame.EndScreen();
    }

    void StartTimer()
    {
        timerGoing = true;
        StartCoroutine(UpdateTimer());
    }

    void EndTimer()
    {
        timerGoing = false;
    }

    IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime * 26.8f;
            //Debug.Log(elapsedTime);

            yield return null;
        }
    }
}
