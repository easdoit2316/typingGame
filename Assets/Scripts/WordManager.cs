using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordManager : MonoBehaviour
{
    public static WordManager instance;
    private string[] lines;
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

        string filePath = "Assets/Scripts/Words.txt";
        string textFile = File.ReadAllText(filePath);
        if(textFile != null)
        {
            string fileContents = textFile;
            Debug.Log("File contents : " + fileContents);

            lines = fileContents.Split(", ");
            foreach(string line in lines)
            {
                Debug.Log("Line : " + line);
            }
        }
        else
        {
            Debug.LogError("Text file asset not assigned");
        }
    }

    private void Update()
    {
        
    }

    private string GetRandomWord(int minSize)
    {
        string tmpWord;
        tmpWord = lines[Random.Range(0,lines.Length)];

        while(tmpWord.Length > minSize)
        {
            tmpWord = lines[Random.Range(0, lines.Length)];
        }

        return tmpWord;
    }

}
