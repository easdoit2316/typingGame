using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string score = GameManager.instance.scoreText.text;
    public string timerText = GameTimer.instance.timerText.text;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setScore()
    {
        score = GameManager.instance.scoreText.text;
    }

    public void setTime()
    {
        timerText = GameTimer.instance.timerText.text;
    }

        
}
