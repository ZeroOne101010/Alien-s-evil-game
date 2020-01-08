using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public string TypeOfGun;
    public int MultiplerOfDamage;
    public bool AfterUpdate;
    void Update()
    {
        if(AfterUpdate == true)
            GetComponent<Text>().text = (MultiplerOfDamage * (PlayerPrefs.GetInt(TypeOfGun)+1)).ToString();
        else
            GetComponent<Text>().text = (MultiplerOfDamage * PlayerPrefs.GetInt(TypeOfGun)).ToString();

    }
}
