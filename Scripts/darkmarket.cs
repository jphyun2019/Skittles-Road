using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darkmarket : MonoBehaviour
{
    public butt pro1;
    public butt pro2;
    public butt pro3;
    public butt mar1;
    public butt mar2;
    public butt mar3;

    public bool bpro1;
    public bool bpro2;
    public bool bpro3;
    public bool bmar1;
    public bool bmar2;
    public bool bmar3;




    public Main main;


    public void uppro(float x)
    {
        main.incomeMulti += (x/10);
        main.money -= 10000f;

        switch (x){

            case 5:
                bpro1 = true;
                break;
            case 10:
                bpro2 = true;
                break;
            case 15:
                bpro3 = true;
                break;
        }





    }
    public void upmar(float x)
    {
        main.incomeMulti += (x/10);
        main.money -= 10000f;
        switch (x)
        {

            case 5:
                bmar1 = true;
                break;
            case 10:
                bmar2 = true;
                break;
            case 15:
                bmar3 = true;
                break;
        }



    }


    private void Update()
    {
        if (main.money >= 30000)
        {

            if (!bpro1)
            {
                pro1.enable();
            }
            else
            {
                pro1.disable();
            }
            if (!bpro2)
            {
                pro2.enable();
            }
            else
            {
                pro2.disable();
            }
            if (!bpro3)
            {
                pro3.enable();
            }
            else
            {
                pro3.disable();
            }
            if (!bmar1)
            {
                mar1.enable();
            }
            else
            {
                mar1.disable();
            }
            if (!bmar2)
            {
                mar2.enable();
            }
            else
            {
                mar2.disable();
            }
            if (!bmar3)
            {
                mar3.enable();
            }
            else
            {
                mar3.disable();
            }
        }
        else if(main.money >= 20000)
        {

            if (!bpro1)
            {
                pro1.enable();
            }
            else
            {
                pro1.disable();
            }
            if (!bpro2)
            {
                pro2.enable();
            }
            else
            {
                pro2.disable();
            }
            if (!bmar1)
            {
                mar1.enable();
            }
            else
            {
                mar1.disable();
            }
            if (!bmar2)
            {
                mar2.enable();
            }
            else
            {
                mar2.disable();
            }
            pro3.disable();
            mar3.disable();

        }
        else if (main.money >= 10000)
        {

            if (!bpro1)
            {
                pro1.enable();
            }
            else
            {
                pro1.disable();
            }
            if (!bmar1)
            {
                mar1.enable();
            }
            else
            {
                mar1.disable();
            }
            pro2.disable();
            mar2.disable();
            pro3.disable();
            mar3.disable();
        }
        else
        {
            pro1.disable();
            mar1.disable();
            pro2.disable();
            mar2.disable();
            pro3.disable();
            mar3.disable();
        }


    }




}
