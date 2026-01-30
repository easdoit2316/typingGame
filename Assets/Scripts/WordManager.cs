using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordManager : MonoBehaviour
{
    public static WordManager instance;
    private string[] lines;
    public List<string> generated_words;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            generated_words = new List<string>();
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

            lines = fileContents.Split(", ");
        }
        else
        {
            Debug.LogError("Text file asset not assigned");
        }
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

    public void WordGenerate(int length, int quant)
    {
        for(int i = 0; i < quant; i++)
        {
            string newWord= GetRandomWord(length);
            generated_words.Add(newWord);
        }
    }
    public List<string> GetGeneratedWords()
    {
        return generated_words;
    }
}
