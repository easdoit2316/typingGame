using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class WordManager : MonoBehaviour
{
    public static WordManager instance;
    private string[] lines;
    public List<WordObject> generated_words = new List<WordObject>();
    public GameObject wordObjectPrefab;
    [SerializeField] private GameObject _destination;
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
            string newWord = GetRandomWord(length);
            WordObject n_Word = Instantiate(wordObjectPrefab.GetComponent<WordObject>(), parent: GameManager.instance.spawners[Random.Range(0,22)]);
            n_Word.SetWord(newWord);
            n_Word.SetDestination(_destination.transform.position);
            generated_words.Add(n_Word);
        }
    }
    public List<WordObject> GetGeneratedWords()
    {
        return generated_words;
    }
}
