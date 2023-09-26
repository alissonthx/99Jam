using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField]
    private MenuButtonController menuButtonController;
    public bool disableOnce;
    private void PlaySound(AudioClip wichSound)
    {
        if (!disableOnce)
        {
            menuButtonController.audioSource.PlayOneShot(wichSound);
        }
        else
        {
            disableOnce = false;
        }
    }
}