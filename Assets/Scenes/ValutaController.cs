using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ValutaType
{
    Coin = 0,
    Emerald = 1
}
public class ValutaController : MonoBehaviour
{
    public Text valuta;
    public ValutaType valutaType;
    void Update()
    {
        valuta.text = (GlobalScript.GetValutaValue(valutaType)).ToString();
    }
}
