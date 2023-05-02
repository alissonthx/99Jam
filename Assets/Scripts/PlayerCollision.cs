using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool onGround;

    [Space]

    [Header("Player Collision")]
    public string surface;
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset;
    private Color debugCollisionColor = Color.red;

    private PlayerMovement playerMove;

    void Start()
    {
        playerMove = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Dirt":
                surface = "Dirt";
                break;
            case "Grass":
                surface = "Grass";
                break;
            case "Stone":
                surface = "Stone";
                break;
            case "Enemy":
                playerMove.Die();
                break;
            case "Bubble2":
                if (!onGround)
                {
                    StartCoroutine(playerMove.BubbleJump());
                }
                break;
            case "Bubble3":
                playerMove.InsideBubble();
                collision.gameObject.SetActive(false);
                break;
        }
    }
}
