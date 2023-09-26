using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeFields]
    private MenuButtonController menuButtonController;
    public bool disableOnce;
    if(!disableOnce){
        menuButtonController.audioSource.PlayOneShot(wichSound);
    }else{
        disableOnce = false;
    }
}