using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private EnemyMovement enemyMovement;

    [Space]

    [Header("Bubble Stats")]

    [SerializeField]
    private float speed;

    [SerializeField]
    private float gForce;
    [SerializeField]
    private float lifetime;
    private BubbleAnimation anim;
    private PlayerMovement playerMove;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private BubbleCollision col;

    private void Awake()
    {
        anim = GetComponentInChildren<BubbleAnimation>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        col = GetComponent<BubbleCollision>();
        playerMove = GetComponent<PlayerMovement>();
        enemyMovement = GetComponent<EnemyMovement>();
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y - Time.deltaTime * gForce);
    }

    private void FixedUpdate()
    {
        if (col.bottomCollision)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    // bubble
    public void SetBubbleSide(int side)
    {
        if (side == 1)
        {
            speed *= 1f;
        }
        else
        {
            speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        // if touchs another bubble projects bubble to foward
        if (collision.gameObject.tag == "Bubble2")
        {
            Vector3 myPosition = transform.position;
            Vector3 otherPosition = collision.transform.position;


            if (myPosition.z > otherPosition.z)
            {

                Vector3 newPosition = otherPosition;
                newPosition.z -= 0.1f;
                transform.position = newPosition;
            }
        }
    }

}
