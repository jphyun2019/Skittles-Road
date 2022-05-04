using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDownScript : MonoBehaviour
{
    public butt manubut;
    public butt techbut;
    public butt maxbut;
    public butt statbut;
    public butt factbut;
    public butt upbutt;
    public butt firebutt;
    public butt recipebutt;
    public butt pricebutt;
    public butt advbutt;
    public butt statsbutt;
    public butt logbutt;

    public GameObject onion;

    public Main main;


    public butt mafia;
    public butt stonks;
    public butt mafia2;


    public void updateDropdown()
    {
        switch (main.level)
        {
            case 0:

                mafia.disable();
                stonks.disable();
                mafia2.disable();
                onion.SetActive(false);
                firebutt.disable();
                maxbut.disable();
                statbut.disable();
                break;

            case 1:
                maxbut.enable();
                recipebutt.disable();
                advbutt.disable();
                break;

            case 2:
                advbutt.enable();
                break;

            case 3:
                statbut.enable();
                break;

            case 4:
                firebutt.enable();
                break;

            case 5:
                recipebutt.enable();
                break;

            case 6:
                onion.SetActive(true);

                break;
            case 7:
                stonks.enable();

                break;
            case 8:
                mafia.enable();
                mafia2.enable();

                break;
            case 9:


                break;



        }
    }



}
