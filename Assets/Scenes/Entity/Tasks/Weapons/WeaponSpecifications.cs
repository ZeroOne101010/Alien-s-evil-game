using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpecifications : MonoBehaviour
{
    public string weaponName;
    public float weaponDamage;
    public float weaponAttackSpeed;
    public string weaponDescription;
    public string weaponReestrKey;
    public void Start()
    {
        if (PlayerPrefs.GetInt(weaponReestrKey) != 0)
        {
            weaponDamage *= PlayerPrefs.GetInt(weaponReestrKey);
            weaponAttackSpeed *= PlayerPrefs.GetInt(weaponReestrKey);
        }
        else
            PlayerPrefs.SetInt(weaponReestrKey, 1);    
    }
}
