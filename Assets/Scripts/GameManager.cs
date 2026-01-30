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
        spawntime = 3f;
        spawntimer = spawntime;

        gameSpeed = 1f;
        lifePoint = 3;
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
            spawnLeangth +=lengthCount / 15;
            spawntime -= lengthCount / 10;
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
