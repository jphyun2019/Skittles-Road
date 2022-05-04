using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class HitmanPrice : MonoBehaviour
{
    public Main main;
    public int[] hitmanCosts = {40000, 55000, 90000, 120000};
    public int priceSelect = 0;
    public string[] resultText = {"Congratulations! You have successfully eliminated a competitor", "Boo. You failed in eliminating a competitor- better luck next time."};
    public Text displayText;
    public butt purchaseButt;
    public double successRate;
    public bool success;

    public void killingdesc (int choice){
        priceSelect = choice;
    }

    public void purchase(){
        main.money -= hitmanCosts[priceSelect];
        if (priceSelect ==0){
            successRate = Random.Range(0.0f, 20.0f);
        }
        else if (priceSelect == 1){
            successRate = Random.Range(0.0f, 15.0f);
        }
        else if(priceSelect == 2){
            successRate = Random.Range(0.0f, 10.0f);
        }
        else{
            successRate = Random.Range(0.0f,5.5f);
        }
        if (successRate>0.0f && successRate<=5.0f){
            success = true;
            displayText.setText(resultText[0]);
        }
        else{
            success = false;
            displayText.setText(resultText[1]);
        }
    }

    public void FixedUpdate(){
        if (hitmanCosts[priceSelect]<=main.money){
            purchaseButt.enable();
        }
        else{
            purchaseButt.disable();
        }
    }
    

}
