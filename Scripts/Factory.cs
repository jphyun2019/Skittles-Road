using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour
{


    public GameObject factory;
    public float income;
    public float risk = 0;
    public int level;
    public int number;

    public float cost;

    public float size;

    public FactoryUpgrade upmenu;


    public static float[] skittlesPerLevel = { 0, 0.2f, 0.4f, 0.7f, 1f, 1.4f};
    public static float[] costPerLevel = {200, 500, 1000, 3000, 10000, 0};



    public void Start()
    {
        factory.GetComponent<Image>().color = Color.black;
        updateFactory();
        this.size = 1;
        this.risk = 0;
    }
    public void setLevel(int l)
    {
        this.level = l;
        this.size = 1 + ((float)l / 5);
    }
    public void updateFactory()
    {
        if(this.level > 0)
        {
            factory.GetComponent<Image>().color = Color.white;
            risk = 5;
        }
        this.income = skittlesPerLevel[level];
        this.cost = costPerLevel[level];
        this.size = 1 + ((float)level / 5);

        factory.transform.localScale = new Vector3(size, size, 0);

    }
    public void openMenu()
    {
        upmenu.currentFactory = number;
        upmenu.updateMenu();
    }



}
