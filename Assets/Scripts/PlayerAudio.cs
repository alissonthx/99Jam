using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField]
    private AudioSource footstepsAudioSource;
    private AudioSource jumpAudioSource;
    [SerializeField]
    private AudioClip[] footstepsAudioClipDirt;
    private AudioClip[] footstepsAudioClipGrass;
    private AudioClip[] footstepsAudioClipStone;
    private AudioClip[] footstepsAudioClipJump;

    private void Footsteps(string surface)
    {
        switch (surface)
        {
            case "Dirt":
                footstepsAudioSource.PlayOneShot(footstepsAudioClipDirt[(Random.Range(0, footstepsAudioClipDirt.Length))]);
                break;
            case "Grass":
                footstepsAudioSource.PlayOneShot(footstepsAudioClipGrass[(Random.Range(0, footstepsAudioClipGrass.Length))]);
                break;
            case "DirtStone":
                footstepsAudioSource.PlayOneShot(footstepsAudioClipStone[(Random.Range(0, footstepsAudioClipStone.Length))]);
                break;
        }
    }

    private void JumpSound()
    {
        jumpAudioSource.PlayOneShot(footstepsAudioClipJump[(Random.Range(0, footstepsAudioClipJump.Length))]);
    }
}
