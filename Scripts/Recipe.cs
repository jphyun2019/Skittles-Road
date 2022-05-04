using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    //public GameObject recipeButt;
    public Main main;
    public int tasteLevel = 0;
    public int textureLevel = 0;
    public int ingredientLevel = 0;
    public int levelSelect = 1;
    public int[] upgradeCost = {1000, 20000, 80000 };
    public butt upgradebutton;
    public Text upgradeType;
    public Text description;
    public Text upgradeButtText;
    public bool textureTest;
    public bool ingredientTest;
    public bool tasteTest;
    public butt[] tasteUpgrades;
    public butt[] textureUpgrades;
    public butt[] ingredientUpgrades;

    public string[] upgradeTypes = {"Finer Machinery", "Perfect Sugar Ratio", "Perfect Flavoring", 
                                    "Perfect Chew", "Perfect Crunch", "Perfect Consistency", 
                                    "High-Quality Cane Sugar", "Vibrant Dyes","Fair Trade"};
    public string[] descriptions = {"Finer machinery will produce higher quality skittles", 
                                    "Get the sugar ratio justtttt right.", 
                                    "The most delicious tasting skittle you'll ever eat.",
                                    "MMM \"That\" Chewiness.", 
                                    "MMM \"That\" Crunchiness.",
                                    "MMM \"That\" perfect  combination of chewy and crunchy.", 
                                    "Elite cane sugar from the shores of Sri Lanka.", 
                                    "The most beautiful skittles you'll ever see.", 
                                    "Sleep well knowing your ingredients are ethically sourced."};
    
    public void recipeUpgradeDesc(int level)
    {
        textureTest = false;
        ingredientTest = false;
        tasteTest = false;

    levelSelect = level;
        switch(level)
        {
            case 1:
                upgradeType.setText(upgradeTypes[0]);
                description.setText(descriptions[0]);
                break;
            case 2: 
                upgradeType.setText(upgradeTypes[1]);
                description.setText(descriptions[1]);
                break;
            case 3:
                upgradeType.setText(upgradeTypes[2]);
                description.setText(descriptions[2]);
                break;
            case 4:
                upgradeType.setText(upgradeTypes[3]);
                description.setText(descriptions[3]);
                break;
            case 5: 
                upgradeType.setText(upgradeTypes[4]);
                description.setText(descriptions[4]);
                break;
            case 6:
                upgradeType.setText(upgradeTypes[5]);
                description.setText(descriptions[5]);
                break;
            case 7:
                upgradeType.setText(upgradeTypes[6]);
                description.setText(descriptions[6]);
                break;
            case 8: 
                upgradeType.setText(upgradeTypes[7]);
                description.setText(descriptions[7]);
                break;
            case 9:
                upgradeType.setText(upgradeTypes[8]);
                description.setText(descriptions[8]);
                break;
        }
        
        // if (levelSelect <= 3 && levelSelect > tasteLevel){
            
        //     upgradeButtText.setText("Upgrade for $"+upgradeCost[levelSelect - 1]);
        // }
        // else if (levelSelect<=6 && ((levelSelect-3)>textureLevel)){
        //     levelSelect -= 3;
        //     upgradeButtText.setText("Upgrade for $"+upgradeCost[levelSelect - 1]);
        //     textureTest=true;
        // }
        // else if (levelSelect<=9 && ((levelSelect-6)>ingredientLevel)){
        //     levelSelect -= 6;
        //     upgradeButtText.setText("Upgrade for $"+upgradeCost[levelSelect - 1]);
        //     ingredientTest=true;
        // }
        // else{
        //     upgradeButtText.setText("Purchased");
        // }
        if (levelSelect>6){
            levelSelect -= 6;
            if (levelSelect > ingredientLevel){
                ingredientTest = true;
                upgradebutton.enable();
                upgradeButtText.setText("Upgrade for $"+ upgradeCost[levelSelect-1]);
            }  
            else 
                upgradeButtText.setText("Purchased");
                upgradebutton.disable();

        }
        else if (levelSelect >3){
            levelSelect -= 3;
            if (levelSelect > textureLevel)
            {
                textureTest = true;
                upgradebutton.enable();
                upgradeButtText.setText("Upgrade for $" + upgradeCost[levelSelect - 1]);
            }
            else
                upgradeButtText.setText("Purchased");
                 upgradebutton.disable();
        }
        else{
            if (levelSelect > tasteLevel)
            {
                tasteTest = true;
                upgradebutton.enable();
                upgradeButtText.setText("Upgrade for $" + upgradeCost[levelSelect - 1]);
            }
            else
                upgradeButtText.setText("Purchased");
                upgradebutton.disable();
        }

        
    }

    public void upgradeRecipe(){
        main.money -= upgradeCost[levelSelect-1];
        if(textureTest){
            textureLevel++;
            upgradeButtText.setText("Purchased");
            upgradebutton.disable();


        }
        else if(ingredientTest){
            ingredientLevel++;
            upgradeButtText.setText("Purchased");
            upgradebutton.disable();


        }
        else{
            tasteLevel++;
            upgradeButtText.setText("Purchased");
            upgradebutton.disable();

        }
    }

    public void FixedUpdate()
    {
        
        if (upgradeCost[levelSelect - 1] <= main.money)
        {
            if (textureTest && (textureLevel< levelSelect))
            {
                upgradebutton.enable();
            }
            else if (ingredientTest && (ingredientLevel < levelSelect))
            {
                upgradebutton.enable();
            }
            else if (tasteTest && (tasteLevel < levelSelect))
            {
                upgradebutton.enable();
            }
            else
            {
                upgradebutton.disable();
            }
        }
        else
            upgradebutton.disable();


        main.priceAdd = ((tasteLevel + textureLevel + ingredientLevel) / 20f);








        int counter1 = tasteLevel +1;
        foreach (butt b in tasteUpgrades){
            if (counter1 > 0){
                b.enable();
                counter1--;
            }
            else{
                b.disable();
            }
        }
        int counter2 = textureLevel +1;
        foreach (butt b in textureUpgrades){
            if (counter2 > 0){
                b.enable();
                counter2--;
            }
            else{
                b.disable();
            }
        }
        int counter3 = ingredientLevel +1;
        foreach (butt b in ingredientUpgrades){
            if (counter3 > 0){
                b.enable();
                counter3--;
            }
            else{
                b.disable();
            }
        }

    }

 
}
