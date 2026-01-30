using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WordObject : MonoBehaviour
{
    [SerializeField] private string word;
    [SerializeField] private Vector2 _destination;
    public void SetWord(string _word)
    {
        word= _word;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destination, 0.1f);
    }
    public void SetDestination(Vector3 _des)
    {
        _destination = (Vector2)_des;
    }
}
