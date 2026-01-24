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
    public int spawnAmount;
    public int spawnLeangth;

    private void Awake()
    {
        spawntimer = spawntime;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        spawntime = 8f;
    }

    private void Start()
    {
        gameSpeed = 1f;
        lifePoint = 3;
    }

    private void Update()
    {
        spawntimer -= Time.deltaTime;
        if(spawntimer <= 0)
        {
            spawntimer = spawntime;
            WordManager.instance.WordGenerate(spawnLeangth, spawnAmount);
        }
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
