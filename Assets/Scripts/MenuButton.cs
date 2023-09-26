using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField]
    private MenuButtonController menuButtonController;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private MenuAnimation menuAnimation;
    [SerializeField]
    private int thisIndex;
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animatorFunctions.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                anim.SetBool("pressed", true);
            }
            else if (animatorFunctions.GetBool("pressed"))
            {
                anim.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            anim.SetBool("selected", false);
        }
    }
}
