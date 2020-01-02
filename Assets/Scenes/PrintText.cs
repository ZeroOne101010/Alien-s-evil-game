using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintText : MonoBehaviour
{
    void Update()
    {
        print(PlayerPrefs.GetInt("Gold"));
        print(PlayerPrefs.GetInt("Exp"));
        print(PlayerPrefs.GetInt("Level"));
    }
}
