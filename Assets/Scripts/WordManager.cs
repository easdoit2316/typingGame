using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordManager : MonoBehaviour
{
    public static WordManager instance;

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

            string[] lines = fileContents.Split(", ");
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

}
