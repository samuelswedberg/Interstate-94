using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool isRamp;

    MovementController mc;
    PlayerController pc;
    BoundBox boundBox;

    void Start()
    {
        mc = GetComponent<MovementController>();
        pc = FindObjectOfType<PlayerController>();
        boundBox = FindObjectOfType<BoundBox>();
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (isRamp == false && other.CompareTag("Player"))
        {
            Debug.Log("Damage");
            pc.isCrashed = true;
            boundBox.DisableBounds();
        }

        if (isRamp == true && other.CompareTag("Player"))
        {
            Debug.Log("Called Ramped()");
            pc.Ramped();
        }

        if (other.CompareTag("ObjKillZone"))
            {
                //Debug.Log("Destroy");
                Destroy(gameObject);
            }
    }
}
