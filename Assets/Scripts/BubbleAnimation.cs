using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleAnimation : MonoBehaviour
{
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public SpriteRenderer sr;    

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();        
    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);
    }

    void Update()
    {
        
    }
}
