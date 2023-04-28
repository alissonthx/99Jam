using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private PlayerCollision coll;
    private PlayerController playerController;

    [Header("Scriptables")]
    [SerializeField]
    private EnemyReference enemyReference;

    [HideInInspector]
    public Rigidbody2D rb;
    private Animator bubbleAnim;

    private Animation anim;
    private PlayerBubble playerBubble;
    private EnemyMovement enemyMovement;


    [Space]
    [Header("Stats")]
    public float dashForce = 10;
    public float speed = 8;
    public float jumpForce = 14;

    [Space]
    [Header("Booleans")]    
    private bool earlyGame;
    private bool lateGame;

    public bool canMove;
    public bool inBubble;
    public bool hasDashed;
    public bool isDashing;
    public bool breath1To2;
    public bool breath2To3;

    private bool groundTouch;
    [Space]

    public int side = 1;

    [Space]
    [Header("Bubble Settings")]
    [SerializeField]
    private float bump = 10f;
    [SerializeField]
    private GameObject bubblePrefab1;
    [SerializeField]
    private GameObject bubblePrefab2;
    [SerializeField]
    private Transform bubblePoint;
    [SerializeField]
    private int bubbleStage = 0;

    [SerializeField]
    private bool firstZPressed = false;

    [Space]
    [Header("Polish")]
    public ParticleSystem jumpParticle;



    void Start()
    {
        canMove = true;
        coll = GetComponent<PlayerCollision>();
        playerController = GetComponent<PlayerController>();
        enemyMovement = GetComponent<EnemyMovement>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animation>();
    }


    void Update()
    {
        bubblePoint = transform.Find("BubblePoint" + side);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
        anim.SetHorizontalMovement(x, y, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            // anim.SetTrigger("jump");
            if (coll.onGround)
                Jump(Vector2.up);
        }

        if (coll.onGround && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }

        if (!coll.onGround && groundTouch)
        {
            groundTouch = false;
        }

        if (x > 0 && canMove)
        {
            side = 1;
            anim.Flip(side);
        }
        if (x < 0 && canMove)
        {
            side = -1;
            anim.Flip(side);
        }

        if (Input.GetButtonDown("Fire2") && !hasDashed && inBubble)
        {
            if (xRaw != 0 || yRaw != 0)
            {
                rb.gravityScale = 6;
                canMove = true;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                BubbleDash(xRaw, yRaw);
            }
        }

        // Bubble instantiates when player press fire3 button      

        if (Input.GetButtonDown("Fire3") && bubbleStage == 1 && coll.onGround && canMove)
        {
            // instantiate bubble 2 
            // anim.SetTrigger("bubble");
            StartCoroutine(DelayBubble(1f));

            playerBubble = GetComponent<PlayerBubble>();

            StartCoroutine(Instance(1f, bubblePrefab1));

            bubbleStage = 0;
            breath1To2 = false;
        }
        // Bubble instantiates when player press fire3 button
        if (Input.GetButtonDown("Fire3") && bubbleStage == 2 && coll.onGround && canMove)
        {
            // instantiate bubble 3
            // anim.SetTrigger("bubble");
            StartCoroutine(DelayBubble(1f));

            StartCoroutine(Instance(1f, bubblePrefab2));

            bubbleStage = 1;
            breath2To3 = false;
        }

        // Bubble instantiates 2 and 3 when the stage going 1-2 and 2-3
        // times pressed Z
        int timesZPressed = 0;

        if (Input.GetButtonDown("Fire1") && coll.onGround)
        {
            // anim.SetTrigger("inflate");
            timesZPressed++;

            if (timesZPressed == 1 && bubbleStage == 0)
            {
                bubbleStage++;
                breath1To2 = true;
                StartCoroutine(DelayBubble(1f));
                // Debug.Log("bubble2");

                // first time press Z
                firstZPressed = true;
            }
            else if (bubbleStage == 1 && firstZPressed == true)
            {
                bubbleStage++;
                breath2To3 = true;
                StartCoroutine(DelayBubble(1f));
                Debug.Log("bubble3");
                firstZPressed = false;
            }
            else if (timesZPressed == 1)
            {
                timesZPressed = 0;
                bubbleStage = 0;
            }
        }
    }

    // Coroutine to delay the bubble instantiate
    IEnumerator DelayBubble(float time)
    {
        canMove = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(time);
        canMove = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
    }

    IEnumerator Instance(float time, GameObject bubblePrefab)
    {
        yield return new WaitForSeconds(time);
        GameObject b2 = Instantiate(bubblePrefab, bubblePoint.position, Quaternion.identity);
        b2.GetComponent<PlayerBubble>().SetBubbleSide(side);
    }    

    // Coroutine to delay the player respawn
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1.1f);
        transform.position = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        canMove = true;
    }

    #region Bubble Dash
    private void BubbleDash(float x, float y)
    {
        hasDashed = true;
        // anim.SetTrigger("dash");

        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

        rb.velocity += dir.normalized * dashForce;
        StartCoroutine(bubbleDashWait(0.3f));
    }

    IEnumerator bubbleDashWait(float t)
    {
        FindObjectOfType<GhostTrail>().ShowGhost();

        StartCoroutine(RestrictDash());

        rb.gravityScale = 0;
        GetComponent<BetterJumping>().enabled = false;
        isDashing = true;

        yield return new WaitForSeconds(t);

        rb.gravityScale = 6;
        GetComponent<BetterJumping>().enabled = true;
        isDashing = false;
    }

    IEnumerator RestrictDash()
    {
        yield return new WaitForSeconds(0.1f);
        if (!inBubble)
        {
            isDashing = false;
        }
    }

    IEnumerator bubbleJump()
    {
        GetComponent<BetterJumping>().enabled = false;

        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * bump, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.3f);
        GetComponent<BetterJumping>().enabled = true;
    }

    IEnumerator DefeatEnemy(float time, Collision2D collision)
    {
        // enemyMovement.GetComponent<EnemyAnimation>().animEnemy.SetTrigger("die");
        enemyMovement.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        collision.gameObject.SetActive(false);
        Debug.Log("defeat enemy");
        yield return new WaitForSeconds(time);
    }

    private void InsideBubble()
    {
        inBubble = true;
        hasDashed = false;
        canMove = false;
        // anim.SetTrigger("insideBubble");
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    #endregion

    private void GroundTouch()
    {
        side = anim.sr.flipX ? -1 : 1;

        jumpParticle.Play();
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;
        else
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
    }

    private void Jump(Vector2 dir)
    {
        ParticleSystem particle = jumpParticle;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

        particle.Play();
    }

    private void Die()
    {
        // anim.SetTrigger("die");
        canMove = false;
        rb.velocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(Respawn());
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {            
            Die();            
        }

        if (collision.gameObject.CompareTag("Bubble2") && !coll.onGround)
        {
            StartCoroutine(bubbleJump());
        }
        if (collision.gameObject.CompareTag("Bubble3"))
        {
            InsideBubble();
            collision.gameObject.SetActive(false);
        }
    }

}
