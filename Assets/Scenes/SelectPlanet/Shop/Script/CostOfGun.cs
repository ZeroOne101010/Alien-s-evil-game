using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostOfGun : MonoBehaviour
{
    string Gun;
    int Money;
    private void Start()
    {
        Gun = GetComponent<UpgradeGun>().TypeGun;
        Money = GetComponent<UpgradeGun>().Cost;
        
    }
    void Update()
    {
        Gun = GetComponent<UpgradeGun>().TypeGun;
        Money = GetComponent<UpgradeGun>().Cost;
        GetComponent<Text>().text = Money.ToString() + "$";
        print("Money - " + Gun + "is" + Money);
        print("Level of " + Gun + "is" + PlayerPrefs.GetInt(Gun));
    }
}
