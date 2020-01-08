using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinMenuBar : MonoBehaviour
{
    public Text coinCount;
    //public string reestrKey;
    void Start()
    {

    }
    void Update()
    {
        AssingVariables();
    }
    public void AssingVariables()
    {
        coinCount.text = PlayerPrefs.GetInt(GlobalScript.coinReestrKey).ToString();
    }
}
