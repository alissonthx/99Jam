using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask Ground;

    public bool rightCollision;
    public bool leftCollision;

    [Header("Enemy Collision")]

    public float collisionRadius = 0.15f;

    public Vector2 rightOffset;
    public Vector2 leftOffset;
    private Color debugCollisionColor = Color.red;


    void Update()
    {
        rightCollision = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, Ground);
        leftCollision = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, Ground);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
