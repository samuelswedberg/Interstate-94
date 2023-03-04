using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isRamp, isDangerous, isCoin;

    MovementController mc;
    public PlayerController pc;
    BoundBox boundBox;
    CoinSystem CoinSystem;
    public AudioSource explode;
    void Start()
    {
        mc = GetComponent<MovementController>();
        pc = FindObjectOfType<PlayerController>();
        boundBox = FindObjectOfType<BoundBox>();
        CoinSystem = FindObjectOfType<CoinSystem>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (isDangerous == true && other.CompareTag("Player"))
        {
            Debug.Log("Damage");
            pc.isCrashed = true;
            explode.Play();
            boundBox.DisableBounds();
        }

        if (isRamp == true && other.CompareTag("Player"))
        {
            Debug.Log("Called Ramped()");
            pc.Ramped();
        }

        if (isCoin == true && other.CompareTag("Player"))
        {
            Debug.Log("Cone collected");
            pc.coinCollect = true;
            Destroy(gameObject);
            CoinSystem.coincounter += 1;
        }

        if (other.CompareTag("ObjKillZone"))
            {
                //Debug.Log("Destroy");
                Destroy(gameObject);
            }
    }
}
