using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputDetector : MonoBehaviour
{
    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    private string currentWord = "WakaWaka";

    private void Start()
    {
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        SetRemainingWord(currentWord);
    }
    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;

            if (keyPressed.Length == 1)
            {
                EnterLetter(keyPressed);
            }
        }
    }

    void EnterLetter(string typedLetter)
    {
        if (IsCorrect(typedLetter))
        {
            RemoveLetter();
            if (IsComplete())
            {
                SetCurrentWord();
            }

        }
    }

    private bool IsCorrect(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsComplete()
    {
        return remainingWord.Length == 0;
    }
}