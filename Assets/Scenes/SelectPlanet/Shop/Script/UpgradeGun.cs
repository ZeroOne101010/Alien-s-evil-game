using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGun : MonoBehaviour
{
    public string TypeGun;
    public int Cost;
    public int Multiplier;
    private void Start()
    {
            Cost = (PlayerPrefs.GetInt(TypeGun) * (PlayerPrefs.GetInt(TypeGun) + 1)) * Multiplier / 2;
    }
    public void UpgradeOfGun()
    {
        if (PlayerPrefs.GetInt("Gold") >= Cost)
        {
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") - Cost);
            PlayerPrefs.SetInt(TypeGun, PlayerPrefs.GetInt(TypeGun) + 1);
            Cost = (PlayerPrefs.GetInt(TypeGun) * (PlayerPrefs.GetInt(TypeGun) + 1)) * Multiplier / 2;
        }
    }
}
