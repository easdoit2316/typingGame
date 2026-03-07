using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [Header("-----AudioSource-----")]
    [SerializeField] private AudioSource bgMusic;
    public AudioSource SFX;

    [Header("-----AudioClips-----")]
    public AudioClip Hurtclip;
    public AudioClip Powerupclip;
    public AudioClip Deathclip;
    public AudioClip destroyClip;

    public void Update()
    {
        bgMusic.volume = VolumeManager.Instance.music;
        SFX.volume = VolumeManager.Instance.sfx;
    }

    public void PlayHurt()
    {
        SFX.PlayOneShot(Hurtclip);
    }

    public void PlayPowerUp()
    {
        SFX.PlayOneShot(Powerupclip);
    }

    public void PlayDeath()
    {
        SFX.PlayOneShot(Deathclip);
    }

    public void PlayDestroy()
    {
        SFX.PlayOneShot(destroyClip);
    }
}
