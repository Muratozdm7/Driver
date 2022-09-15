using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuanText : MonoBehaviour
{
    public TMP_Text coinText;
    public static int coinMiktar;

    
    void Update()
    {
        coinText.text = coinMiktar.ToString();
    }
}
