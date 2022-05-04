using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class technologypage : MonoBehaviour
{
    public Main main;
    public Text tex;
    public Text upcost;
    public int levelSelected = 1;
    public int[] upgradeCosts = { 400, 800, 1000, 2000, 10000, 30000, 100000, 300000};
    public butt upgradebutt;
    public Text descriptionText;

    public butt[] upgrades;

    public dropDownScript drop;


    public void techdesc(int level)
    {
        levelSelected = level;
        switch (level)
        {
            case 1:
                tex.setText("Unlocks Price Control \n \nGo to maximizer --> price to check out new options in controlling the price per skittle");
                descriptionText.setText("Level 1: Technology Upgrade");

                break;
            case 2:
                tex.setText("Unlocks Advertisements \n \nGo to maximizer --> advertise to check out new options in advertising and increasing demand for skittles");
                descriptionText.setText("Level 2: Technology Upgrade");

                break;
            case 3:
                tex.setText("unlocks Statistics Page \n \nGo to statistics --> stats to look at an overview of revenue and overall statistics.");
                descriptionText.setText("Level 3: Technology Upgrade");

                break;
            case 4:
                tex.setText("Unlocks Firewall Upgrades \n \nGo to technology --> firewall to upgrade firewall and increase site security");
                descriptionText.setText("Level 4: Technology Upgrade");

                break;
            case 5:
                tex.setText("Unlocks Custom Recipes \n \nGo to maximization --> recipe to upgrade recipe components to create the most appetizing and market-desirable skittle ever!");
                descriptionText.setText("Level 5: Technology Upgrade");

                break;
            case 6:
                tex.setText("?????????");
                descriptionText.setText("Level 6: Technology Upgrade");

                break;
            case 7:
                tex.setText("?????????");
                descriptionText.setText("Level 7: Technology Upgrade");

                break;
            case 8:
                tex.setText("?????????");
                descriptionText.setText("Level 8: Technology Upgrade");

                break;
        }

        if (levelSelected > main.level)
        {
            upcost.setText("Upgrade for $" + upgradeCosts[levelSelected - 1]);
        }
        else
        {
            upcost.setText("Purchased");
        }
    }
    public void upgrade()
    {
        main.money -= upgradeCosts[levelSelected - 1];
        main.level++;
        upcost.setText("Purchased");
        drop.updateDropdown();
    }


    public void Start()
    {
        tex.setText("Select an Upgrade");
        upcost.setText("");
    }

    public void FixedUpdate()
    {
        if ((upgradeCosts[levelSelected - 1] < main.money) && (main.level < levelSelected))
        {
            upgradebutt.enable();
        }
        else
        {
            upgradebutt.disable();
        }

        int counter = main.level;
        foreach (butt b in upgrades)
        {
            if (counter >= 0)
            {
                b.enable();
                counter--;
            }
            else
            {
                b.disable();
            }

        }


    }


}
