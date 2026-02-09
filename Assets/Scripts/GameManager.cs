using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

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
        spawntime = 8f;
        spawntimer = spawntime;

        gameSpeed = 2.5f;
        lifePoint = 4;
        spawnAmount = 2;
        spawnLeangth = 4;
    }

    private void Update()
    {
        spawntimer -= Time.deltaTime;
        if(spawntimer <= 0)
        {
            spawntimer = spawntime;
            WordManager.instance.WordGenerate(spawnLeangth, spawnAmount);
            spawnLeangth = 4 + lengthCount / 10;
            spawntime = 8 - lengthCount / 20;
            spawnAmount = 2 + lengthCount / 25;
            lengthCount += spawnAmount;
        }

        if (spawntime <= 1)
            spawntime = 1f;   
    }

    public void DecreaseLife()
    {
        healthAnims[4 - GetLifePoint()].SetActive(false);
        lifePoint--;
        if (lifePoint < 0)
        {
            lifePoint = 0;
        }

        if(lifePoint == 0)
        {
            if (lifePoint == 0)
            {
                Time.timeScale = 0.4f;
                FadeController.instance.FadeToScene("Death");
            }
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
}
