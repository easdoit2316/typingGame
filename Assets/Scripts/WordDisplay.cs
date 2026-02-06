using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    public TMP_Text text;
    public Transform target;
    public Vector3 offset;


    private void Update()
    {
        if (target == null) return;

        Vector3 screenPos = target.position;
        transform.position = screenPos + offset;
    }

    public void setWord(WordObject word)
    {
        text.text = word.GetWord();
        target = word.transform;
    }
}
