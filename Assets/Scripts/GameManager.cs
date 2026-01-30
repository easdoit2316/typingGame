using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        spawntime = 8f;
        spawntimer = spawntime;

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
        gameSpeed = 1f;
        lifePoint = 3;
        spawntimer = spawntime;
        spawnAmount = 1;
        spawnLeangth = 4;
    }

    private void Update()
    {
        spawntimer -= Time.deltaTime;
        if(spawntimer <= 0)
        {
            spawntimer = spawntime;
            WordManager.instance.WordGenerate(spawnLeangth, spawnAmount);
            lengthCount++;
            spawnLeangth = 4 + lengthCount / 15;
            spawntime = 8 - lengthCount / 10;
        }

        if (spawntime <= 0)
            spawntime = 0.7f;   
    }

    private void DecreaseLife()
    {
        lifePoint--;
        if (lifePoint < 0)
        {
            lifePoint = 0;
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
