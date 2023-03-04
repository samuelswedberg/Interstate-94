using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    public int health = 1;
    public bool playerMovement;

    MovementController ob;

    public bool isCrashed;
    public BoxCollider2D boxCollider;
    public float jumpTime = .25f;
    public bool isRamping;
    public bool isLanding, coinCollect = false;
    BoundBox boundBox;

    GameState GameState;
    public bool isGameOver;

    public AudioSource coin;



    void Start()
    {
        ob = FindObjectOfType<MovementController>();
        isCrashed = false;
        playerMovement = false;
        boundBox = FindObjectOfType<BoundBox>();
        GameState = FindObjectOfType<GameState>();
    }

    void Update()
    {
        if (isRamping == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (isLanding == true && transform.position.y < -0.25f)
            {
                rb.gravityScale = 0;
                boxCollider.enabled = true;
                isRamping = false;
                isLanding = false;
                boundBox.EnableHorizontal();
            }

        if(coinCollect == true)
        {
            coin.Play();
            coinCollect = false;
        }
    }

    void FixedUpdate()
    {
        if (isCrashed == false && playerMovement == true)
        {
            Move();
        }
        if (isCrashed == true)
        {
            Crash();

            if (isGameOver == false)
            {
                isGameOver = true;
                GameState.EndingGame();
            }
        }
    }

    void Move()
    {
        if (playerMovement == true)
        {
            if (Input.GetAxis("Horizontal") < 0 && isRamping == false)
            {
                movement.x = movement.x * 4f;
            }
            else
            {
                #pragma warning disable 1717 // disables warning for CS1717 (a = a)
                movement.x = movement.x;
                #pragma warning restore 1717 // restores warning for CS1717 (a = a)

            }
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
    public void Crash()
    {
        Debug.Log("Crashed");
        playerMovement = false;
        GameState.EndTimer();
        transform.Translate(Vector2.left * ob.OBspeed * Time.deltaTime);
    }

    public void Ramped()
    {
        StartCoroutine(doRamped());
    }
    IEnumerator doRamped()
    {
        Debug.Log("Ramped() Heard");
        boxCollider.enabled = false;
        isRamping = true;
        boundBox.DisableHorizontal();

        rb.gravityScale = -30;
        yield return new WaitForSeconds(jumpTime);
        rb.gravityScale = -15;
        yield return new WaitForSeconds(jumpTime);
        rb.gravityScale = 0;
        yield return new WaitForSeconds(jumpTime);
        rb.gravityScale = 15;
        yield return new WaitForSeconds(jumpTime);
        rb.gravityScale = 30;
        yield return new WaitForSeconds(jumpTime);
        if( transform.position.y > -.25f )
        {
            rb.gravityScale = 60;
            yield return new WaitForSeconds(jumpTime);
        }
        if( transform.position.y > -.25f )
        {
            rb.gravityScale = 100;
            yield return new WaitForSeconds(jumpTime);
            Debug.Log("Calling isLanding");
            isLanding = true;
        }
        if( transform.position.y < -.25f )
        {
            rb.gravityScale = 0;
            boxCollider.enabled = true;
            isRamping = false;
            isLanding = false;
            boundBox.EnableHorizontal();
        }
    }
}
