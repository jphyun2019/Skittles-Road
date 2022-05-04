using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Main main;

    public butt lower;

    public Text price;


    public void adjPrice(bool s)
    {
        if (s)
        {
            main.price += 0.01f;
        }
        else
        {
            if(main.price > 0)
            {
                main.price -= 0.01f;
            }
        }

        if(main.price == 0)
        {
            lower.disable();
        }
        else
        {
            lower.enable();
        }

        price.setText("$"+ (Mathf.Round(main.price*100f)/100f).ToString());


    }




}
