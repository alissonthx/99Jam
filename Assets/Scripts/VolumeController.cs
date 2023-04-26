using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private float volumeMaster, volumeSFX, volumeMusic;
    [SerializeField]
    private Slider sliderMaster, sliderSFX, sliderMusic;
    [SerializeField]
    GameObject[] Music;

    private void Start()
    {
        sliderMaster.value = PlayerPrefs.GetFloat("Master");
        sliderSFX.value = PlayerPrefs.GetFloat("SFX");
        sliderMusic.value = PlayerPrefs.GetFloat("Music");
    }

    public void VolumeMaster(float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
        PlayerPrefs.SetFloat("Master", volumeMaster);
    }
    public void VolumeSFX(float volume)
    {
        volumeSFX = volume;
        GameObject[] SFX = GameObject.FindGameObjectsWithTag("SFX");
        for (int i = 0; i < SFX.Length; i++)
        {
            SFX[i].GetComponent<AudioSource>().volume = volumeSFX;
        }
        PlayerPrefs.SetFloat("SFX", volumeSFX);
    }
    public void VolumeMusic(float volume)
    {
        volumeMusic = volume;
        GameObject[] Music = GameObject.FindGameObjectsWithTag("Music");
        for (int i = 0; i < Music.Length; i++)
        {
            Music[i].GetComponent<AudioSource>().volume = volumeMusic;
        }
        PlayerPrefs.SetFloat("Music", volumeMusic);
    }
}
