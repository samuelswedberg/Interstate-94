using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    DebugMenu DebugMenu;

    DataManager DataManager;
    public GameObject debugMenu;
    public ParticleSystem explosion;
    public bool dm_open;

    public bool timerGoing;
    public float elapsedTime;
    public TMP_Text tip;


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
        DebugMenu = FindObjectOfType<DebugMenu>();
        DataManager = FindObjectOfType<DataManager>();
        timerGoing = false;
        dm_open = false;
        Intro();
    }

    public void Tips()
    {
        string[] Tips = {"TIP: Run over cones to collect them", "TIP: Use the ramps to jump over vehicles", "TIP: Don't run into other vehicles"};
        int rand = Random.Range(0, 2);
        string rtnString = Tips[rand];
        tip.SetText(rtnString);
    }
    
    void Update()
    {
        Timer();
        DebugMenuVisibility();
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
        explosion.Play();
        EndGame.EndScreen();
        DataManager.SaveCharacterInfo();
    }

    public void WonGame()
    {
        Debug.Log("You win!");
        sp.spawning = false;
        playerController.playerMovement = false;
    }

    public void StartTimer()
    {
        timerGoing = true;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    void DebugMenuVisibility()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            if(dm_open == false)
            {
                debugMenu.SetActive(true);
                dm_open = true;
            }
            else
            {
                debugMenu.SetActive(false);
                dm_open = false;
            }
            
        }
    }

    void Timer()
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

        if ( elapsedTime > 4000f && sp.stage == 4)
        {
            InGame.transmitFinish();
        }
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
