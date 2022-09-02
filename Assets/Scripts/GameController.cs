using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public WordManager wordManager;
    public char[] wordInput = new char[5];
    public char[] word = new char[5];
    
    public List<Row> rows=new List<Row>();

    private int letterCounter = 0;
    private int currentRow = 0;
    private int currentCounter = 0;

    private void Start()
    {
        word = wordManager.currentWord.ToCharArray();
    }

    public void SubmitLatter()
    {
        string checkStr = new string(wordInput);
        if (!wordManager.wordListString.Contains(checkStr))
        {
            Debug.Log("Bu kelime tanımlı değil.");
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (wordInput[i]=='\0')
                {
                    Debug.Log("Kelimeyi tamamla");
                    break;
                    
                }
                else if (word[i] == wordInput[i])
                {
                    rows[currentRow].rowImage[i].sprite = null;
                    rows[currentRow].rowImage[i].color = Color.green;
                    currentCounter++;
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (wordInput[i] == word[j])
                        {
                            rows[currentRow].rowImage[i].sprite = null;
                            rows[currentRow].rowImage[i].color = Color.yellow;
                            break;
                            
                        }
                        else
                        {
                            rows[currentRow].rowImage[i].sprite = null;
                            rows[currentRow].rowImage[i].color = Color.grey;
                        }
                    }
                }
                
            }

            if (currentCounter >= 5)
            {
                Debug.Log("Winner");
            }
            else
            {
                currentCounter = 0;
                currentRow++;
                letterCounter = 0;
            }
        }
    }
    

    public void InputLetter(string letter)
    {
        if (letterCounter<5)
        {
        wordInput[letterCounter] = letter.ToCharArray()[0];
        rows[currentRow].rowText[letterCounter].text = letter;
        letterCounter++;
        }
    }

    public void DeleteLetter()
    {
        if (letterCounter>=1)
        {
            wordInput[letterCounter - 1] = ' ';
            rows[currentRow].rowText[letterCounter - 1].text = "";
            letterCounter--;
        }
    }
    
    
    
    
    
    
    
    
}
