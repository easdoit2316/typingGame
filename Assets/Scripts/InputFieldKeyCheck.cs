using TMPro;
using UnityEngine;

public class InputFieldKeyCheck : MonoBehaviour
{
    public TMP_InputField inputField;

    void Update()
    {
        if (!inputField.isFocused) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            string typedWord = inputField.text.Trim();
            bool matched = false;

            foreach (string word in WordManager.instance.words)
            {
                if (string.Equals(word, typedWord, System.StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log("Matched: " + word);
                    matched = true;
                    break;
                }
            }

            for (int i = WordManager.instance.generated_words.Count - 1; i >= 0; i--)
            {
                WordObject word = WordManager.instance.generated_words[i];

                if (!word) continue;

                if (word.word == typedWord )
                {
                    word.MatchedWord();
                    break;
                }
            }

            inputField.text = "";
            inputField.ActivateInputField();
        }
    }
}