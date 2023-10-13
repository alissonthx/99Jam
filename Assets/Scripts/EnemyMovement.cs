using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyCollision coll;
    private EnemyAnimation animEnemy;
    public Rigidbody2D rbEnemy;
    private SpriteRenderer sr;

    [Header("Stats")]
    public int side = 1;

    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private bool facingRight = true;

    void Start()
    {
        coll = GetComponent<EnemyCollision>();        
        rbEnemy = GetComponent<Rigidbody2D>();
        animEnemy = GetComponent<EnemyAnimation>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

    }
    
    IEnumerator EnemyInsideBubble(float time)
    {
        animEnemy.SetTrigger("insideBubble");
        rbEnemy.constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(time);
        EnemyOutsideBubble();
    }

    private void EnemyOutsideBubble()
    {
        animEnemy.SetTrigger("setExitBubble");                
        rbEnemy.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bubble2")
        {
            StartCoroutine(EnemyInsideBubble(3f));
            collision.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        // moves enemy in the direction it's facing
        float horizontalMovement = facingRight ? speed : -speed;
        rbEnemy.velocity = new Vector2(horizontalMovement, rbEnemy.velocity.y);

        // verifies if enemy is colliding with a wall
        if (coll.rightCollision && facingRight)
        {
            Flip();
        }
        else if (coll.leftCollision && !facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        sr.flipX = !sr.flipX;
    }

}
