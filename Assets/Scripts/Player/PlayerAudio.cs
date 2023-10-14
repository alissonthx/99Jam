using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource footstepsAudioSource;
    // [SerializeField]
    // private AudioSource jumpAudioSource;

    [SerializeField]
    private AudioClip[] footstepsAudioClipDirt;
    [SerializeField]
    private AudioClip[] footstepsAudioClipGrass;
    [SerializeField]
    private AudioClip[] footstepsAudioClipStone;
    // [SerializeField]
    // private AudioClip[] footstepsAudioClipJump;  
    private PlayerCollision coll;

    void Start()
    {
        coll = GetComponentInParent<PlayerCollision>();        
    }  

    private void Footsteps()
    {
        switch (coll.surface)
        {
            case "Dirt":
                footstepsAudioSource.PlayOneShot(footstepsAudioClipDirt[(Random.Range(0, footstepsAudioClipDirt.Length))]);
                break;
            case "Grass":
                footstepsAudioSource.PlayOneShot(footstepsAudioClipGrass[(Random.Range(0, footstepsAudioClipGrass.Length))]);
                break;
            case "Stone":
                footstepsAudioSource.PlayOneShot(footstepsAudioClipStone[(Random.Range(0, footstepsAudioClipStone.Length))]);
                break;
        }
    }

    private void JumpSound()
    {
        // jumpAudioSource.PlayOneShot(footstepsAudioClipJump[(Random.Range(0, footstepsAudioClipJump.Length))]);
    }
}
