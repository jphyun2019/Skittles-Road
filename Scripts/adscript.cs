using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class adscript : MonoBehaviour
{

    float cost;
    float gain;
    int timer;
    public Main main;

    public butt buybutt;
    public Text irecieve;
    public Text urecieve;
    public Text title;
    public Text time;
    public Text buttontxt;
    public Text levelText;

    bool bought;



    private void Start()
    {
        timer = 1000;
        generate();
    }

    void FixedUpdate()
    {
        if(timer > 0)
        {
            timer--;
        }
        else
        {
            timer = 1000;
            generate();
        }

        if((cost <= main.money) && (!bought))
        {
            buybutt.enable();
        }
        else
        {
            buybutt.disable();
        }


        //title.setText("Advertising" + main.AdvertisingLvl);
        levelText.setText("Advertising Level: "+ main.AdvertisingLvl);
        irecieve.setText("i recieve: $" + cost);
        urecieve.setText("you recieve: " + gain + " level");

        time.setText("Time Remaining: " + (timer / 50));

    }

    public void generate()
    {
        bought = false;
        cost = Mathf.Round(Random.Range(500, 2000));
        gain = Mathf.Round(Random.Range(1, 3)*100f)/100f;
        buttontxt.setText("Buy");
        buybutt.enable();

    }

    public void buy()
    {
        main.AdvertisingLvl += gain;
        main.money -= cost;
        buttontxt.setText("Purchased");
        buybutt.disable();
        bought = true;

    }



}
