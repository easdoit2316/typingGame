using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using TMPro;

public class WordObject : MonoBehaviour
{
    [SerializeField] public string word;
    [SerializeField] private Vector2 _destination;
    [SerializeField] private GameObject _textUI;

    [SerializeField] private bool isHealWord = false;
    [SerializeField] private bool isDoubleWord = false;
    public void SetWord(string _word)
    {
        word= _word;
    }
    public void SetTextUI(GameObject t)
    {
        _textUI = t;
    }

    public void SetHeal(bool val)
    {
        isHealWord = val;
    }

    public bool IsHealWord()
    {
        return isHealWord;
    }

    public void SetDouble(bool val)
    {
        isDoubleWord = val;
    }

    public bool IsDoubleWord()
    {
        return isDoubleWord;
    }
    private void Start()
    {
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destination, 0.1f * GameManager.instance.GetGameSpeed() * Time.deltaTime);

        if(transform.position.x == _destination.x && transform.position.y == _destination.y)
        {
            GameManager.instance.DecreaseLife();
            if(isDoubleWord)
                GameManager.instance.DecreaseLife();
            Destroy(_textUI.gameObject);
            Destroy(this.gameObject);
            WordManager.instance.words.Remove(word);
            WordManager.instance.generated_words.Remove(this);
        }
    }

    public void MatchedWord()
    {
        if(isHealWord)
        {
            GameManager.instance.IncreaseLife();
        }

        GameManager.instance.IncreasePoint(word.Length);
        Destroy(_textUI.gameObject);
        Destroy(this.gameObject);
        WordManager.instance.words.Remove(word);
        WordManager.instance.generated_words.Remove(this);
    }

    public void SetDestination(Vector3 _des)
    {
        _destination = (Vector2)_des;
    }
    public string GetWord()
    {
        return word;
    }
}
