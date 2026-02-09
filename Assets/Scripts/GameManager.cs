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
            lengthCount++;
            spawnLeangth +=lengthCount / 15;
            spawntime -= lengthCount / 10;
        }

        if (spawntime <= 0)
            spawntime = 0.7f;   
    }

    public void DecreaseLife()
    {
        healthAnims[4 - GetLifePoint()].SetActive(false);
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
