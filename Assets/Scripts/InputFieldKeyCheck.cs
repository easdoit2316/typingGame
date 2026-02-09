using TMPro;
using UnityEngine;

public class InputFieldKeyCheck : MonoBehaviour
{
    public TMP_InputField inputField;

    void Start()
    {
        inputField.onSubmit.AddListener(OnSubmit);
        // If onSubmit doesn't fire on your TMP version:
        // inputField.onEndEdit.AddListener(OnSubmit);
    }

    void OnSubmit(string typedText)
    {
        typedText = typedText.Trim();
        if (typedText.Length == 0) return;

        // Check words
        for (int i = WordManager.instance.generated_words.Count - 1; i >= 0; i--)
        {
            WordObject word = WordManager.instance.generated_words[i];
            if (!word) continue;

            if (string.Equals(word.word, typedText, System.StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Matched: " + word.word);
                word.MatchedWord();
                break;
            }
        }

        inputField.text = "";
        inputField.ActivateInputField();
    }
}