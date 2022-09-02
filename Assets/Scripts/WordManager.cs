using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


[System.Serializable]
public class Word
{
    public char[] wordle = new char[5];
}

public class WordManager : MonoBehaviour
{
    public List<Word> wordList = new List<Word>();
    public string currentWord;
    public List<string> wordListString = new List<string>();

    private void Awake()
    {
        currentWord = wordListString[Random.Range(0, wordListString.Count)];
        Converter();
    }

    void Converter()
    {
        foreach (string wordle in wordListString)
        {
            Word temp = new Word();
            temp.wordle = wordle.ToCharArray();
            wordList.Add(temp);
        }
    }
}
