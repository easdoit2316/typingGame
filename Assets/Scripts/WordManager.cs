using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;
using System;

public class WordManager : MonoBehaviour
{
    public static WordManager instance;
    private string[] lines;
    public List<WordObject> generated_words = new List<WordObject>();
    public List<string> words = new List<string>();
    public GameObject wordObjectPrefab;
    [SerializeField] private GameObject _destination;

    [SerializeField] private WordDisplay wordDisplayPrefab;
    [SerializeField] private Canvas canvas;
    private List< WordDisplay> myDisplays = new List<WordDisplay>();

    [SerializeField] private float healChance = 0.05f;
    [SerializeField] private float doubleChance = 0.05f;

    public static Action<string> OnWordTyped;
    public static Action<int> OnWordDestroyed;
    public static Action OnPlayerHit;
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

        if (canvas == null)
            canvas = FindObjectOfType<Canvas>();
    }

    private string GetRandomWord(int minSize)
    {
        string tmpWord;
        tmpWord = lines[UnityEngine.Random.Range(0,lines.Length)];

        while(tmpWord.Length > minSize)
        {
            tmpWord = lines[UnityEngine.Random.Range(0, lines.Length)];
        }

        return tmpWord;
    }

    public void WordGenerate(int length, int quant)
    {
        for (int i = 0; i < quant; i++)
        {
            bool spawnHeal = UnityEngine.Random.value < healChance;
            
            bool spawnDouble = UnityEngine.Random.value < doubleChance;

            int finalLength = length;

            if (spawnHeal)
            {
                finalLength += UnityEngine.Random.Range(3, 5); // +3 or +4 letters
                spawnDouble = false;
            }

            string newWord = GetRandomWord(finalLength);

            Vector3 spawnPos = GetRandomSpawnPosition();

            WordObject n_Word = Instantiate(
                wordObjectPrefab.GetComponent<WordObject>(),
                spawnPos,
                Quaternion.identity
            );

            WordDisplay myDisplay = Instantiate(wordDisplayPrefab, canvas.transform);
            myDisplays.Add(myDisplay);

            n_Word.SetWord(newWord);
            if(spawnHeal)
            {
                n_Word.SetHeal(true);
            }
            if(spawnDouble)
            {
                n_Word.SetDouble(true);
            }
            n_Word.SetDestination(_destination.transform.position);
            myDisplay.setWord(n_Word);
            n_Word.SetTextUI(myDisplay.gameObject);

            generated_words.Add(n_Word);
            words.Add(n_Word.word);
        }
    }
    public List<WordObject> GetGeneratedWords()
    {
        return generated_words;
    }

    Vector3 GetRandomSpawnPosition()
    {
        int side = UnityEngine.Random.Range(0, 4);
        Vector3 pos;

        switch (side)
        {
            case 0: // Left
                pos = Camera.main.ViewportToWorldPoint(new Vector3(-0.1f, UnityEngine.Random.value, 0));
                break;

            case 1: // Right
                pos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, UnityEngine.Random.value, 0));
                break;

            case 2: // Top
                pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.value, 1.1f, 0));
                break;

            default: // Bottom
                pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.value, -0.1f, 0));
                break;
        }

        pos.z = 0;
        return pos;
    }
}
