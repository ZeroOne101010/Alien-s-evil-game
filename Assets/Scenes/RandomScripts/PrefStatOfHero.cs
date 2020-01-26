using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefStatOfHero : MonoBehaviour
{
    public int CountOfGold;
    public int Experiance;
    public int CountOfKills;

    public void Save()
    {
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + CountOfGold);
        PlayerPrefs.Save();
    }
}
