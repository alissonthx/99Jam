using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
 [Header("Layers")]
    public LayerMask layerMask;

    public bool bottomCollision;
    public bool rightCollision;
    public bool leftCollision;

    [Header("Bubble Collision")]

    public float collisionRadius = 0.3f;

    public Vector2 rightOffset;
    public Vector2 leftOffset;
    public Vector2 bottomOffset;
    private Color debugCollisionColor = Color.red;

    void Update()
    {
        bottomCollision = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, layerMask);
        rightCollision = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, layerMask);
        leftCollision = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, layerMask);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomOffset, rightOffset, leftOffset };

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, collisionRadius);
    }
}
