using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slidah : MonoBehaviour
{

    public Slider slider;
    public Image fillar;

    public void setSlider(float x)
    {
        slider.value = x/100f;
        if (x < 25)
        {
            fillar.color = Color.green;
        }
        else if(x < 50)
        {
            fillar.color = Color.yellow;
        }
        else if(x < 75)
        {
            fillar.color = Color.red;
        }
        else
        {
            fillar.color = Color.magenta;
        }
    }



}
