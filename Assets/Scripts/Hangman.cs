using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
public class Hangman : MonoBehaviour
{
    public TextMeshProUGUI tex1;
    public TextMeshProUGUI tex2;
    public TextMeshProUGUI tex3;
    public TextMeshProUGUI tex4;
    public TextMeshProUGUI tex5;
    public TextMeshProUGUI tex6;
    public TextMeshProUGUI tex7;
    public GameObject inputField;
    public GameObject imageObj;

    public GameObject winPanel;
    public GameObject losePanel;

    public Image img;
    public Sprite man1;
    public Sprite man2;
    public Sprite man3;
    public Sprite man4;
    public Sprite man5;

    public Main main;

    static String[] wordBank = {"asset", "budget", "credit", "debit", "finance"};
    static System.Random rand = new System.Random();
    int ranNum = 0;
    String word = "LOLL";

    String guess = "";
    int wordLength = 0;
    int livesLeft = 4;

    // Start is called before the first frame update
    void Awake()
    {
        guess = "";
        wordLength = 0;
        livesLeft = 4;





        ranNum = ((int)Math.Floor(Hangman.rand.NextDouble() * (5)));
        word = wordBank[ranNum];
        wordLength = word.Length;


        TextMeshProUGUI[] texArr = {tex1, tex2, tex3, tex4, tex5, tex6, tex7};
        for(int i = 6; i >= wordLength; i--){
            texArr[i].text = "";
        }

        for (int i = 0; i < wordLength; i++){
            guess += "-";
        }
    }

    public void guessLetter(){
        string letter = inputField.GetComponent<TMP_InputField>().text;
        inputField.GetComponent<TMP_InputField>().text = "";
        Boolean dontLoseLife = false;

        for(int i = 0; i < wordLength ; i++){
            string letterAtNum = word[i].ToString();
            if(letter == letterAtNum){
                guess = guess.Remove(i, 1).Insert(i, letter);
                dontLoseLife = true;
            }
        }

        if(!dontLoseLife){
            livesLeft--;
            
            
        }
        if(guess == word){
                win();
        }
        if(livesLeft == 0){
            lose();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI[] texArr = {tex1, tex2, tex3, tex4, tex5, tex6, tex7};

        for(int i = 0; i < wordLength; i++){
            texArr[i].text = guess[i].ToString();
        }

        if(livesLeft == 4){
            img.sprite = man1;
        }
        else if(livesLeft == 3){
            img.sprite = man2;
        }
        else if(livesLeft == 2){
            img.sprite = man3;
        }
        else if(livesLeft == 1){
            img.sprite = man4;
        }
        else if(livesLeft == 0){
            img.sprite = man5;
            //show death message
            
        }

        
        
    }

    private void win(){
        winPanel.SetActive(true);
        main.riskMulti *= 0.8f;


        //decrease risk here
    }

    private void lose(){
        losePanel.SetActive(true);
        main.money -= (5 * Mathf.Pow(3, main.level));
    }

    public void final(){
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        guess = "";
        wordLength = 0;
        livesLeft = 4;





        ranNum = ((int)Math.Floor(Hangman.rand.NextDouble() * (5)));
        word = wordBank[ranNum];
        wordLength = word.Length;


        TextMeshProUGUI[] texArr = {tex1, tex2, tex3, tex4, tex5, tex6, tex7};
        for(int i = 6; i >= wordLength; i--){
            texArr[i].text = "";
        }

        for (int i = 0; i < wordLength; i++){
            guess += "-";
        }
    }
}
