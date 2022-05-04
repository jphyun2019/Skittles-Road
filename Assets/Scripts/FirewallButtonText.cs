using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class FirewallButtonText : MonoBehaviour
{

    public Main main;
    public TextMeshProUGUI tex1;
    public TextMeshProUGUI tex2;
    public butt yes;
    public butt no;


    void Start() {
        tex1.text = "Play\ncost: $" + (5 * Mathf.Pow(3, main.level));
        tex2.text = "Decline\ncost: $" + (10 * Mathf.Pow(3, main.level));
    }

    private void FixedUpdate()
    {

        tex1.text = "Play\ncost: $" + (5 * Mathf.Pow(3, main.level));
        tex2.text = "Decline\ncost: $" + (10 * Mathf.Pow(3, main.level));




        if (main.money >= (10 * Mathf.Pow(3, main.level))){
            yes.enable();
            no.enable();
        }
        else if(main.money >= (5 * Mathf.Pow(3, main.level))){
            no.disable();
            yes.enable();
        }
        else
        {
            yes.disable();
            no.disable();

        }


    }


    public void loserRoute() {

        main.money -= (10 * Mathf.Pow(3, main.level));
        main.riskMulti *= 0.8f;
    }

    public void nonLoserRoute(){
        main.money -= (5 * Mathf.Pow(3, main.level));
    }
}
