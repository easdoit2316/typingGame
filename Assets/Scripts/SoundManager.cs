using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("-----AudioSource-----")]
    [SerializeField] private AudioSource bgMusic;

    [Header("-----AudioClips-----")]
    public AudioClip Hurtclip;
    public AudioClip Powerupclip;
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
}
