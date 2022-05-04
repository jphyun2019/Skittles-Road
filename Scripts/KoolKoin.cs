using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using Newtonsoft.Json;
using TMPro;
using System;
public class KoolKoin : MonoBehaviour
{
    public Main main;
    public TextMeshProUGUI bitcoinPrice;
    public TextMeshProUGUI ethPrice;
    public TextMeshProUGUI xrpPrice;
    public TextMeshProUGUI adaPrice;
    public TextMeshProUGUI solPrice;
    public TextMeshProUGUI terrPrice;
    public TextMeshProUGUI avaPrice;
    public TextMeshProUGUI dotPrice;
    public TextMeshProUGUI dogePrice;
    public TextMeshProUGUI shibPrice;

    public TextMeshProUGUI buyText;
    public TextMeshProUGUI buyPriceText;
    public TextMeshProUGUI buyNumOfCoinsText;
    public GameObject inputField;


    public GameObject owned1;
    public GameObject owned2;
    public GameObject owned3;
    public GameObject owned4;
    public GameObject owned5;
    public GameObject owned6;
    public GameObject owned7;
    public GameObject owned8;
    public GameObject owned9;
    public GameObject owned10;
    private static readonly HttpClient client = new HttpClient();
    Coins currentCoins = new Coins();

    int currentNum = 0;

    int numOfFrames = 0;
    string[] coinNames = {"Bitcoin", "Ethereum", "Ripple", "Cardano", "Solana", "Terra", "Avalanche", "Polkadot", "DogeCoin", "Shiba Inu"};
    // Start is called before the first frame update
    void Start()
    {
        fetch();
    }

    public void test(){
        Debug.Log("TESTTT");
    }

    public async void displayCryptoOwned(){
        GameObject[] allOwnedDisplayers = {owned1, owned2, owned3, owned4, owned5, owned6, owned7, owned8, owned9, owned10};

        for(int i = 0; i >= main.allCrypto.Count; i--){
            allOwnedDisplayers[i].SetActive(false);
        }
        // for(int i = 0; i < main.allCrypto.Count; i++){
        //     allOwnedDisplayers.Ge
        // }
    }
    public void coinBuyChosen(int num){
        if(currentCoins.data.Count != 0){
            currentNum = num;
            var coinName = coinNames[num];
            buyText.text = "Buy " + coinName;
            buyPriceText.text = "Price: $" + Math.Round(currentCoins.data[num].price, 2);
        }
    }

    public async void buyPressed(){
        var usd = Math.Round(double.Parse(inputField.GetComponent<TMP_InputField>().text), 2);
        inputField.GetComponent<TMP_InputField>().text  = "";
        //get net worth
        main.money -= (float) usd;
        double numOfCoins = usd / currentCoins.data[currentNum].price;
        string cryptoName = currentCoins.data[currentNum].id;
        Boolean cryptoAlrBought = false;
        int numAtAll = 0;
        for(int i = 0; i < main.allCrypto.Count; i++){
            if (main.allCrypto[i].name == cryptoName){
                cryptoAlrBought = true;
                numAtAll = i;
            }
        }
        if (cryptoAlrBought){
            main.allCrypto[numAtAll].usdAmt += usd;
        }
        else {
            Crypto newBuy = new Crypto(currentCoins.data[currentNum].id,numOfCoins, usd);
            main.allCrypto.Add(newBuy);
        }
        
        //add ["Bitcoin": usd/price]
    }

    public async void fetch(){
        Debug.Log("lol");
        var responseString = await client.GetStringAsync("https://api.nomics.com/v1/currencies/ticker?key=5987e7413cd4a604e75e3cf60947e5dfc6837a2d&ids=BTC,ETH,XRP,ADA,SOL,LUNA,AVAX,DOT,DOGE,SHIB&interval=1hr&per-page=100&page=1");
        responseString = @"{""data"":" + responseString + "}";
        var allCoins = JsonConvert.DeserializeObject<Coins>(responseString);
        currentCoins = allCoins;

        //set text
        TextMeshProUGUI[] priceArr = {bitcoinPrice, ethPrice, xrpPrice, adaPrice, solPrice, terrPrice, avaPrice, dotPrice, dogePrice, shibPrice};
        for(int i = 0; i < priceArr.Length; i++){
            Debug.Log(i);
            Debug.Log( allCoins.data[i].price);
            priceArr[i].text = "$" + Math.Round(allCoins.data[i].price, 2);
        }

    }
    void FixedUpdate()
    {
        numOfFrames++;
        if(numOfFrames == 500){
            numOfFrames = 0;
            fetch();
        }
    }
}

