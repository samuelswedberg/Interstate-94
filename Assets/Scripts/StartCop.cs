using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCop : MonoBehaviour
{
    float speed = 5f;
    public bool copMovement;

    void Start()
    {
        copMovement = false;
    }
    void Update()
    {
        if ( copMovement == true )
        {
            CopMovement();
        }
    }
    public void CopMovement()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("ObjKillZone"))
        {
            Destroy(gameObject);
        }
    }
}
