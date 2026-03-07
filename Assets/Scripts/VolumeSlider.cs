using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Scrollbar slider;
    public Scrollbar music;
    public Scrollbar sfx;

    public float SFXVolume;
    public float MusicVolume;

    void Start()
    {
        slider.value = VolumeManager.Instance.volume;
    }

    public void ChangeVolume(float value)
    {
        VolumeManager.Instance.volume = value;
        AudioListener.volume = value;
    }

    public void ChangeSFXVolume(float value)
    {
        VolumeManager.Instance.sfx = value;
    }

    public void ChangeMusicVolume(float value)
    {
        VolumeManager.Instance.music = value * 0.3f;
    }
}
