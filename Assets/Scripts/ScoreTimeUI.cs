using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreTimeUI : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text time;
    private void Start()
    {
        SetScore();
        SetTime();
    }
    private void Update()
    {
        
        
    }
    public void SetScore()
    {
        score.text = "Score : " + ScoreManager.Instance.score;
    }
    public void SetTime()
    {
        time.text = "Time : " + ScoreManager.Instance.timerText;
    }
}
