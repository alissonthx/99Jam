using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{

    private Animator anim;
    private PlayerMovement playerMove;
    private PlayerCollision coll;

    [HideInInspector]
    public SpriteRenderer sr;

    #region Animation States
    private string currentAnimaton;
    const string PLAYER_IDLE = "player_idle";
    const string PLAYER_IDLE_B2 = "player_idle_b2";
    const string PLAYER_IDLE_B3 = "player_idle_b3";
    const string PLAYER_WALK = "player_walk";
    const string PLAYER_WALK_B2 = "player_walk_b2";
    const string PLAYER_WALK_B3 = "player_walk_b3";
    const string PLAYER_JUMP = "player_jump";
    const string PLAYER_JUMP_B2 = "player_jump_b2";
    const string PLAYER_JUMP_B3 = "player_jump_b3";
    const string PLAYER_FALL = "player_fall";
    const string PLAYER_INSIDE = "player_inside";
    const string BUBBLE_INFLATE_B2 = "bubble_inflate_b2";
    const string BUBBLE_INFLATE_B3 = "bubble_inflate_b3";
    const string BUBBLE_SHOT_B2 = "bubble_shot_b2";
    const string BUBBLE_SHOT_B3 = "bubble_shot_b3";
    const string PLAYER_DIE = "player_die";
    #endregion



    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponentInParent<PlayerCollision>();
        playerMove = GetComponentInParent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        anim.SetBool("onGround", coll.onGround);
        anim.SetBool("canMove", playerMove.canMove);
        anim.SetBool("breath1-2", playerMove.breath1To2);
        anim.SetBool("breath2-3", playerMove.breath2To3);
    }

    public void SetHorizontalMovement(float x, float y, float yVel)
    {
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);
    }

    private void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    // public void SetTrigger(string trigger)
    // {
    //     anim.SetTrigger(trigger);
    // }

    public AnimatorStateInfo GetCurrentAnimatorStateInfo()
    {
        return anim.GetCurrentAnimatorStateInfo(0);
    }

    public void Flip(int side)
    {
        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
}
