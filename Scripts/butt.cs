using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class butt : MonoBehaviour
{
    public Button buttt;

    public void disable()
    {
        buttt.interactable = false;
    }
    public void enable()
    {
        buttt.interactable = true;
    }


}
