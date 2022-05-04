using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    // Start is called before the first frame update


    public TextMeshProUGUI tex;

    public void setText(string x)
    {
        tex.text = x;
    }


}
