using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelOpen : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel(){
        if (panel != null){
            panel.SetActive(!panel.active);
        }
    }
}
