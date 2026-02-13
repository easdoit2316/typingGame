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
    public List<Transform> spawners;
    private int spawnAmount;
    private int spawnLeangth;
    private int lengthCount = 0;

    private int score = 0;
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
        spawntime = 8f * difficulty;
        spawntimer = spawntime;

        gameSpeed = 2.5f * difficulty;
        lifePoint = 4 * difficulty;
        spawnAmount = 2 * difficulty;
        spawnLeangth = 4 * difficulty;
    }

    private void Update()
    {
        scoreText.text = score.ToString();

        spawntimer -= Time.deltaTime;
        if(spawntimer <= 0)
        {
            spawntimer = spawntime;
            WordManager.instance.WordGenerate(spawnLeangth, spawnAmount);
            spawnLeangth = 4 + lengthCount / (15 / difficulty);
            spawntime = 8 - lengthCount / (25 / difficulty);
            spawnAmount = 2 + lengthCount / (30 / difficulty);
            lengthCount += spawnAmount;
        }

        if (spawntime <= 1)
            spawntime = 1f;   

        if(spawnAmount >= 22)
            spawnAmount = 22;
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
        score += val;
    }
}
