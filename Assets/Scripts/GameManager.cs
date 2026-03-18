using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private float gameSpeed;
    private int lifePoint;

    public float spawntime;
    private float spawntimer;
    private int spawnAmount;
    private int spawnLeangth;

    public int score = 0;
    public TMP_Text scoreText;

    public int difficulty; 

    public List<GameObject> healthAnims;
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

    private void Start()
    {
        spawntime = 8f / difficulty;
        spawntimer = spawntime;

        gameSpeed = 2.5f * difficulty;
        lifePoint = 4;
        spawnAmount = 2 * difficulty;
        spawnLeangth = 4 * difficulty;
    }

    private void Update()
    {
        scoreText.text = score.ToString();

        // Difficulty progression
        float progress = Mathf.FloorToInt(GameTimer.instance.timeElapsed % 60f);
        
        spawnLeangth = 4 * difficulty + (Mathf.RoundToInt(progress) / 20) * difficulty;
        spawnAmount = 2 * difficulty + (Mathf.RoundToInt(progress) / 20) * difficulty;
        spawntime = 8f - Mathf.RoundToInt(progress) / 13;

        if(spawntime <= 0)
        {
            spawntime = 1 / difficulty;
        }

        // Spawn timer
        spawntimer -= Time.deltaTime;

        if (spawntimer <= 0f)
        {
            spawntimer = spawntime;
            //SoundManager.instance.PlayDestroy();
            WordManager.instance.WordGenerate(spawnLeangth, spawnAmount);
        }

        AudioListener.volume = VolumeManager.Instance.volume * 2;
    }

    public void DecreaseLife()
    {
        healthAnims[4 - GetLifePoint()].SetActive(false);
        SoundManager.instance.PlayHurt();
        lifePoint--;
        if (lifePoint < 0)
        {
            lifePoint = 0;
        }

        if (lifePoint == 0)
        {
            SoundManager.instance.PlayDeath();
            Time.timeScale = 0.4f;
            ScoreManager.Instance.setScore();
            ScoreManager.Instance.setTime();
            FadeController.instance.FadeToScene("Death");
        }
    }

    public void IncreaseLife()
    {
        if (lifePoint < 4)
        {
            lifePoint++;
            healthAnims[4 - GetLifePoint()].SetActive(true);
            SoundManager.instance.PlayPowerUp();
        }
    }

    private void SetGameSpeed(float _gameSpeed)
    {
        gameSpeed = _gameSpeed;
    }
    public float GetGameSpeed()
    {
        return gameSpeed;
    }
    public int GetLifePoint()
    {
        return lifePoint;
    }

    public void IncreasePoint(int val)
    {
        //int finalScore = Mathf.RoundToInt(val * UpgradeManager.Instance.scoreMultiplier);

        int finalScore = val;

        score += finalScore;

        //UpgradeManager.Instance.lettersTyped += val;

        //UpgradeManager.Instance.CheckForUpgrade(score);
    }
}
