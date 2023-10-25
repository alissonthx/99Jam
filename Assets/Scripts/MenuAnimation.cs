using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public bool disableOnce;
    public void PlaySound(AudioClip wichSound)
    {
        if (!disableOnce)
        {
            audioSource.PlayOneShot(wichSound);
        }
        else
        {
            disableOnce = false;
        }
    }
}