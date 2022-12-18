using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool movementStatus;

    public bool Obstacle;
    public float OBspeed = 15f;

    public bool BG;
    public float BGspeed = 2f;
    public bool FG;
    public float FGspeed = 15f;

    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
        movementStatus = true;
    }

    void Update()
    {
        if (movementStatus == true)
        {
             if (BG == true)
            {
                BGScroll();
            }
            if (FG == true)
            {
                FGScroll();
            }
            if (Obstacle == true)
            {
                ObstacleScroll();
            }
        }
    }

    void BGScroll()
    {
        transform.Translate(Vector3.left * BGspeed * Time.deltaTime);
        if (transform.position.x < -32.9f)
        {
            transform.position = StartPosition;
        }
    }

    void FGScroll()
    {
        transform.Translate(Vector3.left * FGspeed * Time.deltaTime);
        if (transform.position.x < -32.9f)
        {
            transform.position = StartPosition;
        }
    }

    void ObstacleScroll()
    {
        transform.Translate(Vector2.left * OBspeed * Time.deltaTime);
    }
}
