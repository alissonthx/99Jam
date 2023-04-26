using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [HideInInspector]
    public Animator animEnemy;
    [HideInInspector]
    public SpriteRenderer sr;    

    void Start()
    {
        animEnemy = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();        
    }

    public void SetTrigger(string trigger)
    {
        animEnemy.SetTrigger(trigger);
    }
    void Update()
    {
        
    }
}
