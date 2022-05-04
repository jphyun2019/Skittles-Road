using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FactoryUpgrade : MonoBehaviour
{

    public Text name;
    public Text sps;
    public Text level;
    public Text upgradePrompt;
    public Factory[] factories;
    public int currentFactory = 0;
    public butt upgradebut;
    public Main main;
   

    

    public void updateMenu()
    {
        name.setText("Factory " + (currentFactory+1).ToString());
        sps.setText(((factories[currentFactory].income)*50).ToString() + " SPS");
        level.setText("Level " + (factories[currentFactory].level).ToString());

        if ((factories[currentFactory].level) < 5)
        {
            upgradebut.enable();
            upgradePrompt.setText("Upgrade for $" + (factories[currentFactory].cost).ToString());
        }
        else
        {
            upgradePrompt.setText("Max Level");
            upgradebut.disable();
        }
       
    }

    public void upgrade()
    {
        main.money -= factories[currentFactory].cost;
        factories[currentFactory].level++;
        factories[currentFactory].updateFactory();
        updateMenu();
        
    }
    public void FixedUpdate()
    {
        if (main.money >= factories[currentFactory].cost)
        {
            upgradebut.enable();
        }
        else
        {
            upgradebut.disable();
        }
    }




}
