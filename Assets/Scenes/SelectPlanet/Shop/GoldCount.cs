using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCount : MonoBehaviour
{
    

    void Update()
    {
        GetComponent<Text>().text = "x" + PlayerPrefs.GetInt("Gold").ToString();
    }
}
