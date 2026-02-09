using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WordObject : MonoBehaviour
{
    [SerializeField] public string word;
    [SerializeField] private Vector2 _destination;
    [SerializeField] private GameObject _textUI;
    public void SetWord(string _word)
    {
        word= _word;
    }
    public void SetTextUI(GameObject t)
    {
        _textUI = t;
    }
    private void Start()
    {
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destination, 0.001f * GameManager.instance.GetGameSpeed());

        if(transform.position.x == _destination.x && transform.position.y == _destination.y)
        {
            GameManager.instance.DecreaseLife();
            MatchedWord();
        }
    }

    public void MatchedWord()
    {
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
