using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{

    public Text skittlesCount;
    public Text moneyCount;
    public List<Crypto> allCrypto = new List<Crypto>();
    public float skittles;

    public float money;
    public float risk;
    public float riskMulti;

    public float incomeskittles;

    public float incomeMulti;
    public float outcomeMulti;

    public Factory[] factories;
    public int level;

    public float outcomeskittles;
    public float price;
    public dropDownScript drop;
    public Slidah riskslider;

    public float AdvertisingLvl;

    public float priceAdd;

    public stats stat;

    public GameObject end;
    public AudioSource endsound;



    // Start is called before the first frame update
    void Start()
    {

        Application.targetFrameRate = 30;
        skittles = 0;
        money = 800;
        level = 0;
        outcomeskittles = 0.1f;
        price = 0.7f;
        drop.updateDropdown();
        AdvertisingLvl = 0;
        riskMulti = 1;
        priceAdd = 0;
        incomeMulti = 1;
        outcomeMulti = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        risk = 0;
        // Adds up all the incomes of the factories and adds that to amount of skittles
        incomeskittles = 0;
        foreach (Factory f in factories)
        {
            incomeskittles += f.income;
        }

        incomeskittles *= incomeMulti;

        stat.made.setText((incomeskittles*50f).ToString());


        skittles += incomeskittles;

        skittlesCount.setText("Skittles: " + Mathf.Round(skittles).ToString());
        moneyCount.setText("Money: " + Mathf.Round(money).ToString());



        if (skittles >= outcomeskittles)
        {
            skittles -= outcomeskittles;
            money += outcomeskittles * (price + priceAdd);
        }

        float riskbymoney;
        riskbymoney = Mathf.Log(money/100f, 1.1f);
        risk = riskbymoney;
        foreach (Factory f in factories)
        {
            risk += f.risk;
        }

        risk *= riskMulti;


        stat.risk.setText(((1f-(Mathf.Pow((1f-(Mathf.Pow((risk/100),19f))), 50)))*100).ToString());

        riskslider.setSlider(risk);



        float i = 1 / (Mathf.Pow((risk / 100), 19f));

        int j = (int)Random.Range(0, i);

        if(j == 0)
        {
            Debug.Log("Game Over");
            end.SetActive(true);
            endsound.Play();

        }


        outcomeskittles = 0.02f * Mathf.Exp(-6f*(price - (1 + AdvertisingLvl/50)));

        outcomeskittles *= outcomeMulti;

        stat.sold.setText(outcomeskittles.ToString());


        if(skittles > 1)
        {
            stat.profit.setText((outcomeskittles * (price + priceAdd) * 50).ToString());
            stat.sold.setText((outcomeskittles*50f).ToString());
        }
        else
        {
            stat.sold.setText((incomeskittles*50f).ToString());
            stat.profit.setText((incomeskittles * (price + priceAdd) * 50).ToString());
        }

    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }






}
