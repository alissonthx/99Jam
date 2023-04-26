using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    [Header("Layers")]
    public LayerMask groundLayer;
    // public LayerMask bubbleLayer;

    [Space]

    public bool onGround;       
    // public bool rightCollision;  
    // public bool leftCollision;  

    [Space]

    [Header("Player Collision")]

    public float collisionRadius = 0.25f;
    
    public Vector2 bottomOffset;
    // public Vector2 rightOffset;
    // public Vector2 leftOffset;
    private Color debugCollisionColor = Color.red;

    void Start()
    {
        
    }

    void Update()
    {  
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);                                                       
        // rightCollision = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, collisionRadius, bubbleLayer);                        
        // leftCollision = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, collisionRadius, bubbleLayer);                        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        var positions = new Vector2[] {bottomOffset};

        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);        
        // Gizmos.DrawWireSphere((Vector2)transform.position  + rightOffset, collisionRadius);        
        // Gizmos.DrawWireSphere((Vector2)transform.position  + leftOffset, collisionRadius);        
    }
}
