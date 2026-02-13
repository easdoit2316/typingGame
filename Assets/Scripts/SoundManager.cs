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

    public void PlayHurt()
    {
        SFX.PlayOneShot(Hurtclip);
    }

    public void PlayPowerUp()
    {
        SFX.PlayOneShot(Hurtclip);
    }

    public void PlayDeath()
    {
        SFX.PlayOneShot(Deathclip);
    }
}
