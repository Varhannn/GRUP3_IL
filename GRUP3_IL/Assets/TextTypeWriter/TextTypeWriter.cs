using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextTypeWriter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh; // Reference to TextMeshPro UI component
    [SerializeField] private string textToType;      // String to be typed out
    [SerializeField] private float typingSpeed;     // Speed of typing (characters per second)
    [SerializeField] private float punctuationDelay; // Delay after punctuation (optional)

    private int currentCharacterIndex;
    private bool isTyping;

    public void Start()
    {
        isTyping = true;
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        currentCharacterIndex = 0;

        while (currentCharacterIndex < textToType.Length)
        {
            textMesh.text = textToType.Substring(0, currentCharacterIndex + 1);

            char currentChar = textToType[currentCharacterIndex];
            bool isPunctuation = IsPunctuation(currentChar);

            yield return new WaitForSeconds(isPunctuation ? punctuationDelay : 1f / typingSpeed);

            currentCharacterIndex++;
        }

        isTyping = false;
    }

    private bool IsPunctuation(char c)
    {
        return ".?!,;:\'/\\()[]{}<>".IndexOf(c) != -1;
    }
}
