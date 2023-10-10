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
            anim.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                anim.SetBool("pressed", true);
            }
            else if (anim.GetBool("pressed"))
            {
                anim.SetBool("pressed", false);
                menuAnimation.disableOnce = true;
            }
        }
        else
        {
            anim.SetBool("selected", false);
        }
    }

}
